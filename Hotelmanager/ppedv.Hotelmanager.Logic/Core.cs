using ppedv.Hotelmanager.Contracts;
using ppedv.Hotelmanager.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Hotelmanager.Logic
{
    public class Core
    {
        public IUnitOfWork UnitOfWork { get; }

        public Core(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }


        public Hotel GetHotelWithMostBeds()
        {
            return UnitOfWork.GetRepository<Hotel>().Query()
                             .OrderByDescending(x => x.Zimmer.Sum(y => y.AnzBetten))
                             .FirstOrDefault();
            
            //ODER

            return UnitOfWork.HotelRepository.Query()
                             .OrderByDescending(x => x.Zimmer.Sum(y => y.AnzBetten))
                             .FirstOrDefault();
        }

        public IEnumerable<Zimmer> GetAvailableRooms(Hotel hotel, DateTime day)
        {
            throw new NotImplementedException();
        }


    }
}
