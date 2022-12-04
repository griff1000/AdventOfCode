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
            var ranges = input.Split('-',',');
            FirstElfRange = int.Parse(ranges[0])..int.Parse(ranges[1]);
            SecondElfRange = int.Parse(ranges[2])..int.Parse(ranges[3]);
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
