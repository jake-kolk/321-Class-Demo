using System;

public class BSTNode
{
	/// <summary>
	/// Node attributes, pRight, pLeft (child nodes) and the value the node has
	/// </summary>
	public BSTNode pRight = null;
	public BSTNode pLeft = null;
	public int Value;
	public BSTNode(int NewValue)
	{
		this.Value = NewValue;
	}

}
