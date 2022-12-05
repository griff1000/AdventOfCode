using Challenge5;

var input = await File.ReadAllLinesAsync("./Input.txt");
var tempCratesInStack = new List<Tuple<int, Crate>>();
var crateStacks = new Dictionary<int, CrateStack>();
foreach (var line in input)
{
    if (line.StartsWith("move"))
    {
        var move = new Move(line);
        var removedCrates= crateStacks[move.SourceColumn].RemoveCrates(move.NumberToMove);
        crateStacks[move.DestinationColumn].AddCrates(removedCrates);
    }
    else if (line.StartsWith('['))
    {
        // Since the input file defines the crates in the stacks before it defines the stacks,
        // need a temporary place to hold those definitions until the stacks are defined.  We 
        // could just assume 9 stacks to simplify things I guess, but where's the fun in that?
        var crates = line.ToCharArray();
        for (var i = 0; i < 9; i++)
        {
            var crateId = crates[i * 4 + 1];
            if (crateId!=' ') tempCratesInStack.Add(new Tuple<int, Crate>(i+1, new Crate(crateId)));
        }
    }
    else if (string.IsNullOrEmpty(line))
    {
    }
    else
    {
        // We *could* just combine this code in the `else if (line.StartsWith('['))` section
        // but this is just here in case the number of stacks changes in part 2.  Which it didn't.
        var stackIds = line.Split(' ');

        foreach (var stackId in stackIds.Where(sid => !string.IsNullOrEmpty(sid)))
        {
            crateStacks.Add(int.Parse(stackId), new CrateStack(tempCratesInStack.Where(cis => cis.Item1 == int.Parse(stackId))
                .Select(cis => cis.Item2).ToArray()));
        }
    }
}

foreach (var crateStack in crateStacks)
{
    Console.WriteLine($"Top of stack {crateStack.Key} = {crateStack.Value.Crates.Peek().Identifier}");
}
