// See https://aka.ms/new-console-template for more information
using ppedv.Hotelmanager.Logic;
using ppedv.Hotelmanager.Model;

Console.WriteLine("*** Hotelmanager 5000 v0.1 ***");

var core = new Core(new ppedv.Hotelmanager.Data.EfCore.EfRepository());

foreach (var hotel in core.Repository.Query<Hotel>().OrderByDescending(x => x.Modfied))
{
    Console.WriteLine($"{hotel.Name}");
}

Console.WriteLine($"Die meisten Betten sind in {core.GetHotelWithMostBeds().Name}");


Console.WriteLine("Ende");
Console.ReadLine();