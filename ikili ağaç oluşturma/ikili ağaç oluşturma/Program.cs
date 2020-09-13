using System;
class TreeNode
{
    // automatic property LeftNode
    public TreeNode LeftNode { get; set; }
    public int Data { get; private set; }
    public TreeNode RightNode { get; set; }
    public TreeNode(int nodeData)
    {
        Data = nodeData;
    }
    // insert TreeNode into Tree that contains nodes;
    // ignore duplicate values
    public void Insert(int insertValue)
    {
        if (insertValue < Data) // insert in left subtree
        {
            // insert new TreeNode
            if (LeftNode == null)
            {
                LeftNode = new TreeNode(insertValue);
            }
            else // continue traversing left subtree
            {
                LeftNode.Insert(insertValue);
            }
        }
        else if (insertValue > Data) // insert in right subtree
        {
            // insert new TreeNode
            if (RightNode == null)
            {
                RightNode = new TreeNode(insertValue);
            }
            else // continue traversing right subtree
            {
                RightNode.Insert(insertValue);
            }
        }
    }
}
public class Tree
{
    private TreeNode root;
    public void InsertNode(int insertValue)
    {
        if (root == null)
        {
            root = new TreeNode(insertValue);
        }
        else
        {
            root.Insert(insertValue);
        }
    }
    public void PreorderTraversal()
    {
        PreorderHelper(root);
    }
    private void PreorderHelper(TreeNode node)
    {
        if (node != null)
        {
            Console.Write($"{node.Data} ");
            PreorderHelper(node.LeftNode);
            PreorderHelper(node.RightNode);
        }
    }
    public void InorderTraversal()
    {
        InorderHelper(root);
    }
    private void InorderHelper(TreeNode node)
    {
        if (node != null)
        {
            InorderHelper(node.LeftNode);
            Console.Write($"{node.Data} ");
            InorderHelper(node.RightNode);
        }
    }
    public void PostorderTraversal()
    {
        PostorderHelper(root);
    }
    private void PostorderHelper(TreeNode node)
    {
        if (node != null)
        {
            PostorderHelper(node.LeftNode);
            PostorderHelper(node.RightNode);
            Console.Write($"{node.Data} ");
        }
    }

}
class TreeTest
{
    static void Main()
    {
        Tree tree = new Tree();
        int insertValue;
        Console.WriteLine("Inserting values: ");
        Random random = new Random();
        for (var i = 1; i <= 10; i++)
        {
            insertValue = random.Next(100);
            Console.Write($"{insertValue} ");
            tree.InsertNode(insertValue);
        }
        Console.WriteLine("\n\nPreorder traversal");
        tree.PreorderTraversal();
        Console.WriteLine("\n\nInorder traversal");
        tree.InorderTraversal();
        Console.WriteLine("\n\nPostorder traversal");
        tree.PostorderTraversal();
        Console.ReadLine();
    }
}