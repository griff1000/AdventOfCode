namespace Challenge7
{
    internal struct File
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
