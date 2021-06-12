using System;
using System.Collections.Generic;
using TreeServiceLibrary.Models;

namespace TreeServiceLibrary
{
    public class TreeService<T>
    {
        private TreeDirection        _direction;
        private IBuildTreeService<T> _service;

        public TreeDirection Direction
        {
            get => _direction;
            set
            {
                _direction = value;

                _service = _direction switch
                           {
                               TreeDirection.TopDown  => new BuildTreeTopDownService<T>(),
                               TreeDirection.BottomUp => new BuildTreeBottomUpService<T>(),
                               _                      => throw new ArgumentOutOfRangeException(),
                           };
            }
        }

        /// <summary>
        /// 根節點
        /// </summary>
        public List<TreeNode<T>> RootNodes => _service.RootNodes;

        public void Insert(T current, T next)
        {
            _service.Insert(current, next);
        }
    }
}
