using ppedv.Hotelmanager.Model;
using ppedv.Hotelmanager.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Hotelmanager.Data.EfCore
{
    public class EfRepository : IRepository
    {
        private EfContext _context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //_context.Set<T>().Add(entity);
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}
