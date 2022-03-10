using System;
using System.Collections.Generic;

namespace ppedv.Hotelmanager.Model
{
    public class Gast : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }

        public virtual ICollection<Buchung> Buchungen { get; set; } = new HashSet<Buchung>();
    }

}
