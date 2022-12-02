namespace Challenge2
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarker
    {
        private Round[] _rounds;

        [GlobalSetup]
        public async Task Setup()
        {

            var input = await File.ReadAllLinesAsync("./input.txt");
            _rounds = input.Select(i => new Round(i)).ToArray();
        }

        [Benchmark]
        public async Task RunFullAnalysisIncludingLoad()
        {
            // If you want to test just the data analysis, make the method void then comment out
            // the next two lines (and change the rounds.Sum to _rounds.Sum)
            var input = await File.ReadAllLinesAsync("./input.txt");
            var rounds = input.Select(i => new Round(i)).ToArray();
            _ = rounds.Sum(i => i.RoundScoreBefore);
            _ = rounds.Sum(i => i.RoundScoreAfter);
        }

        [Benchmark]
        public void RunJustAnalysisDataPreloaded()
        {
            _ = _rounds.Sum(i => i.RoundScoreBefore);
            _ = _rounds.Sum(i => i.RoundScoreAfter);
        }
    }
}
