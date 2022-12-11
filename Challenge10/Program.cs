using Challenge10;

var input = await File.ReadAllLinesAsync("./Input.txt");
var cpu = new CPU();
var instructions = input.Select(i => new Instruction(i)).ToList();
var signalStrengths = new Dictionary<int, int>();
var crt = new CRT();

var cycle = 0;
foreach (var instruction in instructions)
{
    do
    {
        cycle++;
        crt.ProcessPixel(cycle, cpu.Register);

        if (cycle == 20 || (cycle + 20) % 40 == 0)
        {
            signalStrengths.Add(cycle, cpu.SignalStrength(cycle));
        }
        cpu.ExecuteInstruction(instruction);
    } while (!instruction.InstructionComplete);
}
Console.WriteLine($"Sum of first six signal strengths: {signalStrengths.Take(6).Sum(ss => ss.Value)}");
crt.Render();
