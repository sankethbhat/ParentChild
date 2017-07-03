using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class CacheHandlerTests
    {
        [TestMethod]
        public void TestCache()
        {
            Assert.IsNotNull(CacheHandler.Nodes);
        }
    }
}
