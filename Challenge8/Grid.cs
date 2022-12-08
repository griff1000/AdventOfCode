namespace Challenge8
{
    using System.Drawing;

    internal class Grid
    {
        internal Dictionary<Point, Tree> Trees { get; } = new();
        private int NumberOfRows { get; }
        private int NumberOfColumns { get; }

        internal int MaxScenicScore => CalculateMaxScenicScore();

        private int CalculateMaxScenicScore()
        {
            return Trees.MaxBy(t => t.Value.ScenicScore).Value.ScenicScore;
        }

        internal Grid(string[] input)
        {
            NumberOfRows = input.Length;
            NumberOfColumns = input[0].Length;
            for (var row = 0; row < NumberOfRows; row++)
            {
                for (var col = 0; col < NumberOfColumns; col++)
                {
                    Trees.Add(new Point(col, row), new Tree(input[row][col], new Point(col, row)));
                }
            }
        }

        internal void SetVisibility()
        {
            foreach (var thisTree in Trees)
            {
                if (thisTree.Key.X == 0 || thisTree.Key.Y == 0 || thisTree.Key.X == 0 ||
                    thisTree.Key.Y == NumberOfRows - 1 || thisTree.Key.X == NumberOfColumns - 1)
                {
                    thisTree.Value.SetVisible();
                    continue;
                }


                if (thisTree.Value.Height >
                    Trees.Where(t => t.Key.X == thisTree.Value.Coordinates.X && t.Key.Y < thisTree.Value.Coordinates.Y)
                        .MaxBy(t => t.Value.Height).Value.Height)
                {
                    thisTree.Value.SetVisible();
                    continue;
                }

                if (thisTree.Value.Height >
                    Trees.Where(t => t.Key.X == thisTree.Value.Coordinates.X && t.Key.Y > thisTree.Value.Coordinates.Y)
                        .MaxBy(t => t.Value.Height).Value.Height)
                {
                    thisTree.Value.SetVisible();
                    continue;
                }

                if (thisTree.Value.Height >
                    Trees.Where(t => t.Key.Y == thisTree.Value.Coordinates.Y && t.Key.X < thisTree.Value.Coordinates.X)
                        .MaxBy(t => t.Value.Height).Value.Height)
                {
                    thisTree.Value.SetVisible();
                    continue;
                }

                if (thisTree.Value.Height >
                    Trees.Where(t => t.Key.Y == thisTree.Value.Coordinates.Y && t.Key.X > thisTree.Value.Coordinates.X)
                        .MaxBy(t => t.Value.Height).Value.Height)
                    thisTree.Value.SetVisible();
            }
        }



        internal void SetScenicScore()
        {
            foreach (var thisTree in Trees)
            {
                if (thisTree.Key.X == 0 || thisTree.Key.Y == 0 || thisTree.Key.Y == NumberOfRows - 1 ||
                    thisTree.Key.X == NumberOfColumns - 1)
                {
                    thisTree.Value.ScenicScore = 0;
                    continue;
                }

                var treesVisibleToLeft = 0;
                for (var i = thisTree.Key.X - 1; i >= 0; i--)
                {
                    var nextTree = Trees[thisTree.Key with { X = i }];
                    treesVisibleToLeft++;
                    if (nextTree.Height >= thisTree.Value.Height) break;
                }

                var treesVisibleToRight = 0;
                for (var i = thisTree.Key.X + 1; i < NumberOfColumns; i++)
                {
                    var nextTree = Trees[thisTree.Key with { X = i }];
                    treesVisibleToRight++;
                    if (nextTree.Height >= thisTree.Value.Height) break;
                }

                var treesVisibleAbove = 0;
                for (var i = thisTree.Key.Y - 1; i >= 0; i--)
                {
                    var nextTree = Trees[thisTree.Key with { Y = i }];
                    treesVisibleAbove++;
                    if (nextTree.Height >= thisTree.Value.Height) break;
                }

                var treesVisibleBelow = 0;
                for (var i = thisTree.Key.Y + 1; i < NumberOfRows; i++)
                {
                    var nextTree = Trees[thisTree.Key with { Y = i }];
                    treesVisibleBelow++;
                    if (nextTree.Height >= thisTree.Value.Height) break;
                }
                thisTree.Value.ScenicScore =
                    treesVisibleToLeft * treesVisibleToRight * treesVisibleAbove * treesVisibleBelow;
            }
        }
    }
}
