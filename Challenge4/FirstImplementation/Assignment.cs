namespace Challenge4.FirstImplementation
{
    internal sealed class Assignment
    {
        private IEnumerable<int> FirstElfSections { get; }
        private IEnumerable<int> SecondElfSections { get; }

        internal bool IsOverlap => FirstElfSections.Any(f => SecondElfSections.Contains(f));
        internal bool OneContainedInOther =>
            SecondElfSections.All(s => FirstElfSections.Contains(s)) ||
            FirstElfSections.All(f => SecondElfSections.Contains(f));

        internal Assignment(string input)
        {
            var ranges = input.Split('-', ',').Select(int.Parse).ToArray();

            FirstElfSections = Enumerable.Range(ranges[0], ranges[1] - ranges[0] + 1);
            SecondElfSections = Enumerable.Range(ranges[2], ranges[3] - ranges[2] + 1);
        }
    }
}
