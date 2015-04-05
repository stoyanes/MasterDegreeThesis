﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Creates a new empty entity.
        /// </summary>
        TEntity Create();

        /// <summary>
        /// Creates the existing entity.
        /// </summary>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Updates the existing entity.
        /// </summary>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Delete an entity using its primary key.
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// Delete the given entity.
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes the existing entity.
        /// </summary>
        void Delete(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Finds one entity based on provided criteria.
        /// </summary>
        TEntity FindOne(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// Finds one entity based on its Identifier.
        /// </summary>
        TEntity FindById(long id);

        /// <summary>
        /// Finds entities based on provided criteria.
        /// </summary>
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// Save any changes to the TContext
        /// </summary>
        bool SaveChanges();
    }
}
