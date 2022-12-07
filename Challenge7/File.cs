namespace Challenge7
{
    internal class File
    {
        internal string Name { get; }
        internal long Size { get; }

        public File(string name, long size)
        {
            Name = name;
            Size = size;
        }
    }
}
