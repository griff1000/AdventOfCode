var input = await File.ReadAllTextAsync("./Input.txt");
const int requiredLength = 4; // 14 for second part
var count = requiredLength;
while (input[(count - requiredLength)..count++].Distinct().Count() != requiredLength){ }
Console.WriteLine($"End position of first unique sequence of {requiredLength} = {count-1}");
