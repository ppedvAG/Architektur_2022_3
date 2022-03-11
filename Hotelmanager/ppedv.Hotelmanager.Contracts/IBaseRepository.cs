using ppedv.Hotelmanager.Model;
using System.Linq;

namespace ppedv.Hotelmanager.Contracts
{
    public interface IBaseRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

}
