using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// Implement a MyCalendar class to store your events. A new event can be added if adding the event will not cause a double booking.
    ///
    /// Your class will have the method, book(int start, int end). 
    /// Formally, this represents a booking on the half open interval [start, end), the range of real numbers x such that start <= x < end.
    /// A double booking happens when two events have some non-empty intersection (ie., there is some time that is common to both events.)

    /// For each call to the method MyCalendar.book, return true if the event can be added to the calendar successfully without causing a double booking. 
    /// Otherwise, return false and do not add the event to the calendar. 
    /// Your class will be called like this: MyCalendar cal = new MyCalendar(); MyCalendar.book(start, end)
    /// 
    /// Example 1
    /// MyCalendar();
    ///     MyCalendar.book(10, 20); /// returns true
    ///     MyCalendar.book(15, 25); /// returns false
    ///     MyCalendar.book(20, 30); /// returns true
    ///     Explanation: 
    /// The first event can be booked.  The second can't because time 15 is already booked by another event.
    /// The third event can be booked, as the first event takes every time less than 20, but not including 20.
        
    /// Note:
    /// The number of calls to MyCalendar.book per test case will be at most 1000.
    /// In calls to MyCalendar.book(start, end), start and end are integers in the range [0, 10^9].
    /// </summary>
    public class MyCalendar
    {
        public MyCalendar()
        {
            booking = new List<Calendar>();
        }

        public bool Book(int start, int end)
        {
            //return BruteForce(start, end);
            return BinaryTree(start, end);
        }

        #region BruteForce
        //// <summary>
        //// Unsorted List - Need to iterate the entire list to check for duplicate
        //// </summary>
        //// <param name="start"></param>
        //// <param name="end"></param>
        //// <returns></returns>
        private bool BruteForce(int start, int end)
        {
            foreach (Calendar currentBooking in booking)
            {
                if (start < currentBooking.end &&
                    currentBooking.start < end)
                    return false;
            }

            booking.Add(new Calendar(start, end));
            return true;
        }

        private List<Calendar> booking;

        internal class Calendar
        {
            internal int start;
            internal int end;

            public Calendar(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }
        #endregion BruteForce

        #region BinaryTree
        class TreeNode
        {
            public TreeNode Left;
            public TreeNode Right;
            public int startTime;
            public int endTime;

            public TreeNode(int start, int end)
            {
                this.startTime = start;
                this.endTime = end;
            }
        }

        TreeNode root;
        private bool BinaryTree(int start, int end)
        {
            if (root == null)
            {
                root = new TreeNode(start, end);
                return true;
            }

            return CheckTreeNode(root, start, end);
        }

        private bool CheckTreeNode(TreeNode node, int start, int end)
        {
            if (node.startTime >= end)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode(start, end);
                    return true;
                }
                else
                {
                    return CheckTreeNode(node.Left, start, end);
                }
            }

            if (node.endTime <= start)
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(start, end);
                    return true;
                }
                else
                {
                    return CheckTreeNode(node.Right, start, end);
                }
            }            

            return false;
        }
        #endregion BinaryTree
    }
 /**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
}
