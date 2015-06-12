using System;
using HassRandomLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HassRandomLanguageTests
{
    [TestClass]
    public class LanguageValidatorTests
    {
        [TestMethod]
        public void LangaugeTest1()
        {
            var languageValidator = new LanguageValidator("a^nb^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsTrue(languageValidator.IsWordValid("1122"));
            Assert.IsTrue(languageValidator.IsWordValid("aabb"));
        }

        [TestMethod]
        public void LangaugeTest2()
        {
            var languageValidator = new LanguageValidator("a^nb^nc^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsTrue(languageValidator.IsWordValid("112233"));
            Assert.IsTrue(languageValidator.IsWordValid("bbddgg"));
            Assert.IsFalse(languageValidator.IsWordValid("aabb"));
        }

        [TestMethod]
        public void LangaugeTest3()
        {
            var languageValidator = new LanguageValidator("a^nb^nc^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsFalse(languageValidator.IsWordValid("11233"));
            Assert.IsFalse(languageValidator.IsWordValid("bbk33"));
        }

        [TestMethod]
        public void LangaugeTest4()
        {
            var languageValidator = new LanguageValidator("a^nb^nc^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsTrue(languageValidator.IsWordValid("123"));
            Assert.IsTrue(languageValidator.IsWordValid("dca"));
        }

        [TestMethod]
        public void LangaugeTest5()
        {
            var languageValidator = new LanguageValidator("a^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsTrue(languageValidator.IsWordValid("1"));
            Assert.IsTrue(languageValidator.IsWordValid("d"));
            Assert.IsFalse(languageValidator.IsWordValid("da"));
            Assert.IsFalse(languageValidator.IsWordValid("dw"));
        }

        [TestMethod]
        public void LangaugeTest6()
        {
            var languageValidator = new LanguageValidator("a^na^na^na^na^na^na^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsTrue(languageValidator.IsWordValid("111222111222333aaakkk"));
        }

        [TestMethod]
        public void LangaugeTest7()
        {
            var languageValidator = new LanguageValidator("z^na^nk^n");

            Assert.IsTrue(languageValidator.IsLanguageValid());
            Assert.IsTrue(languageValidator.IsWordValid("11111aaaaavvvvv"));
            Assert.IsFalse(languageValidator.IsWordValid("11111aaaaavvvv"));
        }
    }
}
