﻿using Temple.Core.Entity;
using Temple.Core.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Data
{
    /// <summary>
    ///     单元操作实现基类
    /// </summary>
    public class UnitOfWorkContextBase : IUnitOfWorkContext
    {
        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        private IDbContext Context;

        public UnitOfWorkContextBase(IDbContext Context)
        {
            this.Context = Context;
        }

        /// <summary>
        ///     获取 当前单元操作是否已被提交
        /// </summary>
        public bool IsCommitted { get; private set; }

        /// <summary>
        ///     提交当前单元操作的结果
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = Context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
        }

        /// <summary>
        ///     把当前单元操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            IsCommitted = false;
        }

        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            Context.Dispose();
        }

        /// <summary>
        ///   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
        /// </summary>
        /// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
        /// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
        public IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return Context.Set<TEntity>();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase
        {
            return new Repository<TEntity>(this);
        }

        /// <summary>
        ///     註册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要註册的类型 </typeparam>
        /// <param name="entity"> 要註册的对象 </param>
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            EntityState state = Context.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                Context.Entry(entity).State = EntityState.Added;
            }
            IsCommitted = false;
        }

        /// <summary>
        ///     批量註册多个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要註册的类型 </typeparam>
        /// <param name="entities"> 要註册的对象集合 </param>
        public void RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterNew(entity);
                }
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        ///     註册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要註册的类型 </typeparam>
        /// <param name="entity"> 要註册的对象 </param>
        public void RegisterModified<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;
            IsCommitted = false;
        }

        /// <summary>
        ///   註册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要註册的类型 </typeparam>
        /// <param name="entity"> 要註册的对象 </param>
        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            Context.Entry(entity).State = EntityState.Deleted;
            IsCommitted = false;
        }

        /// <summary>
        ///   批量註册多个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要註册的类型 </typeparam>
        /// <param name="entities"> 要註册的对象集合 </param>
        public void RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterDeleted(entity);
                }
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }
    }
}
