using System;

namespace Builder_Demo
{
    public enum Oberflächenart { Unbehandelt, Gewachst, Lackiert };
    public class Schrank
    {
        private Schrank()
        {

        }

        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public Oberflächenart Oberfläche { get; private set; }
        public string Farbe { get; private set; }
        public bool Kleiderstange { get; private set; }
        public bool Metallschiene { get; private set; }

        public static SchrankBauer BaueSchrank()
        {
            return new SchrankBauer();
        }

        public class SchrankBauer
        {
            public SchrankBauer()
            {
                zuBauenderSchrank = new Schrank();
            }

            private Schrank zuBauenderSchrank;

            public SchrankBauer MitBöden(int anzahlBöden)
            {
                if (anzahlBöden > 0 && anzahlBöden <= 6)
                    zuBauenderSchrank.AnzahlBöden = anzahlBöden;
                else
                    throw new ArgumentException("Die Anzahl der Böden ist ungültig");

                return this; // Aktuelle SchrankBauer-Instanz
            }

            public SchrankBauer MitTüren(int anzahlTüren)
            {
                if (anzahlTüren >= 2 && anzahlTüren <= 7)
                    zuBauenderSchrank.AnzahlTüren = anzahlTüren;
                else
                    throw new ArgumentException("Die Anzahl der Türen ist ungültig");

                return this;
            }
            public SchrankBauer MitMetallschiene(bool mitSchiene)
            {
                zuBauenderSchrank.Metallschiene = mitSchiene;
                return this;
            }
            public SchrankBauer MitKleiderstange(bool mitStange)
            {
                zuBauenderSchrank.Kleiderstange = mitStange;
                return this;
            }
            public SchrankBauer MitOberfläche(Oberflächenart Oberfläche)
            {
                zuBauenderSchrank.Oberfläche = Oberfläche;
                return this;
            }
            public SchrankBauer InFarbe(string Farbe)
            {
                if (zuBauenderSchrank.Oberfläche == Oberflächenart.Lackiert)
                    zuBauenderSchrank.Farbe = Farbe;
                else
                    throw new ArgumentException("Nur ein lackierter Schrank darf eine Farbe haben");
                return this;
            }

            public Schrank Konstruiere()
            {
                // ToDo: Abschließende Komplett-Validierung
                return zuBauenderSchrank;
            }
        }
    }
}
