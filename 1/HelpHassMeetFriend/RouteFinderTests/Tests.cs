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

            routeFinder.TryGetStationsFromLine("H L");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H L");
        }

        [TestMethod]
        public void FindFastestRoute2()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TryGetStationsFromLine("K L");
            routeFinder.TryGetStationsFromLine("A S");
            routeFinder.TryGetStationsFromLine("H A");
            routeFinder.TryGetStationsFromLine("S K");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A S K L");
        }

        [TestMethod]
        public void FindFastestRoute3()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TryGetStationsFromLine("A C");
            routeFinder.TryGetStationsFromLine("H A");
            routeFinder.TryGetStationsFromLine("D B");
            routeFinder.TryGetStationsFromLine("B M");
            routeFinder.TryGetStationsFromLine("M R");
            routeFinder.TryGetStationsFromLine("R K");
            routeFinder.TryGetStationsFromLine("K L");
            routeFinder.TryGetStationsFromLine("A D");
            routeFinder.TryGetStationsFromLine("A B");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A B M R K L");
        }

        [TestMethod]
        public void FindFastestRoute4()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TryGetStationsFromLine("A C");
            routeFinder.TryGetStationsFromLine("A B");
            routeFinder.TryGetStationsFromLine("H A");
            routeFinder.TryGetStationsFromLine("A D");
            routeFinder.TryGetStationsFromLine("D B");
            routeFinder.TryGetStationsFromLine("B M");
            routeFinder.TryGetStationsFromLine("M R");
            routeFinder.TryGetStationsFromLine("R K");
            routeFinder.TryGetStationsFromLine("K L");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A B M R K L");
        }

        [TestMethod]
        public void FindFastestRoute5()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TryGetStationsFromLine("C D");
            routeFinder.TryGetStationsFromLine("A C");
            routeFinder.TryGetStationsFromLine("D L");
            routeFinder.TryGetStationsFromLine("H A");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A C D L");
        }

        [TestMethod]
        public void FindFastestRoute6()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TryGetStationsFromLine("B M");
            routeFinder.TryGetStationsFromLine("M R");
            routeFinder.TryGetStationsFromLine("H A");
            routeFinder.TryGetStationsFromLine("R K");
            routeFinder.TryGetStationsFromLine("K L");
            routeFinder.TryGetStationsFromLine("B R");
            routeFinder.TryGetStationsFromLine("B R");
            routeFinder.TryGetStationsFromLine("A B");
            routeFinder.TryGetStationsFromLine("B K");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H A B K L");
        }

        [TestMethod]
        public void FindFastestRoute7()
        {
            var routeFinder = new RouteFinder();

            routeFinder.TryGetStationsFromLine("H L");
            routeFinder.TryGetStationsFromLine("B L");
            routeFinder.TryGetStationsFromLine("A L");

            string result = string.Join("", routeFinder.GetRoutes());

            Assert.AreEqual(result, "H L");
        }
    }
}
