
using Shouldly;

[assembly: Parallelize]

[TestClass]
public class NumericalAnalysisTest
{
    [TestMethod]
    public void MonteCarloPiTest()
    {
        var pi = NumericalAnalysis.MonteCarloPi(100_000, 0);
        Console.WriteLine($"PI = {pi}");

        // 99.98% 以上の確率で 誤差±0.02 に収まる
        pi.ShouldBe(Math.PI, 0.02);
    }

    [TestMethod]
    public void MaclaurinExpTest()
    {
        for (var x = -5.0; x <= 5.0; x += 0.5)
        {
            var exp = NumericalAnalysis.MaclaurinExp(x);
            Console.WriteLine($"exp({x,4:F1}) = {exp,21:F17}");

            exp.ShouldBe(Math.Exp(x), 1e-13);
        }
    }

    [TestMethod]
    public void MaclaurinSinTest()
    {
        // -2 * PI ～ 2 * PI の範囲を PI / 6 (30度) 刻みでテスト
        for (var i = -12; i <= 12; i++)
        {
            var x = (Math.PI / 6.0) * i;
            var sin = NumericalAnalysis.MaclaurinSin(x);
            Console.WriteLine($"sin({x,20:F17}) = {sin,20:F17}");

            sin.ShouldBe(Math.Sin(x), 1e-13);
        }
    }

    [TestMethod]
    public void MaclaurinCosTest()
    {
        // -2 * PI ～ 2 * PI の範囲を PI / 6 (30度) 刻みでテスト
        for (var i = -12; i <= 12; i++)
        {
            var x = (Math.PI / 6.0) * i;
            var cos = NumericalAnalysis.MaclaurinCos(x);
            Console.WriteLine($"cos({x,20:F17}) = {cos,20:F17}");

            cos.ShouldBe(Math.Cos(x), 1e-13);
        }
    }

    [TestMethod]
    public void NewtonSqrtTest()
    {
        for (var x = 0.0; x <= 10.0; x += 0.5)
        {
            var sqrt = NumericalAnalysis.NewtonSqrt(x);
            Console.WriteLine($"sqrt({x,4:F1}) = {sqrt,19:F17}");

            sqrt.ShouldBe(Math.Sqrt(x), 1e-13);
        }
    }

    [TestMethod]
    public void NewtonCbrtTest()
    {
        for (var x = 0.0; x <= 10.0; x += 0.5)
        {
            var cbrt = NumericalAnalysis.NewtonCbrt(x);
            Console.WriteLine($"cbrt({x,4:F1}) = {cbrt,19:F17}");

            cbrt.ShouldBe(Math.Cbrt(x), 1e-13);
        }
    }

    [TestMethod]
    public void SimpsonPolynomialTest()
    {
        // 区間 [-2, 3] における f(x) = x^3 + 2x^2 + x - 1 の定積分
        var fx = (double x) => x * x * x + 2.0 * x * x + x - 1.0;
        var integral = NumericalAnalysis.Simpson(fx, -2.0, 3.0);
        Console.WriteLine($"Integral [-2..3] (x^3 + 2x^2 + x - 1) dx = {integral,20:F17}");

        integral.ShouldBe(445.0 / 12.0, 1e-10);
    }

    [TestMethod]
    public void SimpsonSinTest()
    {
        // 区間 [0, PI] における f(x) = sin(x) の定積分
        var integral = NumericalAnalysis.Simpson(Math.Sin, 0.0, Math.PI);
        Console.WriteLine($"Integral [0..PI] sin(x) dx = {integral,20:F17}");

        integral.ShouldBe(2.0, 1e-10);
    }

    [TestMethod]
    public void EulerTest()
    {
        for (var i = 2; i < 5; i++)
        {
            // h = 0.01, 0.001, 0.0001
            var h = Math.Pow(10.0, -i);

            // dy/dx = y, y(0) = 1 の解は y = exp(x)
            var y = NumericalAnalysis.Euler((x, y) => y, 1.0, 0.0, 1.0, h);
            Console.WriteLine($"y(1) = {y,19:F17}, h = {h,6}, tolerance = {Math.Exp(1.0) - y,20:F17}");

            y.ShouldBe(Math.Exp(1.0), 0.02);
        }
    }

    [TestMethod]
    public void RungeKuttaTest()
    {
        for (var i = 2; i < 5; i++)
        {
            // h = 0.01, 0.001, 0.0001
            var h = Math.Pow(10.0, -i);

            // dy/dx = y, y(0) = 1 の解は y = exp(x)
            var y = NumericalAnalysis.RungeKutta((x, y) => y, 1.0, 0.0, 1.0, h);
            Console.WriteLine($"y(1) = {y,19:F17}, h = {h,6}, tolerance = {Math.Exp(1.0) - y,20:F17}");

            y.ShouldBe(Math.Exp(1.0), 1e-9);
        }
    }

    [TestMethod]
    public void GaussianEliminationTest()
    {
        var matrix = new double[,]
        {
            {  2,  1, -1,   8 },
            { -3, -1,  2, -11 },
            { -2,  1,  2,  -3 },
        };

        var x = NumericalAnalysis.GaussianElimination(matrix);
        Console.WriteLine("x = \n[\n" + string.Join(",\n", x.Select(value => $"{value,22:F17}")) + "\n]");

        x[0].ShouldBe( 2.0, 1e-13);
        x[1].ShouldBe( 3.0, 1e-13);
        x[2].ShouldBe(-1.0, 1e-13);
    }

    [TestMethod]
    public void GaussJordanEliminationTest()
    {
        var matrix = new double[,]
        {
            {  2,  1, -1,   8 },
            { -3, -1,  2, -11 },
            { -2,  1,  2,  -3 },
        };

        var x = NumericalAnalysis.GaussJordanElimination(matrix);
        Console.WriteLine("x = \n[\n" + string.Join(",\n", x.Select(value => $"{value,22:F17}")) + "\n]");

        x[0].ShouldBe( 2.0, 1e-13);
        x[1].ShouldBe( 3.0, 1e-13);
        x[2].ShouldBe(-1.0, 1e-13);
    }

    [TestMethod]
    public void FibonacciTest()
    {
        int[] expected = [ 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 ];
        for (int i = 0; i < expected.Length; i++)
        {
            NumericalAnalysis.Fibonacci(i).ShouldBe(expected[i]);
        }
    }

    [TestMethod]
    [DataRow(0, 0, 1)]
    [DataRow(0, 5, 6)]
    [DataRow(1, 2, 4)]
    [DataRow(2, 2, 7)]
    [DataRow(3, 3, 61)]
    public void AckermannTest(int m, int n, int expected)
    {
        NumericalAnalysis.Ackermann(m, n).ShouldBe(expected);
    }
}
