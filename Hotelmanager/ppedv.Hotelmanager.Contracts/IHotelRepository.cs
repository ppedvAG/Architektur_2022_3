using ppedv.Hotelmanager.Model;

namespace ppedv.Hotelmanager.Contracts
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        decimal GetHotelUmsatzberichtForYear(int year);
    }

}
