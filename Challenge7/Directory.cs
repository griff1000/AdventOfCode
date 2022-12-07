namespace Challenge7
{
    internal class Directory
    {
        internal Directory? Parent { get; }
        internal string Name { get; }
        internal List<Directory> Directories { get; } = new();
        internal List<File> Files { get; } = new();
        internal long Size => CalculateSize();

        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
        }

        private long CalculateSize()
        {
            var size = Files.Sum(f => f.Size);
            size += Directories.Sum(d => d.Size);
            return size;
        }
    }
}
