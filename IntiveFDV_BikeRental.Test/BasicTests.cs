using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IntiveFDV_BikeRental.Model;

namespace IntiveFDV_BikeRental.Test
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void CreateBike_OK()
        {
            var testbike = new Bike()
            {
                Code = "BK1",
                Brand = "OLMO Sr",
                Style = (EnumBikeStyle)1 ,
            };

            Assert.AreEqual("BK1", testbike.Code);
            Assert.AreEqual("OLMO Sr", testbike.Brand);
            Assert.AreEqual(EnumBikeStyle.ForMan, testbike.Style);
        }

        [TestMethod]
        public void CreateBike_StyleNotInEnum_Error()
        {
            var testbike = new Bike()
            {
                Code = "BK1",
                Brand = "OLMO Sr",
                Style = (EnumBikeStyle)5,
            };

            Assert.AreEqual("BK1", testbike.Code);
            Assert.AreEqual("OLMO Sr", testbike.Brand);
            Assert.IsFalse(Enum.IsDefined(typeof(EnumBikeStyle), testbike.Style));
        }

        [TestMethod]
        public void CreatePromotion_FamilyPromotion_OK()
        {
            var promotion = new FamilyPromotion()
            {
                PromotionID = 1,
            };
            Assert.AreEqual(1, promotion.PromotionID);
            Assert.AreEqual(30, promotion.Percentage);
        }
    }
}
