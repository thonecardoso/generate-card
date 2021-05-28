using System.Collections.Generic;
using generate_card.Entity;

namespace generate_card.Repository
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        List<T> GetAll();
        T Get(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}