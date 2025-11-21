
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SortAlgorithmBenchmark>();

[MemoryDiagnoser]
public class SortAlgorithmBenchmark
{
    private int[] shuffledArray;
    private int[] ascendingArray;
    private int[] descendingArray;

    public enum Pattern
    {
        Shuffled,
        Ascending,
        Descending,
    }

    [Params(10, 1000, 100000)]
    public int N { get; set; }

    [ParamsAllValues]
    public Pattern Source { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        this.ascendingArray = [.. Enumerable.Range(1, this.N)];
        this.descendingArray = [.. ascendingArray.Reverse()];
        this.shuffledArray = [.. ascendingArray.Shuffle()];
    }

    [Benchmark]
    public void BubbleSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.BubbleSort(array);
    }

    [Benchmark]
    public void SelectionSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.SelectionSort(array);
    }

    [Benchmark]
    public void InsertionSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.InsertionSort(array);
    }

    [Benchmark]
    public void ShellSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.ShellSort(array);
    }

    [Benchmark]
    public void MergeSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.MergeSort(array);
    }

    [Benchmark]
    public void HeapSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.HeapSort(array);
    }

    [Benchmark]
    public void QuickSort()
    {
        var array = this.CreateArray();
        SortAlgorithm.QuickSort(array);
    }

    private int[] CreateArray()
    {
        return this.Source switch
        {
            Pattern.Shuffled => (int[])shuffledArray.Clone(),
            Pattern.Ascending => (int[])ascendingArray.Clone(),
            Pattern.Descending => (int[])descendingArray.Clone(),
            _ => throw new NotImplementedException(),
        };
    }
}
