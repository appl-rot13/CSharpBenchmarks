
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<MemberVsLocalBenchmark>();

[MemoryDiagnoser]
public class MemberVsLocalBenchmark
{
    private readonly byte[] first = Enumerable.Range(1, 32).Select(i => (byte)i).ToArray();
    private readonly byte[] second = Enumerable.Range(1, 32).Select(i => (byte)i).ToArray();

    [Benchmark]
    public bool CompareMember()
    {
        for (var i = 0; i < this.first.Length; i++)
        {
            if (this.first[i] != this.second[i])
            {
                return false;
            }
        }

        return true;
    }

    [Benchmark]
    public bool CompareLocal()
    {
        var first = this.first;
        var second = this.second;

        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
            {
                return false;
            }
        }

        return true;
    }
}
