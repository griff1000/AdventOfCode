namespace Challenge10;

using System.Text;

internal class CRT
{
    private List<List<bool>> Pixels { get; } = new ();

    internal CRT()
    {
        for (var r = 0; r <= 6; r++)
        {
            var row = new List<bool>();
            for (var c = 0; c < 40; c++)
            {
                row.Add(false);
            }
            Pixels.Add(row);
        }
    }

    internal void ProcessPixel(int cycle, int registerValue)
    {
        var horizontal = (cycle - 1) % 40;
        var vertical = (cycle - 1) / 40;
        var isLit = (horizontal - 1) <= registerValue && (horizontal + 1) >= registerValue;
        Pixels[vertical][horizontal] = isLit;
    }

    internal void Render()
    {
        foreach (var row in Pixels)
        {
            var sb = new StringBuilder();
            foreach (var pixel in row)
            {
                sb.Append(pixel ? '*' : ' ');
            }
            Console.WriteLine(sb.ToString());
        }
    }
}