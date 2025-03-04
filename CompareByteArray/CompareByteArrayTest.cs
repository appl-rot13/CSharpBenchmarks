
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class CompareByteArrayTest
{
    [TestMethod]
    public void CompareWithForLoopTest()
    {
        Test(CompareByteArray.CompareWithForLoop);
    }

    [TestMethod]
    public void CompareWithSequenceEqualTest()
    {
        Test(CompareByteArray.CompareWithSequenceEqual);
    }

    [TestMethod]
    public void CompareCastToReadOnlySpanTest()
    {
        Test((first, second) => CompareByteArray.CompareCastToReadOnlySpan(first, second));
    }

    [TestMethod]
    public void CompareCastToSpanTest()
    {
        Test((first, second) => CompareByteArray.CompareCastToSpan(first, second));
    }

    [TestMethod]
    public void CompareAsSpanTest()
    {
        Test(CompareByteArray.CompareAsSpan);
    }

    private static void Test(Func<byte[], byte[], bool> compareByteArray)
    {
        var testCase = new (byte[], byte[], bool)[]
            {
                ([1, 2, 3], [1, 2   ], false),
                ([1, 2, 3], [       ], false),
                ([1, 2   ], [1, 2, 3], false),
                ([       ], [1, 2, 3], false),
                ([1, 2, 3], [1, 2, 3], true ),
                ([       ], [       ], true ),
            };

        foreach (var (first, second, expected) in testCase)
        {
            compareByteArray(first, second).ShouldBe(expected);
        }
    }
}
