using Xunit;
using FluentAssertions;
using System.Linq;
using ppedv.Hotelmanager.Model;
using Moq;
using ppedv.Hotelmanager.Contracts;

namespace ppedv.Hotelmanager.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetHotelWithMostBeds_no_Hotels_should_return_null()
        {

            var repoMock = new Mock<IHotelRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            uowMock.Setup(x => x.GetRepository<Hotel>()).Returns(repoMock.Object);
            //ODER
            uowMock.Setup(x => x.HotelRepository).Returns(repoMock.Object);

            var core = new Core(uowMock.Object);

            var result = core.GetHotelWithMostBeds();

            result.Should().BeNull();
        }

        [Fact]
        public void GetHotelWithMostBeds_3_Hotels_h2_has_more_beds_moq()
        {
            var repoMock = new Mock<IHotelRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            uowMock.Setup(x => x.GetRepository<Hotel>()).Returns(repoMock.Object);
            //ODER
            uowMock.Setup(x => x.HotelRepository).Returns(repoMock.Object);

            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var h1 = new Hotel() { Name = "h1" };
                h1.Zimmer.Add(new Zimmer() { AnzBetten = 4 });

                var h2 = new Hotel() { Name = "h2" };
                h2.Zimmer.Add(new Zimmer() { AnzBetten = 12 });

                var h3 = new Hotel() { Name = "h3" };
                h3.Zimmer.Add(new Zimmer() { AnzBetten = 8 });

                return new[] { h1, h2, h3 }.AsQueryable();
            });
            var core = new Core(uowMock.Object);

            var result = core.GetHotelWithMostBeds();

            result.Name.Should().Be("h2");
        }

        [Fact]
        public void GetHotelWithMostBeds_3_Hotels_h2_has_more_beds()
        {
            var core = new Core(new TestUnitOfWork());

            var result = core.GetHotelWithMostBeds();

            result.Name.Should().Be("h2");
        }
    }

    class TestUnitOfWork : IUnitOfWork
    {
        public IHotelRepository HotelRepository => new HotelTestRepository();

        public IBaseRepository<Buchung> BuchungenRepository => throw new System.NotImplementedException();

        public IBaseRepository<Gast> GastRepository => throw new System.NotImplementedException();

        public IBaseRepository<Zimmer> ZimmerRepository => throw new System.NotImplementedException();

        public IBaseRepository<T> GetRepository<T>() where T : Entity
        {
            if (typeof(T) == typeof(Hotel))
                return new HotelTestRepository() as IBaseRepository<T>;

            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }
    }

    class HotelTestRepository : TestRepository<Hotel>, IHotelRepository
    {
        public decimal GetHotelUmsatzberichtForYear(int year)
        {
            throw new System.NotImplementedException();
        }
    }

    class TestRepository<T> : IBaseRepository<T> where T : Entity
    {
        public void Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Query()
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
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}