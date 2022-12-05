namespace Challenge5
{
    internal class CrateStack
    {
        internal Stack<Crate> Crates { get; }

        internal CrateStack(Stack<Crate> crates)
        {
            Crates = crates;
        }
    }
}
