namespace Challenge5
{
    internal class Move
    {
        internal int NumberToMove { get; }
        internal int SourceColumn { get; }
        internal int DestinationColumn { get; }

        internal Move(string input)
        {
            var elements = input.Split(' ');
            NumberToMove = Convert.ToInt32(elements[1]);
            SourceColumn = Convert.ToInt32(elements[3]);
            DestinationColumn = Convert.ToInt32(elements[5]);
        }
    }
}
