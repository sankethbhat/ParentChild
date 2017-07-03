using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class FileLoaderTests
    {
        [TestMethod]
        public void TestLoadedNodes()
        {
            FileLoader fileLoader = new FileLoader();

            Assert.IsTrue(fileLoader.LoadCSVFile().Count > 0);
        }
    }
}
