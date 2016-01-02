using System.Collections.Generic;

namespace Server.Business.Interfaces
{
    public interface IBaseBusinessService<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        int CreateEntity(TEntity newEntity);

        bool UpdateEntity(TEntity newEntity);

        bool DeleteEntityById(int id);
    }
}
