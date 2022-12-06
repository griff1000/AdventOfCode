var input = await File.ReadAllTextAsync("./Input.txt");
const int requiredSequenceLength = 14; // 4 for first part
var count = requiredSequenceLength;
while (input[(count - requiredSequenceLength)..count].Distinct().Count() != requiredSequenceLength)
{
    count++;
}
Console.WriteLine($"End position of first unique sequence of {requiredSequenceLength} = {count}");
