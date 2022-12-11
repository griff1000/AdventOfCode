namespace Challenge11
{
    internal class Test
    {
        private long Operand { get; }
        private int TrueTarget { get; }
        private int FalseTarget { get; }

        internal Test(IEnumerable<string> test)
        {
            var testDefs = test.ToList();
            Operand = int.Parse(testDefs[0].Split(' ')[^1]);
            TrueTarget = int.Parse(testDefs[1].Split(" ")[^1]);
            FalseTarget = int.Parse(testDefs[2].Split(" ")[^1]);
        }

        internal int FindTarget(long worryLevel)
        {
            var remainder = worryLevel % Operand;
            return remainder == 0 ? TrueTarget : FalseTarget;
        }
    }
}
