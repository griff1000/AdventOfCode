using BenchmarkDotNet.Running;
using Challenge4;
using Challenge4.FirstImplementation;
using Challenge4.SecondImplementation;

BenchmarkRunner.Run<Benchmarker>();

//var input = await File.ReadAllLinesAsync("./input.txt");
//var assignments = input.Select(i => new Assignment(i)).ToArray();
//var assignmentsWithRanges = input.Select(i => new AssignmentWithRanges(i)).ToArray();

//Console.WriteLine($"First implementation: Number of fully contained assignments = {assignments.Count(a => a.OneContainedInOther)}; number overlapping = {assignments.Count(a => a.IsOverlap)}");

//Console.WriteLine($"Second implementation: Number of fully contained assignments = {assignmentsWithRanges.Count(a => a.OneContainedInOther)}; number overlapping = {assignmentsWithRanges.Count(a => a.IsOverlap)}");
