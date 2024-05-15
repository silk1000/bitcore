using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Dynamic;

class TreeBin
{
	public int count { get; private set; }


	public TreeBin(int root)
	{
		new Node(root);
	}

	public class Node
	{
		public Node(int value)
		{
			this.value = value;

			leftValue = null;
			rightValue = null;
		}
		public int value { get; set; }
		public Node leftValue {get; set; }
		public Node rightValue {get; set; }

        public void Add(int integer, Node node) 
			=> TreeBin.Add(integer, node);
    }

	public static void Add(int integer,Node node)
	{
		if (node == null)
		{
			node = new Node(integer);
		}
		if (integer >= node.value)
		{
			node.rightValue.Add(integer,node);
		}
		else if (integer < node.value)
		{
			node.leftValue.Add(integer,node);
		}
	}
}
