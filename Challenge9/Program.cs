using Challenge9;
using System.Drawing;

var input = await File.ReadAllLinesAsync("./Input.txt");

// For part 2, just change to Enumerable.Range(1,10) etc.
var knots = Enumerable.Range(1, 10).Select(_ => new Knot(0, 0)).ToList();
var visited = new HashSet<Point> { knots[^1].Position };
foreach (var command in input)
{
    var elements = command.Split(' ');
    // This algorithm processes moves one square at a time so repeat for however many 
    // moves are required.  It could fairly easily be changed to moving en block though.
    for (var i = 0; i < int.Parse(elements[1]); i++)
    {
        // process the move for each of the knots
        for (var j = 0; j < knots.Count; j++)
        {
            knots[j].ProcessMove(elements[0], j == 0 ? null : knots[j - 1].Position);
        }
        visited.Add(knots[^1].Position); // HashSet silently returns false if already exists
    }
}
Console.WriteLine($"{visited.Count} locations visited by tail");

