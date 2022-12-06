namespace Challenge4.SecondImplementation
{
    internal sealed class Range
    {
        internal int Min { get; }
        internal int Max { get; }

        internal Range(int min, int max)
        {
            Min = min; 
            Max = max;
        }
    }
}
