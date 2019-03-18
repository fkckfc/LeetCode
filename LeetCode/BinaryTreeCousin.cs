using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TreeNode
    {
        public TreeNode(int[] values) : this(values, 0) { }

        TreeNode(int[] values, int index)
        {
            Load(this, values, index);
        }

        public int val;
        public TreeNode left;
        public TreeNode right;

        void Load(TreeNode tree, int[] values, int index)
        {
            this.val = values[index];
            if (index * 2 + 1 < values.Length)
            {
                this.left = new TreeNode(values, index * 2 + 1);
            }
            if (index * 2 + 2 < values.Length)
            {
                this.right = new TreeNode(values, index * 2 + 2);
            }
        }
    }

    class BinaryTreeCousin
    {
        public BinaryTreeCousin()
        {
            int[] nodes = new int[] { 1, 2, 3, 4, 5 };

            TreeNode root = new TreeNode(nodes);

            Console.WriteLine(GetDepth(root, 10, 0));
            Console.ReadLine();
        }

        private int GetDepth(TreeNode root, int node, int depth)
        {
            if (root.val == node) return depth;

            if (root.left != null)
            {
                int val = GetDepth(root.left, node, depth + 1);
                if (val >= 0)
                {
                    return val;
                }
               
            }

            if (root.right != null)
            {
                int val = GetDepth(root.right, node, depth + 1);
                if (val >= 0)
                {
                    return val;
                }
            }

            return -1;
        }
    }
}
