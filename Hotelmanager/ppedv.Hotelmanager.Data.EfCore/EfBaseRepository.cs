using ppedv.Hotelmanager.Contracts;
using ppedv.Hotelmanager.Model;
using System.Linq;

namespace ppedv.Hotelmanager.Data.EfCore
{

    public class EfBaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly EfContext _context;

        public EfBaseRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
