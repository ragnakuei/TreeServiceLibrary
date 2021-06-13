using System.Linq;
using NUnit.Framework;
using TreeServiceLibrary;

namespace TreeServiceLibraryTests
{
    public class TreeServiceTests
    {
        [Test]
        public void 一個頂節點一個子節點()
        {
            var target = new TreeService<int>();

            target.Insert(1, 2);

            var actual = target.RootNodes.FirstOrDefault();

            Assert.AreEqual(actual.Value,              1);
            Assert.AreEqual(actual.NextNodes[0].Value, 2);
        }

        [Test]
        public void 照順序_一個頂節點一個子節點一個子節點()
        {
            var target = new TreeService<int>();

            target.Insert(1, 2);
            target.Insert(2, 3);

            var actual = target.RootNodes[0];

            Assert.AreEqual(actual.Value,                           1);
            Assert.AreEqual(actual.NextNodes[0].Value,              2);
            Assert.AreEqual(actual.NextNodes[0].NextNodes[0].Value, 3);
        }

        [Test]
        public void 不照順序_一個頂節點一個子節點一個子節點()
        {
            var target = new TreeService<int>();

            target.Insert(2, 3);
            target.Insert(1, 2);

            var actual = target.RootNodes[0];

            Assert.AreEqual(actual.Value,                           1);
            Assert.AreEqual(actual.NextNodes[0].Value,              2);
            Assert.AreEqual(actual.NextNodes[0].NextNodes[0].Value, 3);
        }

        [Test]
        public void 二個頂節點()
        {
            var target = new TreeService<int>();

            target.Insert(1, 2);
            target.Insert(3, 4);

            var actual = target.RootNodes;

            Assert.AreEqual(actual[0].Value,              1);
            Assert.AreEqual(actual[0].NextNodes[0].Value, 2);
            Assert.AreEqual(actual[1].Value,              3);
            Assert.AreEqual(actual[1].NextNodes[0].Value, 4);
        }

        [Test]
        public void 照順序_二個頂節點二個子節點()
        {
            var target = new TreeService<int>();

            target.Insert(1, 2);
            target.Insert(2, 3);

            target.Insert(4, 5);
            target.Insert(5, 6);

            var actual = target.RootNodes;

            Assert.AreEqual(actual[0].Value,                           1);
            Assert.AreEqual(actual[0].NextNodes[0].Value,              2);
            Assert.AreEqual(actual[0].NextNodes[0].NextNodes[0].Value, 3);
            Assert.AreEqual(actual[1].Value,                           4);
            Assert.AreEqual(actual[1].NextNodes[0].Value,              5);
            Assert.AreEqual(actual[1].NextNodes[0].NextNodes[0].Value, 6);
        }

        [Test]
        public void 不照順序_二個頂節點二個子節點()
        {
            var target = new TreeService<int>();

            target.Insert(5, 6);
            target.Insert(2, 3);

            target.Insert(1, 2);
            target.Insert(4, 5);

            var actual = target.RootNodes;

            Assert.AreEqual(actual[0].Value,                           1);
            Assert.AreEqual(actual[0].NextNodes[0].Value,              2);
            Assert.AreEqual(actual[0].NextNodes[0].NextNodes[0].Value, 3);
            Assert.AreEqual(actual[1].Value,                           4);
            Assert.AreEqual(actual[1].NextNodes[0].Value,              5);
            Assert.AreEqual(actual[1].NextNodes[0].NextNodes[0].Value, 6);
        }

        [Test]
        public void LeetCode210()
        {
            var target = new TreeService<int>();

            target.Insert(1, 0);
            target.Insert(2, 0);

            target.Insert(3, 1);
            target.Insert(3, 2);

            var actual = target.RootNodes;

            Assert.AreEqual(actual[0].Value,                           3);
            Assert.AreEqual(actual[0].NextNodes[0].Value,              1);
            Assert.AreEqual(actual[0].NextNodes[0].NextNodes[0].Value, 0);
            Assert.AreEqual(actual[0].NextNodes[1].Value,              2);
            Assert.AreEqual(actual[0].NextNodes[1].NextNodes[0].Value, 0);
        }

        [Test]
        public void 不照順序_先給定二個根節點_再給定中間節點()
        {
            var target = new TreeService<int>();

            target.Insert(1, 2);
            target.Insert(3, 4);
            target.Insert(2, 3);

            var actual = target.RootNodes;

            Assert.AreEqual(actual[0].Value,                                        1);
            Assert.AreEqual(actual[0].NextNodes[0].Value,                           2);
            Assert.AreEqual(actual[0].NextNodes[0].NextNodes[0].Value,              3);
            Assert.AreEqual(actual[0].NextNodes[0].NextNodes[0].NextNodes[0].Value, 4);
        }
    }
}
