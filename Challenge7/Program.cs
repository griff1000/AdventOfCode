using Directory=Challenge7.Directory;
using File= Challenge7.File;

var input = await System.IO.File.ReadAllLinesAsync("./Input.txt");

const long totalDiskSpace = 70000000;
const long minDiskSpace = 30000000;

Directory? currentDirectory = null;
var allDirectories = new List<Directory>();
foreach (var command in input)
{
    var elements = command.Split(' ');
    switch (elements[0])
    {
        case "$":
            switch (elements[1])
            {
                case "cd":
                    switch (elements[2])
                    {
                        case "..":
                            currentDirectory = currentDirectory!.Parent;
                            break;
                        default:
                            if (currentDirectory == null)
                            {
                                var rootDirectory = new Directory(elements[2], null);
                                currentDirectory = rootDirectory;
                                allDirectories.Add(rootDirectory);
                            }
                                
                            else
                                currentDirectory = currentDirectory!.Directories.Single(d => d.Name == elements[2]);
                            break;
                    }

                    break;
                case "ls":
                    break;
            }
            break;
        case "dir":
            var directory = new Directory(elements[1], currentDirectory);
            currentDirectory!.Directories.Add(directory);
            allDirectories.Add(directory);
            break;
        default:
            currentDirectory!.Files.Add(new File(elements[1], long.Parse(elements[0])));
            break;
    }
}

while (currentDirectory!.Parent is not null)
{
    currentDirectory = currentDirectory.Parent;
}

var sizeOfSmallerDirectories = allDirectories.Where(d => d.Size <= 100000).Sum(d => d.Size);
Console.WriteLine($"Sum of size of smaller directories = {sizeOfSmallerDirectories}");

var diskSizeRemaining = totalDiskSpace - currentDirectory.Size;
var spaceRequiredToFree = minDiskSpace - diskSizeRemaining;
var directoryToDelete = allDirectories.Where(d => d.Size >= spaceRequiredToFree).OrderBy(d => d.Size).First();
Console.WriteLine($"Size of directory to delete = {directoryToDelete.Size}");