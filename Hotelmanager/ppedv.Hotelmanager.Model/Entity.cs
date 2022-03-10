using System;

namespace ppedv.Hotelmanager.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modfied { get; set; }
    }

}
