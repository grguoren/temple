using Temple.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;

namespace Temple.Core.Data
{
    public class EntityContext :DbContext,IDbContext
    {
        public EntityContext()
            : base()
        {
            Database.SetInitializer<EntityContext>(null);
            //Database.SetInitializer<EntityContext>(new DropCreateDatabaseIfModelChanges<EntityContext>());//模型更改时重新创建数据库
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.LazyLoadingEnabled = true; //延时加载

            //this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;//关闭自动跟踪对象的属性变化
            //this.Configuration.LazyLoadingEnabled = false; //关闭延迟加载
            //this.Configuration.ProxyCreationEnabled = false; //关闭代理类
            this.Configuration.ValidateOnSaveEnabled = false; //关闭保存时的实体验证
            this.Configuration.UseDatabaseNullSemantics = true; //关闭数据库null比较行为
        }

        public EntityContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (Assembly assembly in BuildManager.GetReferencedAssemblies())
            {
                var types = assembly.GetTypes()
                    .Where(type => !String.IsNullOrEmpty(type.Namespace))
                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
                foreach (var type in types)
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.Configurations.Add(configurationInstance);
                }
            }
            base.OnModelCreating(modelBuilder);
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity item) where TEntity : EntityBase
        {
            return base.Entry<TEntity>(item);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        public void ValidateOnSave(bool isEnabled)
        {
            base.Configuration.ValidateOnSaveEnabled = isEnabled;
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        public int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var result = this.Database.ExecuteSqlCommand(sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }
            return result;
        }
    }
}
