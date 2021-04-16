using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace MovieShop2021.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut;
        private static List<Movie> _movies;
        private Mock<IMovieRepository> _mockMovieRepository;

        [TestInitialize]
        //[OneTimeSetup] in nUnit
        public void OneTimeSetup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockMovieRepository.Setup(m => m.GetTop30HighestGrossingMovies()).ReturnsAsync(_movies);

            // SUT System under Test MovieService => Get30HighestGrossing
            _sut = new MovieService(_mockMovieRepository.Object);
           
        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _movies = new List<Movie>()
            {
                new Movie {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie {Id = 2, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie {Id = 3, Title = "Avatar", Budget = 1200000},
                new Movie {Id = 4, Title = "Star Wars", Budget = 1200000},
                new Movie {Id = 5, Title = "Titanic", Budget = 1200000},
                new Movie {Id = 6, Title = "Inception", Budget = 1200000},
                new Movie {Id = 7, Title = "Avengers: Age of Ultron", Budget = 1200000},
                new Movie {Id = 8, Title = "Interstellar", Budget = 1200000},
                new Movie {Id = 9, Title = "Fight Club", Budget = 1200000},
                new Movie {Id = 10, Title = "The Lord of the Rings: The Fellowship of the Ring", Budget = 1200000}
            };

        }

        [TestMethod]
        public async Task TestListOfHighestGrossingMoviesFromFakeData()
        {
            /*
             AAA, Arrange,Act and Assert
                Arrange: Initialize objects, create mocks with arguments that are passed to the method under test and adds expectations
                Act: Invokes the method or property under test with the arranged parameters
                Assert: Verifies the action of the method under test behaves as expected
            */

            // 1. arrange: mock objects, data, methods etc
            // SUT System under Test MovieService => Get30HighestGrossing
            // _sut = new MovieService(new MockMovieRepository());

            // 2. act: call the method
            var movies = await _sut.Get30HighestGrossing(); 
             
            // 3. assert: check the actual output with expected value
            
            Assert.IsNotNull(movies); 
            Assert.IsInstanceOfType(movies,typeof(IEnumerable<MovieCardResponseModel>));
            //Assert.AreEqual(10,movies.Count);
        }
    }

   
}
