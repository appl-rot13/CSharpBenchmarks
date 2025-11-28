
public partial class NumericalAnalysis
{
    public static double[] GaussianElimination(double[,] matrix)
    {
        var n = matrix.GetLength(0);
        var m = matrix.GetLength(1);

        if (m != n + 1)
        {
            throw new ArgumentException("The matrix size must be n x (n + 1).", nameof(matrix));
        }

        // 前進消去(上三角行列に変換)
        for (var k = 0; k < n - 1; k++)
        {
            // 部分ピボット選択
            Pivoting(matrix, k);

            // k列でk行より下の行列値を消去
            for (var i = k + 1; i < n; i++)
            {
                var uk = matrix[i, k] / matrix[k, k];
                for (var j = k; j < m; j++)
                {
                    matrix[i, j] -= uk * matrix[k, j];
                }
            }
        }

        // 後退代入
        var x = new double[n];
        for (var i = n - 1; i >= 0; i--)
        {
            // 既に算出済みの解を用いてi行左辺の定数項を算出
            var sum = 0.0;
            for (var j = i + 1; j < n; j++)
            {
                sum += matrix[i, j] * x[j];
            }

            // i行i列の係数とi行の右辺定数項、先に求めた左辺定数項からi行の解を算出
            x[i] = (matrix[i, n] - sum) / matrix[i, i];
        }

        return x;
    }

    public static double[] GaussJordanElimination(double[,] matrix)
    {
        var n = matrix.GetLength(0);
        var m = matrix.GetLength(1);

        if (m != n + 1)
        {
            throw new ArgumentException("The matrix size must be n x (n + 1).", nameof(matrix));
        }

        for (var k = 0; k < n; k++)
        {
            // 部分ピボット選択
            Pivoting(matrix, k);

            // k行k列を1に正規化
            var pivotValue = matrix[k, k];
            for (var j = k; j < m; j++)
            {
                matrix[k, j] /= pivotValue;
            }

            // k列でk行以外の行列値を消去
            for (var i = 0; i < n; i++)
            {
                if (i == k)
                {
                    continue;
                }

                var uk = matrix[i, k];
                for (var j = k; j < m; j++)
                {
                    matrix[i, j] -= uk * matrix[k, j];
                }
            }
        }

        var x = new double[n];
        for (var i = 0; i < n; i++)
        {
            x[i] = matrix[i, n];
        }

        return x;
    }

    private static void Pivoting(double[,] matrix, int k)
    {
        var n = matrix.GetLength(0);
        var m = matrix.GetLength(1);

        // k列で絶対値が最大の行を検索
        var maxIndex = k;
        var maxValue = Math.Abs(matrix[k, k]);
        for (var i = k + 1; i < n; i++)
        {
            var value = Math.Abs(matrix[i, k]);
            if (value <= maxValue)
            {
                continue;
            }

            maxIndex = i;
            maxValue = value;
        }

        if (k != maxIndex)
        {
            // k列で絶対値が最大の行とk行を入れ替え
            for (int j = 0; j < m; j++)
            {
                (matrix[maxIndex, j], matrix[k, j]) = (matrix[k, j], matrix[maxIndex, j]);
            }
        }
    }
}
