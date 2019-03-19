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

            int currentIndex = index * 2 + 1;
            if (currentIndex < values.Length && values[currentIndex] != 0)
            {
                this.left = new TreeNode(values, currentIndex);
            }

            currentIndex = index * 2 + 2;
            if (currentIndex < values.Length && values[currentIndex] != 0)
            {
                this.right = new TreeNode(values, currentIndex);
            }
        }
    }

    class BinaryTreeCousin
    {
        public BinaryTreeCousin()
        {
            int[] nodes = new int[] { 1, 2, 3, 0, 4, 0, 5 };
            TreeNode root = new TreeNode(nodes);

            Console.WriteLine(
                "Test case 0 : " + (IsCousins(root, 4, 5) == true ? "Passed" : "Failed")
            );

            Console.WriteLine(
                "Test case 1 : " + (IsCousins(root, 2, 3) == false ? "Passed" : "Failed")
            );

            Console.ReadLine();
        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            //return WithoutDictionary(root, x, y);
            return WithDictionary(root, x, y);
        }

        #region WithoutDictionary
        private bool WithoutDictionary(TreeNode root, int x, int y)
        {
            bool result = false;

            int xDepth = GetDepth(root, x, 0);
            int yDepth = GetDepth(root, y, 0);

            if (xDepth == yDepth && xDepth != -1)
            {
                if (GetParent(root, x) != GetParent(root, y))
                {
                    result = true;
                }
            }

            return result;
        }

        private int GetParent(TreeNode node, int value)
        {
            if (node.left != null && node.left.val == value)
            {
                return node.val;
            }

            if (node.right != null && node.right.val == value)
            {
                return node.val;
            }

            if (node.left != null)
            {
                int val = GetParent(node.left, value);
                if (val >= 0)
                {
                    return val;
                }
            }

            if (node.right != null)
            {
                int val = GetParent(node.right, value);
                if (val >= 0)
                {
                    return val;
                }
            }

            return -1;
        }

        private int GetDepth(TreeNode node, int value, int depth)
        {
            if (node.val == value) return depth;

            if (node.left != null)
            {
                int val = GetDepth(node.left, value, depth + 1);
                if (val >= 0)
                {
                    return val;
                }
               
            }

            if (node.right != null)
            {
                int val = GetDepth(node.right, value, depth + 1);
                if (val >= 0)
                {
                    return val;
                }
            }

            return -1;
        }
        #endregion WithoutDictionary

        #region WithDictionary
        Dictionary<int, int> depthDict;
        Dictionary<int, TreeNode> parentDict;
        private bool WithDictionary(TreeNode root, int x, int y)
        {
            depthDict = new Dictionary<int, int>();
            parentDict = new Dictionary<int, TreeNode>();
            DepthFirstSearch(root, null);

            return (depthDict[x] == depthDict[y] && parentDict[x] != parentDict[y]);
        }

        private void DepthFirstSearch(TreeNode node, TreeNode parent)
        {
            if (node != null)
            {
                depthDict.Add(node.val, parent == null ? 0 : depthDict[parent.val] + 1);
                parentDict.Add(node.val, parent);

                if (node.left != null) DepthFirstSearch(node.left, node);

                if (node.right != null) DepthFirstSearch(node.right, node);
            }
        }
        #endregion WithDictionary
    }
}
