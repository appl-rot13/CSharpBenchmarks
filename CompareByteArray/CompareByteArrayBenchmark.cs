
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<CompareByteArrayBenchmark>();

[MemoryDiagnoser]
public class CompareByteArrayBenchmark
{
    private byte[] first;
    private byte[] second;

    [GlobalSetup]
    public void Setup()
    {
        this.first = Enumerable.Range(1, this.N).Select(i => (byte)i).ToArray();
        this.second = Enumerable.Range(1, this.N).Select(i => (byte)i).ToArray();

        if (!this.ArrayEquals)
        {
            // 同一配列が最遅ケースのため、最速ケースとして配列の先頭を異なる値とする
            this.second[0] = 0;
        }
    }

    [Params(32, 1024)]
    public int N { get; set; }

    [Params(false, true)]
    public bool ArrayEquals { get; set; }

    [Benchmark]
    public bool CompareWithForLoop()
    {
        return CompareByteArray.CompareWithForLoop(this.first, this.second);
    }

    [Benchmark]
    public bool CompareWithSequenceEqual()
    {
        return CompareByteArray.CompareWithSequenceEqual(this.first, this.second);
    }

    [Benchmark]
    public bool CompareCastToReadOnlySpan()
    {
        return CompareByteArray.CompareCastToReadOnlySpan(this.first, this.second);
    }

    [Benchmark]
    public bool CompareCastToSpan()
    {
        return CompareByteArray.CompareCastToSpan(this.first, this.second);
    }

    [Benchmark]
    public bool CompareAsSpan()
    {
        return CompareByteArray.CompareAsSpan(this.first, this.second);
    }
}
