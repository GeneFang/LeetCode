namespace Demo.LeetCode.Algorithms.Models
{
    public class TreeNode
    {
        public TreeNode(int val)
        {
            Val = val;
        }

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            Val = val;
            Left = left;
            Right = right;
        }

        public int Val { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }


        public static bool IsSame(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }

            if (t1 == null || t2 == null)
            {
                return false;
            }

            return t1.Val == t2.Val && IsSame(t1.Left, t2.Left) && IsSame(t1.Right, t2.Right);
        }
    }
}