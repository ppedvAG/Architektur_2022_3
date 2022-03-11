using ppedv.Hotelmanager.Contracts;
using ppedv.Hotelmanager.Model;
using System.Linq;

namespace ppedv.Hotelmanager.Data.EfCore
{
    public class EfHotelRepository : EfBaseRepository<Hotel>, IHotelRepository
    {
        public EfHotelRepository(EfContext efContext) : base(efContext)
        { }

        public decimal GetHotelUmsatzberichtForYear(int year)
        {
            //evtl. direkten SQL / Stored Proc zugriff
            return _context.Hotels.Count() * 12;
        }
    }
}
