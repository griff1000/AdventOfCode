using BenchmarkDotNet.Running;
using Challenge2;

//BenchmarkRunner.Run<Benchmarker>();

var input = await File.ReadAllLinesAsync("./input.txt");
var rounds = input.Select(i => new Round(i)).ToArray();
var scoreBeforeFullRequirements = rounds.Sum(i => i.RoundScoreBefore);
var scoreAfterFullRequirements = rounds.Sum(i => i.RoundScoreAfter);

Console.WriteLine($"Score before full requirements: {scoreBeforeFullRequirements}; score after full requirements: {scoreAfterFullRequirements}.");