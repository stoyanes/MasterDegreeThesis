using AutoMapper;
using Server.Business.Interfaces;
using Server.Data;
using Server.Data.Interfaces;
using Server.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Business.Services
{
    public class BaseBusinessService<TEntity, TEntityDto> : IBaseBusinessService<TEntityDto> where TEntity : class, IBaseEntity
    {
        protected IRepository<TEntity> entityRepository = new Repository<TEntity>(new ApplicationDbContext());
        public virtual int CreateEntity(TEntityDto newEntity)
        {
            TEntity entityToCreate = Mapper.Map<TEntity>(newEntity);
            TEntity createdEntity = entityRepository.Create(entityToCreate);
            entityRepository.SaveChanges();
            return createdEntity.Id;
        }

        public virtual bool DeleteEntityById(int id)
        {
            entityRepository.Delete(id);
            bool deleteResult = entityRepository.SaveChanges();
            return deleteResult;
        }

        public virtual IEnumerable<TEntityDto> GetAll()
        {
            var entities = entityRepository
                .FindAll()
                .ToList();
            var resultEntities = Mapper.Map<List<TEntityDto>>(entities);
            return resultEntities;
        }

        public virtual TEntityDto GetById(int id)
        {
            var entity = entityRepository.FindById(id);
            var resultEntity = Mapper.Map<TEntityDto>(entity);

            return resultEntity;
        }

        public virtual bool UpdateEntity(TEntityDto newEntity)
        {
            TEntity entityToUpdate = Mapper.Map<TEntity>(newEntity);
            entityRepository.Update(entityToUpdate);
            bool updateResult = entityRepository.SaveChanges();
            return updateResult;
        }
    }
}
