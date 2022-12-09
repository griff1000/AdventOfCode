namespace Challenge9;

using System.Drawing;

internal class Knot
{
    internal Point Position { get; private set; }

    public Knot(int x, int y)
    {
        Position = new Point(x, y);
    }

    internal void ProcessMove(string direction, Point? leadingPosition)
    {
        if (leadingPosition is null)
        {
            Move(direction);
        }
        else if (DoesThisNeedToMove(leadingPosition.Value))
        {
            if (leadingPosition.Value.X > Position.X) { Move("R"); }
            if (leadingPosition.Value.X < Position.X) { Move("L"); }
            if (leadingPosition.Value.Y > Position.Y) { Move("U"); }
            if (leadingPosition.Value.Y < Position.Y) { Move("D"); }
        }
    }

    private void Move(string direction)
    {
        var startPosition = Position;
        _ = direction switch
        {
            "U" => startPosition with { Y = (startPosition.Y)++ },
            "D" => startPosition with { Y = (startPosition.Y)-- },
            "L" => startPosition with { X = (startPosition.X)-- },
            "R" => startPosition with { X = (startPosition.X)++ },
            _ => Position
        };
        Position = startPosition;
    }

    private bool DoesThisNeedToMove(Point leadingPosition)
    {
        return Math.Abs(leadingPosition.X - Position.X) > 1 || Math.Abs(leadingPosition.Y - Position.Y) > 1;
    }
}