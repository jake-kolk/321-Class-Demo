using System;

public class BST
{
	/// <summary>
	/// Stats for BST
	/// </summary>
	public int Size = 0;
	public int NumLevels = 0;
	private BSTNode pHead;

	/// <summary>
	/// Constructor
	/// </summary>
	
	public BST()
	{
		Size = 0;
	}
	/// <summary>
	/// Adjusts size and level attributes each time a node is inserted
	/// </summary>
	/// <param name="Level"></param>
	private void AdjustLevelandSize(int Level)
	{
		if (Level > NumLevels){this.NumLevels = Level;}
		Size++;
	}
    /// <summary>
    /// This traverses the existing BST, modifies the pRight or pLeft to include a reference to int inserted node. Also calls 
    /// AdjustLevelandSize to keep BST stats accurate.
    /// /// </summary>
    /// <param name="Inserted"></param>
    public void Insert(BSTNode Inserted)
	{
		if (Inserted == null) return;

		if (Size == 0)
		{
			pHead = Inserted;
			this.Size = 1;
            return;
		}
		else
		{
            BSTNode CurNode = pHead;
            for(int i = 1; ;i++) {
				if (CurNode.Value < Inserted.Value)
				{
					if (CurNode.pRight == null) // Insert as right child
					{
						CurNode.pRight = Inserted;
						AdjustLevelandSize(i);
						return;
					}
					else // Descend right
					{
						CurNode = CurNode.pRight;
						continue;
					}
				}
				else if (CurNode.Value > Inserted.Value) // Insert as left child
				{
					if (CurNode.pLeft == null)
					{
						CurNode.pLeft = Inserted;
                        AdjustLevelandSize(i);
                        return;
					}
					else // Descend left
					{
						CurNode = CurNode.pLeft;
						continue;
					}
				}
				else if (CurNode.Value == Inserted.Value) return;
			}
		}
	}
	
	/// <summary>
	/// Print wrapper for recursive traverse
	/// </summary>
	public void PrintTraverse()
	{
		Console.Write("BST: ");
		Traverse(this.pHead);
	}
	/// <summary>
	/// Recursivle searches BST from left to right
	/// </summary>
	/// <param name="node"></param>
	public void Traverse(BSTNode node)
	{
		if (node == null) return;
		else
		{
			Console.Write(" " + node.Value + " ");
		}
		Traverse(node.pLeft);
		Traverse(node.pRight);
		return;
	}
}
