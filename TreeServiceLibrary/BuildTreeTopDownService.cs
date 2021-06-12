using System.Collections.Generic;
using System.Linq;
using TreeServiceLibrary.Models;

namespace TreeServiceLibrary
{
    /// <summary>
    /// 樹頂端在最上面
    /// </summary>
    internal class BuildTreeTopDownService<T> : IBuildTreeService<T>
    {
        /// <summary>
        /// 攤平的所有節點
        /// </summary>
        private Dictionary<T, TreeNode<T>> _nodes = new();

        /// <summary>
        /// 最上面所有節點
        /// </summary>
        private Dictionary<T, TreeNode<T>> _topNodes = new();

        /// <summary>
        /// 最上面所有節點
        /// </summary>
        public List<TreeNode<T>> RootNodes => _topNodes.Values.ToList();

        public void Insert(T current, T lower)
        {
            var isInsertTop = _nodes.ContainsKey(current)    == false
                           && _topNodes.ContainsKey(current) == false;

            var currentNode = Insert(current);
            var lowerNode   = Insert(lower);
            currentNode.Lower = lowerNode;

            if (isInsertTop)
            {
                if (_topNodes.GetValueOrDefault(lower) is TreeNode<T> topNode)
                {
                    // 更換 topNode

                    var newBottomNode = currentNode;
                    _topNodes.Add(newBottomNode.Value, newBottomNode);
                    _topNodes.Remove(lower);
                }
                else
                {
                    _topNodes.Add(currentNode.Value, currentNode);
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
