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

        public void Should_Get_Alternate_Location()
        {
            var booking = new Booking();

            var result = booking.AlternateGetLocation("London");
            Assert.AreEqual("HereLondon", result);
        }
    }
}
