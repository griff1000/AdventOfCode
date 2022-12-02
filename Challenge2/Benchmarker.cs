namespace Challenge2
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarker
    {
        //private Round[] _rounds;

        //[GlobalSetup]
        //public async Task Setup()
        //{
        //    var input = await File.ReadAllLinesAsync("./input.txt");
        //    _rounds = input.Select(i => new Round(i)).ToArray();
        //}

        [Benchmark]
        public async Task RunAnalysis()
        {
            var input = await File.ReadAllLinesAsync("./input.txt");
            var rounds = input.Select(i => new Round(i)).ToArray();
            var scoreBeforeFullRequirements = rounds.Sum(i => i.RoundScoreBefore);
            var scoreAfterFullRequirements = rounds.Sum(i => i.RoundScoreAfter);

            Console.WriteLine($"Score before full requirements: {scoreBeforeFullRequirements}; score after full requirements: {scoreAfterFullRequirements}.");
        }
    }
}
