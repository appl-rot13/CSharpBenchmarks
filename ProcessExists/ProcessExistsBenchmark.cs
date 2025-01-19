
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ProcessExistsBenchmark>();

[MemoryDiagnoser]
public class ProcessExistsBenchmark
{
    [Benchmark]
    public bool GetProcessesAny()
    {
        return Test(ProcessExists.GetProcessesAny);
    }

    [Benchmark]
    public bool GetProcessesForEach()
    {
        return Test(ProcessExists.GetProcessesForEach);
    }

    [Benchmark]
    public bool GetProcessesByNameAny()
    {
        return Test(ProcessExists.GetProcessesByNameAny);
    }

    [Benchmark]
    public bool GetProcessesByNameLength()
    {
        return Test(ProcessExists.GetProcessesByNameLength);
    }

    private static bool Test(Func<string, bool> processExists)
    {
        return processExists("Notepad");
    }
}
