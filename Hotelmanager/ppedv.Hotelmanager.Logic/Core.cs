using ppedv.Hotelmanager.Model;
using ppedv.Hotelmanager.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Hotelmanager.Logic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }


        public Hotel GetHotelWithMostBeds()
        {
            return Repository.Query<Hotel>().OrderBy(x => x.Zimmer.Sum(y => y.AnzBetten)).FirstOrDefault();
        }

        public IEnumerable<Zimmer> GetAvailableRooms(Hotel hotel, DateTime day)
        {
            throw new NotImplementedException();
        }


    }
}
