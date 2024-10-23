
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ComputeHashBenchmark>();

[MemoryDiagnoser]
public class ComputeHashBenchmark
{
    private static readonly string TargetDirPath = AppContext.BaseDirectory;

    [Benchmark]
    public List<(string, string)> ComputeHashWithLock()
    {
        return Test(ComputeHash.ComputeHashWithLock);
    }

    [Benchmark]
    public List<(string, string)> ComputeHashWithoutLock()
    {
        return Test(ComputeHash.ComputeHashWithoutLock);
    }

    private static List<(string, string)> Test(Func<string, byte[]> computeHash)
    {
        return Directory.EnumerateFiles(TargetDirPath, "*", SearchOption.AllDirectories).AsParallel()
            .Select(filePath => (filePath, ToHexString(computeHash(filePath)))).OrderBy(t => t.filePath).ToList();
    }

    private static string ToHexString(byte[] bytes)
    {
        //return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
        return Convert.ToHexString(bytes).ToLower();
    }
}
