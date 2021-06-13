using System;
using System.Collections.Generic;
using System.Linq;
using TreeServiceLibrary.Models;

namespace TreeServiceLibrary
{
    public class FloatTreeRootNodeService<T>
    {
        private Stack<T> _currentResult;

        private List<List<T>> Result { get; set; } = new();

        public List<List<T>> Float(List<TreeNode<T>> rootNodes)
        {
            foreach (var treeNode in rootNodes)
            {
                _currentResult = new();

                ExtractChildNodes(treeNode);
            }

            return Result;
        }

        private void ExtractChildNodes(TreeNode<T> treeNode)
        {
            _currentResult.Push(treeNode.Value);

            if (treeNode?.NextNodes.Count != 0)
            {
                foreach (var nextNode in treeNode?.NextNodes)
                {
                    ExtractChildNodes(nextNode);
                }

                _currentResult.Pop();
            }
            else
            {
                Result.Add(_currentResult.ToList());

                _currentResult.Pop();
            }
        }
    }
}
