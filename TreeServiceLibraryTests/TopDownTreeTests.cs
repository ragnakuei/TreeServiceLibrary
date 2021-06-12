using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TreeServiceLibrary;
using TreeServiceLibrary.Models;

namespace TreeServiceLibraryTests
{
    public class TopDownTreeTests
    {
        [Test]
        public void 一個頂節點一個子節點()
        {
            var target = new TreeService<int>();
            target.Direction = TreeDirection.TopDown;

            target.Insert(1, 2);

            var actual = target.RootNodes;

            var expected = new List<TreeNode<int>>
                           {
                               new TreeNode<int>
                               {
                                   Value = 1,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 2,
                                               Lower = null,
                                           }
                               }
                           };

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 照順序_一個頂節點一個子節點一個子節點()
        {
            var target = new TreeService<int>();
            target.Direction = TreeDirection.TopDown;

            target.Insert(1, 2);
            target.Insert(2, 3);

            var actual = target.RootNodes;

            var expected = new List<TreeNode<int>>
                           {
                               new TreeNode<int>
                               {
                                   Value = 1,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 2,
                                               Lower = new TreeNode<int>
                                                       {
                                                           Value = 3,
                                                           Lower = null,
                                                       },
                                           }
                               }
                           };

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 不照順序_一個頂節點一個子節點一個子節點()
        {
            var target = new TreeService<int>();
            target.Direction = TreeDirection.TopDown;

            target.Insert(2, 3);
            target.Insert(1, 2);

            var actual = target.RootNodes;

            var expected = new List<TreeNode<int>>
                           {
                               new TreeNode<int>
                               {
                                   Value = 1,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 2,
                                               Lower = new TreeNode<int>
                                                       {
                                                           Value = 3,
                                                           Lower = null,
                                                       },
                                           }
                               }
                           };

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 二個頂節點()
        {
            var target = new TreeService<int>();
            target.Direction = TreeDirection.TopDown;

            target.Insert(1, 2);
            target.Insert(3, 4);

            var actual = target.RootNodes;

            var expected = new List<TreeNode<int>>
                           {
                               new TreeNode<int>
                               {
                                   Value = 1,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 2,
                                               Lower = null,
                                           }
                               },
                               new TreeNode<int>
                               {
                                   Value = 3,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 4,
                                               Lower = null,
                                           }
                               }
                           };

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 照順序_二個頂節點二個子節點()
        {
            var target = new TreeService<int>();
            target.Direction = TreeDirection.TopDown;

            target.Insert(1, 2);
            target.Insert(2, 3);

            target.Insert(4, 5);
            target.Insert(5, 6);

            var actual = target.RootNodes;

            var expected = new List<TreeNode<int>>
                           {
                               new TreeNode<int>
                               {
                                   Value = 1,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 2,
                                               Lower = new TreeNode<int>
                                                       {
                                                           Value = 3,
                                                           Lower = null,
                                                       },
                                           }
                               },
                               new TreeNode<int>
                               {
                                   Value = 4,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 5,
                                               Lower = new TreeNode<int>
                                                       {
                                                           Value = 6,
                                                           Lower = null,
                                                       },
                                           }
                               },
                           };

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void 不照順序_二個頂節點二個子節點()
        {
            var target = new TreeService<int>();
            target.Direction = TreeDirection.TopDown;

            target.Insert(5, 6);
            target.Insert(2, 3);

            target.Insert(1, 2);
            target.Insert(4, 5);

            var actual = target.RootNodes;

            var expected = new List<TreeNode<int>>
                           {
                               new TreeNode<int>
                               {
                                   Value = 1,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 2,
                                               Lower = new TreeNode<int>
                                                       {
                                                           Value = 3,
                                                           Lower = null,
                                                       },
                                           }
                               },
                               new TreeNode<int>
                               {
                                   Value = 4,
                                   Lower = new TreeNode<int>
                                           {
                                               Value = 5,
                                               Lower = new TreeNode<int>
                                                       {
                                                           Value = 6,
                                                           Lower = null,
                                                       },
                                           }
                               },
                           };

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
