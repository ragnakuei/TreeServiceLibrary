using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TreeServiceLibrary;

namespace TreeServiceLibraryTests
{
    public class FloatTreeRootNodeServiceTests
    {
        [Test]
        public void 一個頂節點一個子節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 2);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 2 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 個頂節點一個子節點一個子節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 2);
            treeService.Insert(2, 3);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 2, 3 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 個頂節點一個子節點一個子節點一個子節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 2);
            treeService.Insert(2, 3);
            treeService.Insert(3, 4);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 2, 3, 4 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 二個頂節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 2);
            treeService.Insert(3, 4);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 2 },
                               new() { 3, 4 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 二個頂節點二個子節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 2);
            treeService.Insert(2, 3);
            treeService.Insert(4, 5);
            treeService.Insert(5, 6);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 2, 3 },
                               new() { 4, 5, 6 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 二個根節點結合成一個子節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 0);
            treeService.Insert(2, 0);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 0 },
                               new() { 2, 0 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 二個根節點一個子節點二個子節點()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 0);
            treeService.Insert(2, 0);
            treeService.Insert(0, 3);
            treeService.Insert(0, 4);


            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 1, 0, 3 },
                               new() { 1, 0, 4 },
                               new() { 2, 0, 3 },
                               new() { 2, 0, 4 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void LeetCode210()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 0);
            treeService.Insert(2, 0);
            treeService.Insert(3, 1);
            treeService.Insert(3, 2);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 3, 1, 0 },
                               new() { 3, 2, 0 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 各端點深度不同()
        {
            var treeService = new TreeService<int>();
            treeService.Insert(1, 0);
            treeService.Insert(2, 0);
            treeService.Insert(3, 1);
            treeService.Insert(3, 2);
            treeService.Insert(4, 5);
            treeService.Insert(1, 4);

            var target = new FloatTreeRootNodeService<int>();
            var actual = target.Float(treeService.RootNodes);

            var expected = new List<List<int>>
                           {
                               new() { 3, 1, 0 },
                               new() { 3, 1, 4, 5 },
                               new() { 3, 2, 0 },
                           };
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
