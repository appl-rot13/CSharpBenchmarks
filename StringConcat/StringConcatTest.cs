
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StringConcatTest
{
    [TestMethod]
    public void OperatorAggregateTest()
    {
        Test(StringConcat.OperatorAggregate);
    }

    [TestMethod]
    public void OperatorTest()
    {
        Test(StringConcat.Operator);
    }

    [TestMethod]
    public void ConcatTest()
    {
        Test(StringConcat.Concat);
    }

    [TestMethod]
    public void BuilderTest()
    {
        Test(StringConcat.Builder);
    }

    [TestMethod]
    public void BuilderSpecifiedCapacityTest()
    {
        Test(StringConcat.BuilderSpecifiedCapacity);
    }

    [TestMethod]
    public void StringCreateTest()
    {
        Test(StringConcat.StringCreate);
    }

    [TestMethod]
    public void DefaultInterpolatedStringHandlerTest()
    {
        Test(StringConcat.DefaultInterpolatedStringHandler);
    }

    private static void Test(Func<string, int[], string> concat)
    {
        concat("0123456789abcdef", [1, 2, 3, 4, 5, 6, 7, 8]).Is("01234567");
    }
}
