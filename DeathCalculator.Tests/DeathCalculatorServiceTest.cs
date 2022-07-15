using DeathCalculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeathCalculator.Tests
{
    [TestClass]
    public class DeathCalculatorServiceTest
    {
        #region Fields

        private DeathCalculatorService _service;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            this._service = new DeathCalculatorService();
        }

        #region (public) Methods
        [TestMethod]
        public void GetAverageKilledPerson_Test()
        {
            var response = this._service.GetAverageKilledPerson(10, 12, 13, 17);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(double));
            Assert.AreEqual(4.5, response);
        }

        [TestMethod]
        public void IsValidData_PositifTest()
        {
            var response = this._service.IsValidData(10, 12, 13, 17);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(bool));
            Assert.AreEqual(true, response);
        }

        [TestMethod]
        public void IsValidData_NegatifTest()
        {
            var response = this._service.IsValidData(-1, 12, -2, 17);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(bool));
            Assert.AreEqual(false, response);
        }

        [TestMethod]
        public void calculateSumFibo_Test()
        {
            var response = this._service.GetAverageKilledPerson(10, 10, 13, 17);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(double));
        }

        #endregion
    }
}
