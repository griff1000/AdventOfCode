namespace Challenge3
{
    internal class Rucksack
    {
        private IEnumerable<char> Compartment1 { get; }
        private IEnumerable<char> Compartment2 { get; }
        internal IEnumerable<char> TotalContents => Compartment1.Concat(Compartment2);
        private char CommonItem => Compartment1.Intersect(Compartment2).Single();
        internal int CommonItemPriority => Priority(CommonItem);

        internal Rucksack(string contents)
        {
            Compartment1 = contents[..(contents.Length / 2)];
            Compartment2 = contents[(contents.Length / 2)..];
        }

        internal static int Priority(char value)
        {
            return value >= 'a' ? value - 'a' + 1 : value - 'A' + 27;
        }
    }
}
