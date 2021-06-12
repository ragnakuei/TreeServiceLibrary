using System.Collections.Generic;
using TreeServiceLibrary.Models;

namespace TreeServiceLibrary
{
    internal interface IBuildTreeService<T>
    {
        /// <summary>
        /// 最底部所有節點
        /// </summary>
        List<TreeNode<T>> RootNodes { get; }

        void Insert(T current, T next);
    }
}
