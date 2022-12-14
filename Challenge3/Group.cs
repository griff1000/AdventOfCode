namespace Challenge3
{
    internal class Group
    {
        private Rucksack[] Rucksacks { get; }
        private char Badge => Rucksacks[0].TotalContents
                                .Intersect(Rucksacks[1].TotalContents
                                .Intersect(Rucksacks[2].TotalContents)).Single();
        internal int BadgePriority => Rucksack.Priority(Badge);

        internal Group(Rucksack[] rucksacks)
        {
            if (rucksacks.Length != 3) throw new ArgumentException("Invalid number of rucksacks", nameof(rucksacks));
            Rucksacks = rucksacks;
        }
    }
}
