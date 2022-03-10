using AutoFixture;
using AutoFixture.Kernel;
using ppedv.Hotelmanager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace ppedv.Hotelmanager.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var res = con.Database.EnsureCreated();

            Assert.True(res);
        }

        [Fact]
        public void Can_insert_Zimmer()
        {
            var zimmer = new Zimmer() { AnzBetten = 4, Nummer = "003", Stockwerk = "4" };

            var con = new EfContext();
            con.Add(zimmer);
            var rowsCount = con.SaveChanges();

            Assert.Equal(1, rowsCount);
        }

        [Fact]
        public void Can_CRUD_Gast()
        {
            var gast = new Gast() { Name = $"Fred Feuerstein {Guid.NewGuid()}", GebDatum = new DateTime(1111, 11, 11) };
            var newName = $"Wilma {Guid.NewGuid()}";

            using (var con = new EfContext()) //INSERT
            {
                con.Add(gast);
                con.SaveChanges();
            }

            using (var con = new EfContext()) //READ + UPDATE
            {
                var loaded = con.Find<Gast>(gast.Id);
                Assert.Equal(gast.Name, loaded.Name);

                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext()) //UPDATE READ + DELETE
            {
                var loaded = con.Find<Gast>(gast.Id);
                Assert.Equal(newName, loaded.Name);

                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext()) //check DELETE
            {
                var loaded = con.Find<Gast>(gast.Id);
                Assert.Null(loaded);
            }
        }


        [Fact]
        public void Can_insert_and_read_Zimmer_with_AutoFixture()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var zimmer = fix.Create<Zimmer>();

            using (var con = new EfContext()) 
            {
                con.Add(zimmer);
                con.SaveChanges();
            }
        }


    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}