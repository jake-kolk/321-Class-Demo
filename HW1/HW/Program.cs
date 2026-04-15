using System;
//using Collection;
//using BST;



class Program
{
/// <summary>
/// This runs the entire program
/// - Gets collection
/// - Creates collection object
/// - Creates BST
/// - Adds collection items to BST
/// - Calculates and displays BST stats
/// </summary>
/// <returns></returns>
	static int Main()
	{
		string CollectionInput;

        System.Console.WriteLine("Enter a collections of numbers in range [0:100], seperated by spaces:");

		CollectionInput = Console.ReadLine();
		Collection collection = new Collection(CollectionInput);

		BST Bst = new BST();
		BSTNode NewNode;
		
		for(int i = 0; i < collection.Items.Count; i++)
		{
			NewNode = new BSTNode(collection.Items[i]);
			Bst.Insert(NewNode);
		}

		int MinimumBSTDepth = (int)Math.Ceiling(Math.Log2(Bst.Size + 1)) - 1;
		if (MinimumBSTDepth < 0) MinimumBSTDepth = 0; //check for 0 size

		Bst.PrintTraverse();

		System.Console.WriteLine("Tree Statistics\n" +
			"  Number of nodes: " + Bst.Size + "\n" +
			"  Number of levels: " + Bst.NumLevels + "\n" +
			"  Minimum number of levels that a tree with " + Bst.Size + " nodes could have = " + MinimumBSTDepth + "\n",
			"Done"
			);
        return 0;
	}
}
