namespace Challenge5;

internal class Move
{
    private int NumberToMove { get; }
    private int SourceStack { get; }
    private int DestinationStack { get; }

    internal void ApplyMoveOperations(List<CrateStack> stacks)
    {
        var removedCrates = stacks[SourceStack].RemoveCrates(NumberToMove);
        stacks[DestinationStack].AddCrates(removedCrates);
    }

    internal Move(string input)
    {
        var elements = input.Split(' ');
        NumberToMove = Convert.ToInt32(elements[1]);
        SourceStack = Convert.ToInt32(elements[3]) - 1; // 0 based index
        DestinationStack = Convert.ToInt32(elements[5]) - 1; // 0 based index
    }
}