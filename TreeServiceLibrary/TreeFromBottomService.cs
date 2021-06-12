using System.Collections.Generic;
using System.Linq;
using TreeServiceLibrary.Models;

namespace TreeServiceLibrary
{
    /// <summary>
    /// 樹頂端在最下面
    /// </summary>
    internal class BuildTreeBottomUpService<T> : IBuildTreeService<T>
    {
        /// <summary>
        /// 攤平的所有節點
        /// </summary>
        private Dictionary<T, TreeNode<T>> _nodes = new();

        /// <summary>
        /// 最底部所有節點
        /// </summary>
        private Dictionary<T, TreeNode<T>> _bottomNodes = new();

        /// <summary>
        /// 最底部所有節點
        /// </summary>
        public List<TreeNode<T>> RootNodes => _bottomNodes.Values.ToList();

        public void Insert(T current, T upper)
        {
            var isInsertBottom = _nodes.ContainsKey(current)       == false
                              && _bottomNodes.ContainsKey(current) == false;

            var currentNode = Insert(current);
            var upperNode   = Insert(upper);
            currentNode.Upper = upperNode;

            if (isInsertBottom)
            {
                if (_bottomNodes.GetValueOrDefault(upper) is TreeNode<T> bottomNode)
                {
                    // 更換 bottomNode

                    var newBottomNode = currentNode;
                    _bottomNodes.Add(newBottomNode.Value, newBottomNode);
                    _bottomNodes.Remove(upper);
                }
                else
                {
                    _bottomNodes.Add(currentNode.Value, currentNode);
                }
            }
        }

        private TreeNode<T> Insert(T v)
        {
            if (_nodes.GetValueOrDefault(v) is TreeNode<T> node)
            {
                return node;
            }

            var newNode = new TreeNode<T> { Value = v };
            _nodes.Add(newNode.Value, newNode);

            return newNode;
        }
    }
}
