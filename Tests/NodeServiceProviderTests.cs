using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace Tests
{
    [TestClass]
    public class NodeServiceProviderTests
    {
        [TestMethod]
        public void TestParentNameFoundAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            string parentName = nodeServiceProvider.GetParent("1VRDFB");
            Assert.IsNotNull(parentName);
        }

        [TestMethod]
        public void TestParentNameNotFoundAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            string parentName = nodeServiceProvider.GetParent("0PIOCR");
            Assert.IsTrue(parentName == string.Empty);
        }

        [TestMethod]
        public void TestChildrenFoundAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            Assert.IsTrue(nodeServiceProvider.GetChildren("1VRDFB", 3, 2).Count == 3);
        }

        [TestMethod]
        public void TestChildrenNotFoundAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            Assert.IsTrue(nodeServiceProvider.GetChildren("ABC", 3, 2).Count == 0);
        }

        [TestMethod]
        public void TestChildrenBoundaryConditionAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            Assert.IsTrue(nodeServiceProvider.GetChildren("1VRDFB", 30, 20).Count == 0);
        }

        [TestMethod]
        public void TestParentWithDepthFoundAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            Assert.IsTrue(nodeServiceProvider.GetParent("1VRDFB", 3).ChildNodes.Count == 3);
        }

        [TestMethod]
        public void TestParentWithDepthNotFoundAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            Assert.IsNull(nodeServiceProvider.GetParent("ABC", 3));
        }

        [TestMethod]
        public void TestParentWithDepthBoundaryAPI()
        {
            NodeServiceProvider nodeServiceProvider = new NodeServiceProvider();

            Assert.IsTrue(nodeServiceProvider.GetParent("1VRDFB", 30).ChildNodes.Count == 10);
        }
    }
}
