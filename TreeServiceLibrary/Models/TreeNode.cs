namespace TreeServiceLibrary.Models
{
    public class TreeNode<T>
    {
        public T Value { get; set; }

        public TreeNode<T> Upper { get; set; }

        public TreeNode<T> Lower { get; set; }
    }
}
