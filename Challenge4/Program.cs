using Challenge4.FirstImplementation;
using Challenge4.SecondImplementation;

// Uncomment the line below and do a release build/run to use benchmarker
//BenchmarkDotNet.Running.BenchmarkRunner.Run<Challenge4.Benchmarker>();

var input = await File.ReadAllLinesAsync("./input.txt");
var assignments = input.Select(i => new Assignment(i)).ToArray();
var assignmentsWithRanges = input.Select(i => new AssignmentWithRanges(i)).ToArray();

Console.WriteLine($"Simple implementation: Number of fully contained assignments = {assignments.Count(a => a.OneContainedInOther)}; number overlapping = {assignments.Count(a => a.IsOverlap)}");

Console.WriteLine($"Range implementation: Number of fully contained assignments = {assignmentsWithRanges.Count(a => a.OneContainedInOther)}; number overlapping = {assignmentsWithRanges.Count(a => a.IsOverlap)}");
