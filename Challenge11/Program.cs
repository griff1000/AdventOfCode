using Challenge11;

var input = await File.ReadAllLinesAsync("./Input.txt");
var monkeyDefinitions = input.Chunk(7);
// For problem 1, set applyRelief in the Monkey constructor to true and set round < 20
var monkeys = monkeyDefinitions.Select(def => new Monkey(def.ToList(), false)).ToList();
for (var round = 0; round < 10000; round++)
{
    foreach (var monkey in monkeys)
    {
        monkey.ProcessRound(monkeys);
    }
}

var topTwoActiveMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2).ToList();
var monkeyBusiness = topTwoActiveMonkeys[0].InspectionCount * topTwoActiveMonkeys[1].InspectionCount;
Console.WriteLine($"Top two monkeys' activities = {monkeyBusiness}");