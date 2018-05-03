using Temple.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity item) where TEntity : EntityBase;

        int SaveChanges();

        void ValidateOnSave(bool isEnabled);

        DbContextConfiguration Configuration { get; }

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters);

        void Dispose();
    }
}
