using System;
using System.Linq;
using HotelRestAPI.DBUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace UnitTestRestAPI
{
    [TestClass]
    public class ManageHotelTest
    {
        [TestMethod]
        public void Test_Hotel_GetSpecific()
        {
            //Arrange
            Hotel testHotel = new Hotel(9999, "Test", "Test");
            ManageHotel manageHotel = new ManageHotel();
            manageHotel.Post(testHotel);

            //Act
            Hotel actualHotel = manageHotel.Get(9999);

            //Cleanup
            manageHotel.Delete(9999);

            //Assert
            Assert.AreEqual(testHotel, actualHotel);
        }


        [TestMethod]
        public void Test_Hotel_Post()
        {
            //Arrange
            Hotel testHotel = new Hotel(9999, "Test","Test");
            ManageHotel manageHotel = new ManageHotel();
            int hotelsbefore = (from h in manageHotel.Get()
                select h.ID).Count();


            //Act
            bool ok = manageHotel.Post(testHotel);
            int hotelsAfter = (from h in manageHotel.Get()
                select h.ID).Count();
            Hotel addedHotel = manageHotel.Get(9999);


            //Cleanup
            manageHotel.Delete(9999);
            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(testHotel, addedHotel);
            Assert.AreEqual(hotelsbefore+1, hotelsAfter);
        }

        [TestMethod]

        public void Test_Hotel_Delete()
        {
            //Arrange 
            Hotel testHotel = new Hotel(9999, "Test", "Test");
            ManageHotel manageHotel = new ManageHotel();
            manageHotel.Post(testHotel);
            int hotelsBefore = (from h in manageHotel.Get() select h.ID).Count();

            //Act
            bool ok = manageHotel.Delete(9999);
            int hotelsAfter = (from h in manageHotel.Get() select h.ID).Count();


            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(hotelsBefore-1, hotelsAfter);
        }

        [TestMethod]
        public void Test_Hotel_Put()
        {
            //Arrange
            Hotel testHotel = new Hotel(9999, "Test", "Test");
            ManageHotel manageHotel = new ManageHotel();
            manageHotel.Post(testHotel);
            Hotel expectedHotelUpdate = new Hotel(8888, "Test2", "Test2");


            //Act
            bool ok = manageHotel.Put(9999, expectedHotelUpdate);
            Hotel actualUpdatedHotel = manageHotel.Get(8888);

            //Cleanup
            manageHotel.Delete(8888);
            manageHotel.Delete(9999);

            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(expectedHotelUpdate, actualUpdatedHotel);
        }
    }
}
