using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeathCalculator.Controllers;
using DeathCalculator.Service;
using Moq;
using DeathCalculator.Models;

namespace DeathCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        #region Fields

        private HomeController _controller;
        private Mock<IDeathCalculatorService> _deathCalculatorService;

        #endregion


        #region (public) Methods

        [TestInitialize]
        public void MyTestInitialize()
        {
            this._deathCalculatorService = new Mock<IDeathCalculatorService>();
            this._controller = new HomeController(this._deathCalculatorService.Object);
        }

        [TestMethod]
        public void IndexGet_PositiveTest()
        {
            var result = this._controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Index", ((ViewResult)result).ViewName);
        }

        [TestMethod]
        public void IndexPost_PositiveTest()
        {
            this._deathCalculatorService
                .Setup(m => m.IsValidData(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            this._deathCalculatorService
                .Setup(m => m.GetAverageKilledPerson(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(It.IsAny<double>);

            var model = new DeathCalculatorViewModel
            {
                YearOfDeathA = 12,
                AgeOfDeathA = 10,
                YearOfDeathB = 17,
                AgeOfDeathB = 13
            };

            var result = this._controller.Index(model);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Result", ((ViewResult)result).ViewName);
            var resultVM = (ResultViewModel)((ViewResult)result).Model;
            Assert.IsNotNull(resultVM.Result);
        }

        [TestMethod]
        public void IndexPost_NegativeTest_ModelStateIsInvalid()
        {
            this._deathCalculatorService
               .Setup(m => m.IsValidData(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
               .Returns(false);

            var model = new DeathCalculatorViewModel
            {
                YearOfDeathA = -1,
                AgeOfDeathA = 10,
                YearOfDeathB = 17,
                AgeOfDeathB = 13
            };

            var result = this._controller.Index(model);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Result", ((ViewResult)result).ViewName);
            var resultVM = (ResultViewModel)((ViewResult)result).Model;
            Assert.AreEqual(-1, resultVM.Result);
        }
        #endregion
    }
}
