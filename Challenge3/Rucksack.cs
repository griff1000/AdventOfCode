namespace Challenge3
{
    internal class Rucksack
    {
        private char[] Compartment1 { get; }
        private char[] Compartment2 { get; }
        internal IEnumerable<char> TotalContents => Compartment1.Concat(Compartment2);
        private char CommonItem => Compartment1.Intersect(Compartment2).Single();
        internal int CommonItemPriority => Priority(CommonItem);

        internal Rucksack(string contents)
        {
            var array = contents.ToCharArray();
            if (array.Length % 2 > 0) throw new ArgumentException("Odd number of elements", nameof(contents));
            Compartment1 = array.Take(array.Length / 2).ToArray();
            Compartment2 = array.Skip(array.Length / 2).ToArray();
        }

        internal static int Priority(char value)
        {
            var charValue = value - 64;
            if (charValue > 32) charValue -= 32;
            else charValue += 26;
            return charValue;
        }
    }
}
