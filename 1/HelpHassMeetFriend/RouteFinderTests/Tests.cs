using HelpHassMeetFriend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RouteFinderTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void FindFastestRoute1()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("H L");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H L");
        }

        [TestMethod]
        public void FindFastestRoute2()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("K L");
            routeFinder.TrySetStationsFromLine("A S");
            routeFinder.TrySetStationsFromLine("H A");
            routeFinder.TrySetStationsFromLine("S K");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A S K L");
        }

        [TestMethod]
        public void FindFastestRoute3()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("A C");
            routeFinder.TrySetStationsFromLine("H A");
            routeFinder.TrySetStationsFromLine("D B");
            routeFinder.TrySetStationsFromLine("B M");
            routeFinder.TrySetStationsFromLine("M R");
            routeFinder.TrySetStationsFromLine("R K");
            routeFinder.TrySetStationsFromLine("K L");
            routeFinder.TrySetStationsFromLine("A D");
            routeFinder.TrySetStationsFromLine("A B");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A B M R K L");
        }

        [TestMethod]
        public void FindFastestRoute4()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("A C");
            routeFinder.TrySetStationsFromLine("A B");
            routeFinder.TrySetStationsFromLine("H A");
            routeFinder.TrySetStationsFromLine("A D");
            routeFinder.TrySetStationsFromLine("D B");
            routeFinder.TrySetStationsFromLine("B M");
            routeFinder.TrySetStationsFromLine("M R");
            routeFinder.TrySetStationsFromLine("R K");
            routeFinder.TrySetStationsFromLine("K L");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A B M R K L");
        }

        [TestMethod]
        public void FindFastestRoute5()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("C D");
            routeFinder.TrySetStationsFromLine("A C");
            routeFinder.TrySetStationsFromLine("D L");
            routeFinder.TrySetStationsFromLine("H A");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A C D L");
        }

        [TestMethod]
        public void FindFastestRoute6()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("B M");
            routeFinder.TrySetStationsFromLine("M R");
            routeFinder.TrySetStationsFromLine("H A");
            routeFinder.TrySetStationsFromLine("R K");
            routeFinder.TrySetStationsFromLine("K L");
            routeFinder.TrySetStationsFromLine("B R");
            routeFinder.TrySetStationsFromLine("B R");
            routeFinder.TrySetStationsFromLine("A B");
            routeFinder.TrySetStationsFromLine("B K");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A B K L");
        }

        [TestMethod]
        public void FindFastestRoute7()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TrySetStationsFromLine("H L");
            routeFinder.TrySetStationsFromLine("B L");
            routeFinder.TrySetStationsFromLine("A L");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H L");
        }
    }
}
