
public partial class NumericalAnalysis
{
    public static double MonteCarloPi(long n, int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();

        var m = 0L;
        for (var i = 0L; i < n; i++)
        {
            var x = random.NextDouble();
            var y = random.NextDouble();

            // x^2 + y^2 が r^2 の範囲内かどうかを判定
            if (x * x + y * y <= 1.0) m++;
        }

        // 円の中の点 / 全ての点 ≈ 円の面積 / 正方形の面積 なので、
        // m / n ≈ (PI * r^2) / (2r * 2r) = PI / 4  ->  PI ≈ 4 * m / n
        return 4.0 * m / n;
    }

    public static double MaclaurinExp(double x)
    {
        var term = 1.0;
        var sum = term;

        // 1 + x / 1! + x^2 / 2! + ... + x^n / n! + ...
        for (var n = 1; Math.Abs(term) > 1e-16; n++)
        {
            term *= x / n;
            sum += term;
        }

        return sum;
    }

    public static double MaclaurinSin(double x)
    {
        x %= 2.0 * Math.PI;

        var term = x;
        var sum = term;

        // x - x^3 / 3! + x^5 / 5! - ... + (-1)^n * x^(2n + 1) / (2n + 1)! + ...
        for (var n = 1; Math.Abs(term) > 1e-16; n++)
        {
            term *= -x * x / ((2.0 * n) * (2.0 * n + 1));
            sum += term;
        }

        return sum;
    }

    public static double MaclaurinCos(double x)
    {
        x %= 2.0 * Math.PI;

        var term = 1.0;
        var sum = term;

        // 1 - x^2 / 2! + x^4 / 4! - ... + (-1)^n * x^(2n) / (2n)! + ...
        for (var n = 1; Math.Abs(term) > 1e-16; n++)
        {
            term *= -x * x / ((2.0 * n - 1) * (2.0 * n));
            sum += term;
        }

        return sum;
    }

    public static double NewtonSqrt(double x)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(x);

        if (x == 0.0)
        {
            return 0.0;
        }

        var current = x;
        while (true)
        {
            // 公式は以下の式だが、桁落ちによる精度低下を避けるため、変形した式を使用
            //var next = current - (current * current - x) / (2.0 * current);
            var next = 0.5 * (current + x / current);

            if (Math.Abs(next - current) < 1e-15)
            {
                return next;
            }

            current = next;
        }
    }

    public static double NewtonCbrt(double x)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(x);

        if (x == 0.0)
        {
            return 0.0;
        }

        var current = x;
        while (true)
        {
            // 公式は以下の式だが、桁落ちによる精度低下を避けるため、変形した式を使用
            //var next = current - (current * current * current - x) / (3.0 * current * current);
            var next = (2.0 * current + x / (current * current)) / 3.0;

            if (Math.Abs(next - current) < 1e-15)
            {
                return next;
            }

            current = next;
        }
    }

    public static double Simpson(Func<double, double> f, double a, double b)
    {
        var current = Simpson(f, a, b, 1);
        for (var n = 2;; n *= 2)
        {
            var next = Simpson(f, a, b, n);

            if (Math.Abs(next - current) < 1e-13)
            {
                return next;
            }

            current = next;
        }
    }

    private static double Simpson(Func<double, double> f, double a, double b, int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);

        var h = (b - a) / n;

        // 奇数項(Σf(x_odd))
        var oddSum = 0.0;
        for (var i = 1; i < n; i += 2)
        {
            oddSum += f(a + i * h);
        }

        // 偶数項(Σf(x_even))
        var evenSum = 0.0;
        for (var i = 2; i < n; i += 2)
        {
            evenSum += f(a + i * h);
        }

        // h / 3 * [f(a) + 4 * Σf(x_odd) + 2 * Σf(x_even) + f(b)]
        return h / 3.0 * (f(a) + 4.0 * oddSum + 2.0 * evenSum + f(b));
    }

    public static double Euler(Func<double, double, double> f, double y0, double x0, double xn, double h)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(h);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(xn, x0);

        var y = y0;
        var n = (int)Math.Round((xn - x0) / h);
        for (var i = 0; i < n; i++)
        {
            var x = x0 + i * h;

            y += h * f(x, y);
        }

        return y;
    }

    public static double RungeKutta(Func<double, double, double> f, double y0, double x0, double xn, double h)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(h);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(xn, x0);

        var y = y0;
        var n = (int)Math.Round((xn - x0) / h);
        for (var i = 0; i < n; i++)
        {
            var x = x0 + i * h;

            var k1 = f(x, y);
            var k2 = f(x + h / 2.0, y + k1 * h / 2.0);
            var k3 = f(x + h / 2.0, y + k2 * h / 2.0);
            var k4 = f(x + h, y + k3 * h);

            y += (h / 6.0) * (k1 + 2.0 * k2 + 2.0 * k3 + k4);
        }

        return y;
    }

    public static int Fibonacci(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        return n switch
        {
            0 or 1 => n,
            _ => Fibonacci(n - 1) + Fibonacci(n - 2),
        };
    }

    public static int Ackermann(int m, int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(m);
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        return (m, n) switch
        {
            (0, _) => n + 1,
            (_, 0) => Ackermann(m - 1, 1),
            _ => Ackermann(m - 1, Ackermann(m, n - 1)),
        };
    }
}
