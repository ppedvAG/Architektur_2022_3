using System;

namespace Decorator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var lecker1 = new Schinken(new Trüffel(new Salami(new Käse(new Pizza()))));

            Console.WriteLine(lecker1.Beschreibung);
            Console.WriteLine(lecker1.Preis);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
