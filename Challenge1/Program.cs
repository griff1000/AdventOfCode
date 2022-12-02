int calorieCount = 0, elfCount = 0;
var caloriesPerElf = new Dictionary<int, int>();
foreach (var line in await File.ReadAllLinesAsync("./input.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        caloriesPerElf.Add(++elfCount, calorieCount);
        calorieCount = 0;
        continue;
    }
    calorieCount += int.Parse(line);
}
Console.WriteLine($"Fattest elf is {caloriesPerElf.MaxBy(cpe => cpe.Value).Key}; Sum of top 3 calories = {caloriesPerElf.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value)}");