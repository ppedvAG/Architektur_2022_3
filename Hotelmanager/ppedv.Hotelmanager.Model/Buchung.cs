using System;
using System.Collections.Generic;

namespace ppedv.Hotelmanager.Model
{
    public class Buchung : Entity
    {
        public DateTime Datum { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

        public virtual ICollection<Gast> Gaeste { get; set; } = new HashSet<Gast>();
        public virtual Zimmer Zimmer { get; set; }
        public virtual Hotel Hotel { get; set; }
    }

}
