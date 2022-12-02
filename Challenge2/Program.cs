// See https://aka.ms/new-console-template for more information

using Challenge2;

var input = await File.ReadAllLinesAsync("./input.txt");
var scoreBeforeFullRequirements = 0;
var scoreAfterFullRequirements = 0;
foreach (var guesses in input)
{
    var round = new Round(guesses);
    scoreBeforeFullRequirements += round.RoundScoreBeforeFullRequirements;
    scoreAfterFullRequirements += round.RoundScoreAfterFullRequirements;

}

Console.WriteLine($"Score before full requirements: {scoreBeforeFullRequirements}; score after full requirements: {scoreAfterFullRequirements}");


