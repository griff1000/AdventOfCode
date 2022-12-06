namespace Challenge4.ThirdImplementation
{
    internal sealed class AssignmentWithSystemRanges
    {
        private Range FirstElfRange { get; }
        private Range SecondElfRange { get; }

        internal bool IsOverlap => DoRangesOverlap();

        internal bool OneContainedInOther => IsOneContainedInOther();

        public AssignmentWithSystemRanges(string input)
        {
            var ranges = input.Split('-',',').Select(int.Parse).ToArray();
            FirstElfRange = ranges[0]..ranges[1];
            SecondElfRange = ranges[2]..ranges[3];
        }

        private bool DoRangesOverlap()
        {
            return FirstElfRange.End.Value >= SecondElfRange.Start.Value && FirstElfRange.Start.Value <= SecondElfRange.End.Value;
        }

        private bool IsOneContainedInOther()
        {
            if (FirstElfRange.Start.Value >= SecondElfRange.Start.Value && FirstElfRange.End.Value <= SecondElfRange.End.Value) return true;
            return SecondElfRange.Start.Value >= FirstElfRange.Start.Value && SecondElfRange.End.Value <= FirstElfRange.End.Value;
        }
    }
}
