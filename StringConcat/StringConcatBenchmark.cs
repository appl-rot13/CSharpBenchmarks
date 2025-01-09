
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<StringConcatBenchmark>();

[MemoryDiagnoser]
public class StringConcatBenchmark
{
    private static readonly string Chars = "0123456789abcdef";
    private static readonly int[] Indexes = [1, 2, 3, 4, 5, 6, 7, 8];

    [Benchmark]
    public string OperatorAggregate()
    {
        return StringConcat.OperatorAggregate(Chars, Indexes);
    }

    [Benchmark]
    public string Operator()
    {
        return StringConcat.Operator(Chars, Indexes);
    }

    [Benchmark]
    public string Concat()
    {
        return StringConcat.Concat(Chars, Indexes);
    }

    [Benchmark]
    public string Builder()
    {
        return StringConcat.Builder(Chars, Indexes);
    }

    [Benchmark]
    public string BuilderSpecifiedCapacity()
    {
        return StringConcat.BuilderSpecifiedCapacity(Chars, Indexes);
    }
}
