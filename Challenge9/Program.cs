using System.Drawing;
using Challenge9;

var input = await File.ReadAllLinesAsync("./Input.txt");

// For part 2, just change to Enumerable.Range(1,10) etc.
var knots = Enumerable.Range(1, 2).Select(_ => new Knot(0, 0)).ToList();
var visited = new HashSet<Point> { knots[^1].Position };
foreach (var command in input)
{
    var elements = command.Split(' ');
    for (var i = 0; i < int.Parse(elements[1]); i++)
    {
        knots[0].ProcessMove(elements[0], null);
        for (var j = 1; j < knots.Count; j++)
        {
            knots[j].ProcessMove(elements[0], knots[j-1].Position);
        }
        visited.Add(knots[^1].Position);
    }
}
Console.WriteLine($"{visited.Count} locations visited by tail");

