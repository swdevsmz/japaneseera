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
            // 明治最初
            Assert.AreEqual("明治01年01月25日", JapaneseEra.GetEraYMD(new DateTime(1868, 1, 25)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 明治最後
            Assert.AreEqual("明治45年07月29日", JapaneseEra.GetEraYMD(new DateTime(1912, 7, 29)));
        }


        [TestMethod]
        public void TestMethod3()
        {
            // 大正最初
            Assert.AreEqual("大正01年07月30日", JapaneseEra.GetEraYMD(new DateTime(1912, 7, 30)));
        }

        [TestMethod]
        public void TestMethod4()
        {
            // 大正最後
            Assert.AreEqual("大正15年12月24日", JapaneseEra.GetEraYMD(new DateTime(1926, 12, 24)));
        }


        [TestMethod]
        public void TestMethod5()
        {
            // 昭和最初
            Assert.AreEqual("昭和01年12月25日", JapaneseEra.GetEraYMD(new DateTime(1926, 12, 25)));
        }

        [TestMethod]
        public void TestMethod6()
        {
            // 昭和最後
            Assert.AreEqual("昭和64年01月07日", JapaneseEra.GetEraYMD(new DateTime(1989, 1, 7)));
        }

        [TestMethod]
        public void TestMethod7()
        {
            // 平成最初
            Assert.AreEqual("平成01年01月08日", JapaneseEra.GetEraYMD(new DateTime(1989, 1, 8)));
        }

        [TestMethod]
        public void TestMethod8()
        {
            // 平成最後
            Assert.AreEqual("平成31年04月30日", JapaneseEra.GetEraYMD(new DateTime(2019, 4, 30)));
        }

        [TestMethod]
        public void TestMethod9()
        {
            // 新元号最初
            Assert.AreEqual("新元01年05月01日", JapaneseEra.GetEraYMD(new DateTime(2019, 5, 1)));
        }
    }
}
