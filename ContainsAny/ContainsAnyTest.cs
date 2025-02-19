
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ContainsAnyTest
{
    [TestMethod]
    public void WithLinqTest()
    {
        Test((source, keywords) => ContainsAny.WithLinq(source, keywords, StringComparison.Ordinal));
    }

    [TestMethod]
    public void WithSpanTest()
    {
        Test((source, keywords) => ContainsAny.WithSpan(source, keywords, StringComparison.Ordinal));
    }

    private static void Test(Func<string, string[], bool> containsAny)
    {
        var testCase = new (string, string[], bool)[]
            {
                ("a"    , ["aaa", "bbb", "ccc"], false),
                ("bbb"  , ["aaa", "bbb", "ccc"], true ),
                ("ccccc", ["aaa", "bbb", "ccc"], true ),
                (""     , [                   ], false),
            };

        foreach (var (source, keywords, expected) in testCase)
        {
            containsAny(source, keywords).Is(expected);
        }
    }
}
