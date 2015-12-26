using AutoMapper;
using Server.Business.Interfaces;
using Server.Data;
using Server.Data.Interfaces;
using Server.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Server.Business.Services
{
    public class BaseBusinessService<TEntity, TEntityDto> : IBaseBusinessService<TEntityDto> where TEntity : class, IBaseEntity
    {
        private IRepository<TEntity> entityRepository = new Repository<TEntity>(new ApplicationDbContext());
        public virtual int CreateEntity(TEntityDto newEntity, int? employeeId = default(int?))
        {
            if (!employeeId.HasValue)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            TEntity entityToCreate = Mapper.Map<TEntity>(newEntity);
            TEntity createdEntity = entityRepository.Create(entityToCreate);
            entityRepository.SaveChanges();
            return createdEntity.Id;
        }

        public bool DeleteEntityById(int id)
        {
            entityRepository.Delete(id);
            bool deleteResult = entityRepository.SaveChanges();
            return deleteResult;
        }

        public IEnumerable<TEntityDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntityDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(TEntityDto newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
