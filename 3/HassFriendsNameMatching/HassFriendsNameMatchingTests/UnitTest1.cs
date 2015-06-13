using HassFriendsNameMatching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HassFriendsNameMatchingTests
{
    [TestClass]
    public class NameMatcherTests
    {
        [TestMethod]
        public void Test1()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("1 1");
            string result = nameMatcher.CalculateChanceOfSuccess("Vetta Tess Lejetta");
            Assert.IsTrue(result == "100%");
        }

        [TestMethod]
        public void Test2()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("1 0");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Julietta Frass Qetta");
            Assert.IsTrue(result == "50%");
        }

        [TestMethod]
        public void Test3()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("1 1");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Julietta Frass Qetta Petta");
            Assert.IsTrue(result == "50%");
        }

        [TestMethod]
        public void Test4()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("1 0");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Julietta Frass Qetta");
            Assert.IsTrue(result == "50%");
        }

        [TestMethod]
        public void Test5()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("0 1");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Fr1ass 23Frass 2Frass Julietta Q2etta Q3etta Q4etta Q5etta");
            Assert.IsTrue(result == "25,0%");
        }

        [TestMethod]
        public void Test6()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("2 1");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Fr1ass 23Frass 2Frass Julietta Q2etta Q3etta Q4etta Q5etta");
            Assert.IsTrue(result == "33,25%");
        }

        [TestMethod]
        public void Test7()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("2 2");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Fr1ass Julietta Q2etta");
            Assert.IsTrue(result == "100%");
        }

        [TestMethod]
        public void Test8()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("2 0");
            string result = nameMatcher.CalculateChanceOfSuccess("Jass Fr1ass Julietta Q2etta");
            Assert.IsTrue(result == "50%");
        }

        [TestMethod]
        public void Test9()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("3 1");
            string result =
                nameMatcher.CalculateChanceOfSuccess("Jass Fr1ass Jass Jass Jass Jass Jass Julietta Q2etta");
            Assert.IsTrue(result == "25%");
        }

        [TestMethod]
        public void Test10()
        {
            var nameMatcher = new NameMatcher();
            nameMatcher.SetGenderMatchCount("0 0");
            string result =
                nameMatcher.CalculateChanceOfSuccess("Jass Fr1ass Jass Jass Jass Julietta Q2etta");
            Assert.IsTrue(result == "28,70%");
        }
    }
}
