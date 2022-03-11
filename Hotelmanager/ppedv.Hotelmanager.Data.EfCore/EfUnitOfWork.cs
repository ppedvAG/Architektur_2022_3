using ppedv.Hotelmanager.Contracts;
using ppedv.Hotelmanager.Model;

namespace ppedv.Hotelmanager.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EfContext _context = new();

        public IHotelRepository HotelRepository =>new EfHotelRepository(_context);

        public IBaseRepository<Buchung> BuchungenRepository => new EfBaseRepository<Buchung>(_context);

        public IBaseRepository<Gast> GastRepository => new EfBaseRepository<Gast>(_context);

        public IBaseRepository<Zimmer> ZimmerRepository => new EfBaseRepository<Zimmer>(_context);

        public IBaseRepository<T> GetRepository<T>() where T : Entity
        {
            return new EfBaseRepository<T>(_context);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
}
