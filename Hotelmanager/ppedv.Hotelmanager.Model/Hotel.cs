using System.Collections.Generic;

namespace ppedv.Hotelmanager.Model
{
    public class Hotel : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Zimmer> Zimmer { get; set; } = new HashSet<Zimmer>();
        public virtual ICollection<Buchung> Buchungen { get; set; } = new HashSet<Buchung>();
    }

}
