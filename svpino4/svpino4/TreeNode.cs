using System.Collections.Generic;

namespace svpino4
{
    class TreeNode<T>
    {
        private readonly List<TreeNode<T>> _leafs;
        public TreeNode(T value)
        {
            Value = value;
            _leafs = new List<TreeNode<T>>();
        }

        public T Value { get; private set; }

        public void AddLeaf(TreeNode<T> leaf)
        {
            _leafs.Add(leaf);
        }

        public TreeNode<T>[] GetLeafs()
        {
            if (_leafs.Count == 0)
            {
                return null;
            }
            return _leafs.ToArray();
        }
    }
}
