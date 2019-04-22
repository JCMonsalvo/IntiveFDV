using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IntiveFDV_BikeRental.Repository;
using IntiveFDV_BikeRental.Model;
using IntiveFDV_BikeRental.BRules;

namespace IntiveFDV_BikeRental.Test
{
    [TestClass]
    public class BussinesRulesTest
    {
        Rental TestRental = null;
        RentalRequest TestRequest = null;

        [TestMethod]
        public void CreateRental_OK()
        {
            Guid sGuid;
            TestRental = new Rental("CSTMR1");

            Assert.AreEqual("CSTMR1", TestRental.CustomerID);
            Assert.IsTrue(Guid.TryParse(TestRental.RentalID.ToString(), out sGuid));
        }

        [TestMethod]
        public void CreateRentalByRequest_OK()
        {
            Guid sGuid;
            TestRequest = new RentalRequest();
            TestRental = TestRequest.CreateNewRental("CSTMR1");

            Assert.IsInstanceOfType(TestRequest, typeof(RentalRequest));
            Assert.AreEqual("CSTMR1", TestRental.CustomerID);
            Assert.IsTrue(Guid.TryParse(TestRental.RentalID.ToString(), out sGuid));
        }

        [TestMethod]
        public void AddRentalDetailByRequest_OK()
        {
            TestRequest = new RentalRequest();
            TestRental = TestRequest.CreateNewRental("CSTMR1");
            TestRequest.AddRentalDetail(TestRental, "BK1", "ByHour", new TimeSpan(1, 0, 0));

            Assert.IsInstanceOfType(TestRequest, typeof(RentalRequest));
            Assert.IsInstanceOfType(TestRental, typeof(Rental));
            Assert.AreEqual(1, TestRental.RentalItems.Count);
            TimeSpan sResult = TestRental.RentalItems.First().To - TestRental.RentalItems.First().From;
            Assert.AreEqual(1, sResult.Hours);
        }

        [TestMethod]
        public void RentalwithoutDiscount_OK()
        {
            TestRequest = new RentalRequest();
            TestRental = TestRequest.CreateNewRental("CSTMR1");

            TestRequest.AddRentalDetail(TestRental, "BK1", "ByHour", new TimeSpan(1, 0, 0));
            TestRequest.AddRentalDetail(TestRental, "BK2", "ByHour", new TimeSpan(1, 0, 0));

            TestRequest.CalculateRentalPrice(TestRental);

            Assert.IsInstanceOfType(TestRequest, typeof(RentalRequest));
            Assert.IsInstanceOfType(TestRental, typeof(Rental));
            Assert.AreEqual(10, TestRental.TotalAmount);
            Assert.AreEqual(TestRental.TotalToPay, TestRental.TotalAmount);

        }


        [TestMethod]
        public void RentalwithDiscount_OK()
        {
            TestRequest = new RentalRequest();
            TestRental = TestRequest.CreateNewRental("CSTMR1");

            TestRequest.AddRentalDetail(TestRental, "BK1", "ByDay", new DateTime(2019, 4, 22), new DateTime(2019, 4, 23));
            TestRequest.AddRentalDetail(TestRental, "BK2", "ByDay", new DateTime(2019, 4, 22), new DateTime(2019, 4, 23));
            TestRequest.AddRentalDetail(TestRental, "BK3", "ByDay", new DateTime(2019, 4, 22), new DateTime(2019, 4, 23));

            TestRequest.CalculateRentalPrice(TestRental);

            Assert.IsInstanceOfType(TestRequest, typeof(RentalRequest));
            Assert.IsInstanceOfType(TestRental, typeof(Rental));
            Assert.AreEqual(60, TestRental.TotalAmount);
            Assert.AreEqual(42, TestRental.TotalToPay);

        }
    }
}
