namespace Challenge11
{
    using System.Numerics;

    internal class Monkey
    {
        private Queue<BigInteger> Items { get; }
        private Operation Operation { get; }
        private Test Test { get; }
        internal long InspectionCount { get; private set; }
        private bool ApplyRelief { get; }

        internal Monkey(List<string> monkeyDefinition, bool applyRelief)
        {
            Items = GetInitialItems(monkeyDefinition[1]);
            Operation = new Operation(monkeyDefinition[2]);
            Test = new Test(monkeyDefinition.GetRange(3, 3));
            ApplyRelief = applyRelief;
        }

        private Queue<BigInteger> GetInitialItems(string startingItems)
        {
            var items = startingItems.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var queue = new Queue<BigInteger>();
            items.Where((_, index) => index >= 2).Select(i => new BigInteger(int.Parse(i))).ToList().ForEach(queue.Enqueue);
            return queue;
        }

        internal void ProcessRound(List<Monkey> monkeyList)
        {
            while (Items.Count > 0)
            {
                InspectionCount++;
                var item = Items.Dequeue();
                item = Operation.NewWorry(item);
                if (ApplyRelief) item /= 3; // relief
                monkeyList[Test.FindTarget(item)].Items.Enqueue(item);
            }
        }
    }
}
