using System;


public class Collection
{
    /// <summary>
    /// List for storing coloction values
    /// </summary>
	public List<int> Items;
    /// <summary>
    /// Constructor for Collection object. it safley transforms string to ints, deletes duplicates, and enforces 0:100 rule.
    /// </summary>
    /// <param name="Line"></param>
	public Collection(string Line)
	{
        List<string> Strings = new List<string>(Line.Split(" "));

        List<int> Ints = Strings
            .Where(s => int.TryParse(s, out _)) //keep strings that are valid ints
            .Select(s => int.Parse(s)) // Transforms strings into ints
            .Where(s => s < 100 && s > 0) // removes all ints out of range
            .Distinct()  // Removes all duplicates
            .ToList(); // saves to new list
            
        Items = Ints;
    }

}
