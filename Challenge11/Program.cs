using Challenge11;

var input = await File.ReadAllLinesAsync("./TestInput.txt");
var monkeyDefinitions = input.Chunk(7);
var monkeys = monkeyDefinitions.Select(def => new Monkey(def.ToList(), false)).ToList();
for (var round = 0; round < 1000; round++)
{
    foreach (var monkey in monkeys)
    {
        monkey.ProcessRound(monkeys);
    }

    if (round % 50 == 0) Console.WriteLine($"Round {round}");
}

var topTwoActiveMonkeys = monkeys.OrderByDescending(m => m.InspectionCount).Take(2).ToList();
var monkeyBusiness = topTwoActiveMonkeys[0].InspectionCount * topTwoActiveMonkeys[1].InspectionCount;
Console.WriteLine($"Top two monkeys' activities = {monkeyBusiness}");