namespace Challenge8
{
    using System.Drawing;

    internal class Tree
    {
        internal int Height { get; }
        internal bool IsVisible { get; private set; }
        internal Point Coordinates { get; }
        internal int ScenicScore { get; set; }

        internal Tree(char height, Point coordinates)
        {
            Height = Convert.ToInt32(height.ToString());
            Coordinates = coordinates;
            IsVisible = coordinates.X == 0 && coordinates.Y == 0;
            ScenicScore = 0;
        }

        internal void SetVisible()
        {
            IsVisible = true;
        }
    }
}
