
using Shouldly;

[TestClass]
public class SortAlgorithmTest
{
    [TestMethod]
    public void BubbleSortTest()
    {
        Test(SortAlgorithm.BubbleSort);
    }

    [TestMethod]
    public void SelectionSortTest()
    {
        Test(SortAlgorithm.SelectionSort);
    }

    [TestMethod]
    public void InsertionSortTest()
    {
        Test(SortAlgorithm.InsertionSort);
    }

    [TestMethod]
    public void ShellSortTest()
    {
        Test(SortAlgorithm.ShellSort);
    }

    [TestMethod]
    public void MergeSortTest()
    {
        Test(SortAlgorithm.MergeSort);
    }

    [TestMethod]
    public void HeapSortTest()
    {
        Test(SortAlgorithm.HeapSort);
    }

    [TestMethod]
    public void QuickSortTest()
    {
        Test(SortAlgorithm.QuickSort);
    }

    private static void Test(Action<int[]> sort, int n = 10)
    {
        for (var i = 0; i <= n; i++)
        {
            int[] expected = [.. Enumerable.Range(1, i)];
            int[] array = [.. expected.Shuffle()];

            Console.WriteLine($"Before: {Dump(array)}");
            sort(array);
            Console.WriteLine($" After: {Dump(array)}\n");

            array.ShouldBe(expected);
        }
    }

    private static string Dump(int[] array)
    {
        return $"[{string.Join(", ", array)}]";
    }
}
