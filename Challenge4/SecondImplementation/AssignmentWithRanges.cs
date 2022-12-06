namespace Challenge4.SecondImplementation
{
    internal sealed class AssignmentWithRanges
    {
        private Range FirstElfRange { get; }
        private Range SecondElfRange { get; }

        internal bool IsOverlap => DoRangesOverlap();

        internal bool OneContainedInOther => IsOneContainedInOther();

        public AssignmentWithRanges(string input)
        {
            var ranges = input.Split('-',',').Select(int.Parse).ToArray();
            FirstElfRange = new Range(ranges[0], ranges[1]);
            SecondElfRange = new Range(ranges[2], ranges[3]);
        }

        private bool DoRangesOverlap()
        {
            return FirstElfRange.Max >= SecondElfRange.Min && FirstElfRange.Min <= SecondElfRange.Max;
        }

        private bool IsOneContainedInOther()
        {
            if (FirstElfRange.Min >= SecondElfRange.Min && FirstElfRange.Max <= SecondElfRange.Max) return true;
            return SecondElfRange.Min >= FirstElfRange.Min && SecondElfRange.Max <= FirstElfRange.Max;
        }
    }
}
