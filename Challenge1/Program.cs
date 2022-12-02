var input = await File.ReadAllLinesAsync("./input.txt");
int maxCalories = 0, calorieCount = 0, fattestElf = 0, elfCount = 0;
var caloriesPerElf = new Dictionary<int, int>();
foreach (var line in input)
{
    if (string.IsNullOrEmpty(line))
    {
        caloriesPerElf.Add(++elfCount, calorieCount);
        if (calorieCount > maxCalories)
        {
            maxCalories = calorieCount;
            fattestElf = elfCount;
        }
        calorieCount = 0;
    }
    else
    {
        calorieCount += int.Parse(line);
    }
}
var top3 = caloriesPerElf.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value);
Console.WriteLine($"Fattest elf is {fattestElf}; Sum of top 3 calories = {top3}");