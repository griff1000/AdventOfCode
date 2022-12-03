using Challenge3;

var input = await File.ReadAllLinesAsync("./input.txt");
var rucksacks = input.Select(i => new Rucksack(i)).ToArray();
var groups = rucksacks.Chunk(3).Select(group => new Group(group));
Console.WriteLine($"Sum of priorities: {rucksacks.Sum(r => r.CommonItemPriority)}; Sum of Badge priorities: {groups.Sum(g => g.BadgePriority)}");
