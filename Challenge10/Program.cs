using System.Text;
using Challenge10;
using Microsoft.VisualBasic;

var input = await File.ReadAllLinesAsync("./Input.txt");
var cpu = new CPU();
var instructions = input.Select(i => new Instruction(i)).ToList();
var cycle = 0;
var signalStrengths = new Dictionary<int, int>();
var crt = new List<List<bool>>();
for (var r = 0; r <= 6; r++ )
{
    var row = new List<bool>();
    for (var c = 0; c < 40; c++)
    {
        row.Add(false);
    }
    crt.Add(row);
}

var horizontal = -1;
var vertical = 0;
for (var i = 0; i < instructions.Count; i++)
{
    cycle++;
    horizontal++;
    if (horizontal > 39)
    {
        horizontal = 0;
        vertical++;
    }
    var isLit = (horizontal - 2) < cpu.Register && (horizontal + 2) > cpu.Register;
    crt[vertical][horizontal] = isLit;

    if (cycle == 20 || (cycle + 20) % 40 == 0)
    {
        signalStrengths.Add(cycle, cpu.SignalStrength(cycle));
    }
    cpu.ExecuteInstruction(instructions[i]);
    if (!instructions[i].InstructionComplete) i--; // do same instruction until complete
}
Console.WriteLine($"Sum of first six signal strengths: {signalStrengths.Take(6).Sum(ss => ss.Value)}");
foreach (var row in crt)
{
    var sb = new StringBuilder();
    foreach (var pixel in row)
    {
        sb.Append(pixel ? '#' : '.');
    }
    Console.WriteLine(sb.ToString());
}
