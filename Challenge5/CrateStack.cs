namespace Challenge5
{
    internal class CrateStack
    {
        internal Stack<Crate> Crates { get; }

        internal void AddCrates(Crate[] cratesToAdd)
        {
            // foreach (var crate in cratesToAdd.Reverse()) // Easiest answer to part 2
            foreach (var crate in cratesToAdd) 
            {
                 Crates.Push(crate);
            }
        }

        internal Crate[] RemoveCrates(int numberToRemove)
        {
            var cratesRemoved = new List<Crate>();
            for (var i = 0; i < numberToRemove; i++)
            {
                cratesRemoved.Add(Crates.Pop());
            }

            return cratesRemoved.ToArray();
        }

        internal CrateStack(Crate[] crates)
        {
            Crates = new Stack<Crate>(crates.Reverse());
        }
    }
}
