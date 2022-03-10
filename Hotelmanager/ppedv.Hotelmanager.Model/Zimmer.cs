using System.Collections.Generic;

namespace ppedv.Hotelmanager.Model
{
    public class Zimmer : Entity
    {
        public string Nummer { get; set; }
        public string Stockwerk { get; set; }
        public int AnzBetten { get; set; }

        public virtual ICollection<Buchung> Buchungen { get; set; } = new HashSet<Buchung>();
        public virtual Hotel Hotel { get; set; }

    }

}
