namespace Challenge5;

internal class CrateStack
{
    internal Stack<Crate> Crates { get; }

    internal void AddCrate(Crate crate)
    {
        Crates.Push(crate);
    }
    internal void AddCrates(IEnumerable<Crate> cratesToAdd)
    {
        // foreach (var crate in cratesToAdd.Reverse()) // Easiest answer to part 2
        foreach (var crate in cratesToAdd) 
        {
            AddCrate(crate);
        }
    }

    internal IEnumerable<Crate> RemoveCrates(int numberToRemove)
    {
        var cratesRemoved = new List<Crate>();
        for (var i = 0; i < numberToRemove; i++)
        {
            cratesRemoved.Add(Crates.Pop());
        }

        return cratesRemoved;
    }

    internal CrateStack()
    {
        Crates = new Stack<Crate>();
    }
}