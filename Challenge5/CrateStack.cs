namespace Challenge5;

internal class CrateStack
{
    internal Stack<Crate> Crates { get; }

    // Could get away without this method but it provides a seam where we could change the
    // implementation later if we wanted to
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

    internal static List<CrateStack> CreateStacks(int numberOfStacks)
    {
        return new List<CrateStack>(
            Enumerable.Range(1, numberOfStacks).Select(_ => new CrateStack()));
    }
}