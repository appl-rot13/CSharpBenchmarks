
using System.Buffers;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ContainsAnyBenchmark>();

[MemoryDiagnoser]
public class ContainsAnyBenchmark
{
    private string source;
    private string[] keywords;
    private SearchValues<string> searchValues;

    [GlobalSetup]
    public void Setup()
    {
        this.source = string.Join(string.Empty, Enumerable.Repeat(this.Case ? 'a' : 'e', this.N));
        this.keywords = ["aaa", "bbb", "ccc"];
        this.searchValues = SearchValues.Create(this.keywords, StringComparison.Ordinal);
    }

    [Params(4, 64, 1024, 16384, 262144)]
    public int N { get; set; }

    [Params(true, false)]
    public bool Case { get; set; }

    [Benchmark]
    public bool WithLinq()
    {
        return ContainsAny.WithLinq(this.source, this.keywords, StringComparison.Ordinal);
    }

    [Benchmark]
    public bool WithSpan()
    {
        return ContainsAny.WithSpan(this.source, this.keywords, StringComparison.Ordinal);
    }

    [Benchmark]
    public bool WithSpanPrepared()
    {
        return ContainsAny.WithSpanPrepared(this.source, this.searchValues);
    }
}
