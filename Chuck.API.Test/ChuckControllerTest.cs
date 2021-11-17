using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chuck.API.Controllers;
using Chuck.API.Entities;
using Chuck.API.Repository;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Chuck.API.Test
{
    [TestFixture]
    public class ChuckControllerTest
    {

        Mock<IDapper> _mockCon;


        ChuckController chuck;


        [SetUp]
        public void Setup()
        {
            _mockCon = new Mock<IDapper>();
            chuck = new ChuckController(_mockCon.Object);

        }

        [Test]
        public async Task Test_Get_Joke_Randomly()
        {
            var get = new ChuckNorrisJokes(Guid.NewGuid(), "Da hell", 1, DateTime.Now);

            _mockCon.Setup(x => x.GetChuckNorrisJokeAsync(null)).ReturnsAsync(get);

            var result = await chuck.GetChuckNorrisJokes();

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

        }


        [Test]
        public async Task Test_Get_Joke_By_Joke_Level()
        {

            var rand = new Random();

            var number = rand.Next(10);

            var get = new ChuckNorrisJokes(Guid.NewGuid(), "Dribble these cheeks Bugs", number, DateTime.Now);


            _mockCon.Setup(x => x.GetChuckNorrisJokeAsync(number)).ReturnsAsync(get);

            var result = await chuck.GetChuckNorrisJokes();

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(number, get.FunnyLevel);
            Assert.AreEqual(200, okResult.StatusCode);

        }


    




    }
}
