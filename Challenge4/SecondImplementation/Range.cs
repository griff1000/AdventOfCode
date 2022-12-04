namespace Challenge4.SecondImplementation
{
    internal sealed class Range
    {
        internal int Min { get; }
        internal int Max { get; }

        internal Range(string min, string max)
        {
            Min = int.Parse(min); Max = int.Parse(max);
        }
    }
}
