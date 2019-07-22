using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSharperDemo;

namespace ReSharperDemos.Tests
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void Should_Get_Location()
        {
            var booking = new Booking();

            var result = booking.GetLocation();
            Assert.AreEqual("Here", result);
        }

        //[TestMethod]
        //public void Should_Get_Alternate_Location()
        //{
        //    var booking = new Booking();

        //    var result = booking.AlternateGetLocation("London");
        //    Assert.AreEqual("HereLondon", result);
        //}

        //[TestMethod]
        //public void Should_Get_Further_Discount()
        //{
        //    var booking = new Booking();

        //    var result = booking.FurtherDiscount(10,20);
        //    Assert.AreEqual(30, result);
        //}
        //

        [TestMethod]
        public void Should_Throw_An_Exception()
        {
            var number = StackTraceExplorer.GetNumber();

            
            Assert.AreEqual(30, number);
        }


    }
}
