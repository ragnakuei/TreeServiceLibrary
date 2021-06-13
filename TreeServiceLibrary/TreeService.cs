using System;
using System.Collections.Generic;
using System.Linq;
using TreeServiceLibrary.Models;

namespace TreeServiceLibrary
{
    public class TreeService<T>
    {
        /// <summary>
        /// 最底部所有節點
        /// </summary>
        public List<TreeNode<T>> RootNodes => _nodes.Values.Where(n => n.PrevNodes.Count == 0).ToList();

        public List<TreeNode<T>> EndNodes => _nodes.Values.Where(n => n.NextNodes.Count == 0).ToList();

        public void Insert(T current, T next)
        {
            var currentNode = Insert(current);
            var upperNode   = Insert(next);

            currentNode.NextNodes.Add(upperNode);
            upperNode.PrevNodes.Add(currentNode);
        }

        /// <summary>
        /// 攤平的所有節點
        /// </summary>
        private Dictionary<T, TreeNode<T>> _nodes = new();

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
