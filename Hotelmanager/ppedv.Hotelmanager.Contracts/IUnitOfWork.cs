using ppedv.Hotelmanager.Model;

namespace ppedv.Hotelmanager.Contracts
{
    public interface IUnitOfWork
    {
        IHotelRepository HotelRepository { get; }

        #region optional für alle Typen 1 Repo festlegen
        IBaseRepository<Buchung> BuchungenRepository { get; }
        IBaseRepository<Gast> GastRepository { get; }
        IBaseRepository<Zimmer> ZimmerRepository { get; }
        #endregion

        #region oder eine generische Methode für alle
        IBaseRepository<T> GetRepository<T>() where T : Entity;

        #endregion

        void SaveAll();
    }

}
