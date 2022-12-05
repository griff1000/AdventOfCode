using Challenge5;

var input = await File.ReadAllLinesAsync("./Input.txt");
var tempCratesInStack = new List<Tuple<int, Crate>>();
var crateStacks = new Dictionary<int, CrateStack>();
foreach (var line in input)
{
    if (line.StartsWith("move"))
    {
        var move = new Move(line);
        // Mechanism for Part 1
        //for (var i = 1; i <= move.NumberToMove; i++)
        //{
        //    var crate = crateStacks[move.SourceColumn].Crates.Pop();
        //    crateStacks[move.DestinationColumn].Crates.Push(crate);
        //}

        // Mechanism for Part 2
        var cratesToMove = new List<Crate>();
        for (var i = 1; i <= move.NumberToMove; i++)
        {
            var crate = crateStacks[move.SourceColumn].Crates.Pop();
            cratesToMove.Add(crate);
        }
        cratesToMove.Reverse();
        foreach (var crate in cratesToMove)
        {
            crateStacks[move.DestinationColumn].Crates.Push(crate);
        }
    }
    else if (line.StartsWith('['))
    {
        var crates = line.ToCharArray();
        for (var i = 0; i < 9; i++)
        {
            var crateId = crates[i * 4 + 1];
            if (crateId!=' ') tempCratesInStack.Add(new Tuple<int, Crate>(i+1, new Crate(crateId)));
        }
    }
    else if (string.IsNullOrEmpty(line))
    {
        continue;
    }
    else
    {
        var stackIds = line.Split(' ');

        foreach (var stackId in stackIds.Where(sid => !string.IsNullOrEmpty(sid)))
        {
            var stackOfCrates = new Stack<Crate>(tempCratesInStack.Where(cis => cis.Item1 == int.Parse(stackId))
                .Select(cis => cis.Item2).ToArray().Reverse());

            crateStacks.Add(int.Parse(stackId), new CrateStack(stackOfCrates));
        }
    }
}

foreach (var crateStack in crateStacks)
{
    Console.WriteLine($"Top of stack {crateStack.Key} = {crateStack.Value.Crates.Peek().Identifier}");
}
