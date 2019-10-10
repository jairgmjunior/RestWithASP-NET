using RestWithASPNET.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindById(long id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(long id);
        bool Exist(long? id);
    }
}
