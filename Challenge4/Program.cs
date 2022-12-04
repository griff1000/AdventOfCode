using Challenge4;

var input = await File.ReadAllLinesAsync("./input.txt");
var assignments = input.Select(i => new Assignment(i)).ToArray();

Console.WriteLine($"Number of fully contained assignments = {assignments.Count(a => a.OneContainedInOther)}; number overlapping = {assignments.Count(a => a.IsOverlap)}");
