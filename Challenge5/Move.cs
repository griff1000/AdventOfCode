namespace Challenge5;

internal class Move
{
    private int NumberToMove { get; }
    private int SourceStackIndex { get; }
    private int DestinationStackIndex { get; }

    internal void ApplyMoveOperations(IList<CrateStack> stacks)
    {
        var removedCrates = stacks[SourceStackIndex].RemoveCrates(NumberToMove);
        stacks[DestinationStackIndex].AddCrates(removedCrates);
    }

    internal Move(string input)
    {
        var elements = input.Split(' ');
        NumberToMove = Convert.ToInt32(elements[1]);
        SourceStackIndex = Convert.ToInt32(elements[3]) - 1; // 0 based index
        DestinationStackIndex = Convert.ToInt32(elements[5]) - 1; // 0 based index
    }
}