using System.Runtime.Serialization;

class TreeBin
{
    public int count { get; private set; }
    public TreeBin(Node root)
    {
        count = 0;
    }
    public class Node
    {
        public int floor { get; private set; }
        int value;
        Node? left { get; set; }
        Node? right { get; set; }

        public Node(int val)
        {
            value = val;
            left = null;
            right = null;
        }
    }

    Node root = new Node(0);
    public void addRoot(int val)
    {
        Node root = new Node(val);
    }

    public void add(int val, Node root)
    {
        if (root.value == null)
        {
            root.value = val;
        }
        else if (root.value >= val)
        {
            if (root.left == null)
            {
                root.left = new Node(val);
                count++;
            }
            else
            {
                add(val, root.left);
            }
        }
        else if (root.value < val)
        {
            if (root.right == null)
            {
                root.right = new Node(val);
                count++;
            }
            else
            {
                add(val, root.right);
            }
        }
    }

    public void find()
    {

    }


}
