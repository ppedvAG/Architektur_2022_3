using Xunit;
using FluentAssertions;
using ppedv.Hotelmanager.Model.Contracts;
using System.Linq;
using ppedv.Hotelmanager.Model;
using Moq;

namespace ppedv.Hotelmanager.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetHotelWithMostBeds_no_Hotels_should_return_null()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.GetHotelWithMostBeds();

            result.Should().BeNull();
        }

        [Fact]
        public void GetHotelWithMostBeds_3_Hotels_h2_has_more_beds_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Hotel>()).Returns(() =>
            {
                var h1 = new Hotel() { Name = "h1" };
                h1.Zimmer.Add(new Zimmer() { AnzBetten = 4 });

                var h2 = new Hotel() { Name = "h2" };
                h2.Zimmer.Add(new Zimmer() { AnzBetten = 12 });

                var h3 = new Hotel() { Name = "h3" };
                h3.Zimmer.Add(new Zimmer() { AnzBetten = 8 });

                return new[] { h1, h2, h3 }.AsQueryable();
            });
            var core = new Core(mock.Object);

            var result = core.GetHotelWithMostBeds();

            result.Name.Should().Be("h2");
        }

        [Fact]
        public void GetHotelWithMostBeds_3_Hotels_h2_has_more_beds()
        {
            var core = new Core(new TestRepository());

            var result = core.GetHotelWithMostBeds();

            result.Name.Should().Be("h2");
        }
    }

    class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Hotel))
            {
                var h1 = new Hotel() { Name = "h1" };
                h1.Zimmer.Add(new Zimmer() { AnzBetten = 4 });

                var h2 = new Hotel() { Name = "h2" };
                h2.Zimmer.Add(new Zimmer() { AnzBetten = 12 });

                var h3 = new Hotel() { Name = "h3" };
                h3.Zimmer.Add(new Zimmer() { AnzBetten = 8 });

                return new[] { h1, h2, h3 }.AsQueryable().Cast<T>();
            }

            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }
    }
}