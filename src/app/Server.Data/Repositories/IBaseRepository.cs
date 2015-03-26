using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories
{
    public interface IBaseRepository<T>
     where T : class
    {
        int Add(T theType);

        System.Collections.Generic.IList<T> GetAll();

        System.Collections.Generic.IList<T> GetAllByIds(int[] ids);

        T GetById(int entityId);

        bool GetExists(int entityId);

        bool Remove(int entityId);

        bool Remove(T item);

        bool Save(T theType);

        bool Update(T entity);
    }
}
