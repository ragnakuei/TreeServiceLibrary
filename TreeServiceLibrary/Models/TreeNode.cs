using System.Collections.Generic;

namespace TreeServiceLibrary.Models
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public List<TreeNode<T>> NextNodes { get; init; } = new();

        public List<TreeNode<T>> PrevNodes { get; init; } = new();
    }
}
