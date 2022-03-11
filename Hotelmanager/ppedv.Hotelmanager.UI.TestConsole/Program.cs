// See https://aka.ms/new-console-template for more information
using Autofac;
using ppedv.Hotelmanager.Contracts;
using ppedv.Hotelmanager.Data.EfCore;
using ppedv.Hotelmanager.Logic;
using ppedv.Hotelmanager.Model;
using System.Reflection;

Console.WriteLine("*** Hotelmanager 5000 v0.1 ***");

//Dependency Injection direkt
//var core = new Core(new ppedv.Hotelmanager.Data.EfCore.EfRepository());

//DI manuell per Reflection ohne Referenz
//var dataPath = @"C:\Users\Fred\source\repos\ppedvAG\Architektur_2022_3\Hotelmanager\ppedv.Hotelmanager.Data.EfCore\bin\Debug\net6.0\ppedv.Hotelmanager.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(dataPath);
//var repoType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = (IRepository)Activator.CreateInstance(repoType);
//var core = new Core(repo);

//DI mit AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfUnitOfWork>().AsImplementedInterfaces();
var con = builder.Build();


var core = new Core(con.Resolve<IUnitOfWork>());

foreach (var hotel in core.UnitOfWork.HotelRepository.Query().OrderByDescending(x => x.Modfied))
{
    Console.WriteLine($"{hotel.Name}");
}

Console.WriteLine($"Die meisten Betten sind in {core.GetHotelWithMostBeds().Name}");


Console.WriteLine("Ende");
Console.ReadLine();