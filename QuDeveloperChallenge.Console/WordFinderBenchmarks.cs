using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using QuDeveloperChallenge.Library;

namespace QuDeveloperChallenge.Console
{
    [MemoryDiagnoser]
    public class WordFinderBenchmarks
    {
        private readonly Consumer _consumer = new();
        private WordFinder _wordFinder;

        public WordFinderBenchmarks()
        {
            HashSet<string> matrix = [];
            _wordFinder = new WordFinder(matrix);
        }

        [Benchmark]
        public void RunFindBenchmark()
        {
            HashSet<string> wordStream = [];
            _wordFinder.Find(wordStream).Consume(_consumer);
        }
    }
}
