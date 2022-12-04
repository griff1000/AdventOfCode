namespace Challenge4
{
    internal class Assignment
    {
        private IEnumerable<int> FirstElfSections { get; }
        private IEnumerable<int> SecondElfSections { get;}

        internal bool IsOverlap => FirstElfSections.Any(f => SecondElfSections.Contains(f));
        internal bool OneContainedInOther => 
            SecondElfSections.All(s => FirstElfSections.Contains(s)) || 
            FirstElfSections.All(f => SecondElfSections.Contains(f));

        internal Assignment(string input)
        {
            var ranges = input.Split('-',',');
            FirstElfSections = Enumerable.Range(int.Parse(ranges[0]), int.Parse(ranges[1]) - int.Parse(ranges[0]) + 1);
            SecondElfSections = Enumerable.Range(int.Parse(ranges[2]), int.Parse(ranges[3]) - int.Parse(ranges[2]) + 1);
        }
    }
}
