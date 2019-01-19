using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JapaneseEraClassLibrary;

namespace JapaneseEraClassLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("平成31年04月30日", JapaneseEra.GetEraYMD(new DateTime(2019, 4, 30)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("新元01年05月01日", JapaneseEra.GetEraYMD(new DateTime(2019, 5, 1)));
        }
    }
}
