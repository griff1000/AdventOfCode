namespace Challenge4
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Order;
    using FirstImplementation;
    using SecondImplementation;

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmarker
    {
        private string[] _input;

        [GlobalSetup]
        public async Task Setup()
        {

            _input = await File.ReadAllLinesAsync("input.txt");
        }

        [Benchmark]
        public void SimpleImplementationUsingLinq()
        {
            var assignments = _input.Select(i => new Assignment(i)).ToArray();
            _ = assignments.Count(a => a.OneContainedInOther);
            _ = assignments.Count(a => a.IsOverlap);
        }

        [Benchmark]
        public void ImplementationUsingRange()
        {
            var assignments = _input.Select(i => new AssignmentWithRanges(i)).ToArray(); 
            _ = assignments.Count(a => a.OneContainedInOther);
            _ = assignments.Count(a => a.IsOverlap);
        }
    }
}
