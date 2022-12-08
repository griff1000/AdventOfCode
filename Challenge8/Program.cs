using Challenge8;

var input = await File.ReadAllLinesAsync("./Input.txt");

var grid = new Grid(input);
grid.SetVisibility();
Console.WriteLine($"There are {grid.Trees.Count(t => t.Value.IsVisible)} trees visible");
grid.SetScenicScore();
Console.WriteLine($"Max possible Scenic Score = {grid.MaxScenicScore}");
