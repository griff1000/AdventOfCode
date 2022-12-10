using Challenge10;

var input = await File.ReadAllLinesAsync("./Input.txt");
var cpu = new CPU();
var instructions = input.Select(i => new Instruction(i)).ToList();
var signalStrengths = new Dictionary<int, int>();
var crt = new CRT();

var cycle = 0;
for (var i = 0; i < instructions.Count; i++)
{
    cycle++;
    crt.ProcessPixel(cycle, cpu.Register);

    if (cycle == 20 || (cycle + 20) % 40 == 0)
    {
        signalStrengths.Add(cycle, cpu.SignalStrength(cycle));
    }
    cpu.ExecuteInstruction(instructions[i]);
    if (!instructions[i].InstructionComplete) i--; // do same instruction until complete
}
Console.WriteLine($"Sum of first six signal strengths: {signalStrengths.Take(6).Sum(ss => ss.Value)}");
crt.RenderCRT();
