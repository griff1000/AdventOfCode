var input = await File.ReadAllTextAsync("./Input.txt");
const int requiredSequenceLength = 4; // 14 for second part
var count = requiredSequenceLength;
while (input[(count - requiredSequenceLength)..count++].Distinct().Count() != requiredSequenceLength)
{ }
Console.WriteLine($"End position of first unique sequence of {requiredSequenceLength} = {count-1}");
