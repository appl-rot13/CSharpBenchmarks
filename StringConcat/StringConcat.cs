
using System.Runtime.CompilerServices;
using System.Text;

public class StringConcat
{
    public static string OperatorAggregate(string chars, int[] indexes)
    {
        return indexes.Aggregate(string.Empty, (ret, i) => ret + chars[i - 1]);
    }

    public static string Operator(string chars, int[] indexes)
    {
        var ret = string.Empty;
        foreach (var i in indexes)
        {
            ret += chars[i - 1];
        }

        return ret;
    }

    public static string Concat(string chars, int[] indexes)
    {
        return string.Concat(indexes.Select(i => chars[i - 1]));
    }

    public static string Builder(string chars, int[] indexes)
    {
        var builder = new StringBuilder();
        foreach (var i in indexes)
        {
            builder.Append(chars[i - 1]);
        }

        return builder.ToString();
    }

    public static string BuilderSpecifiedCapacity(string chars, int[] indexes)
    {
        var builder = new StringBuilder(indexes.Length);
        foreach (var i in indexes)
        {
            builder.Append(chars[i - 1]);
        }

        return builder.ToString();
    }

    public static string StringCreate(string chars, int[] indexes)
    {
        return string.Create(
            indexes.Length,
            (chars, indexes),
            (buffer, state) =>
            {
                for (var i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = state.chars[state.indexes[i] - 1];
                }
            });
    }

    public static string DefaultInterpolatedStringHandler(string chars, int[] indexes)
    {
        var builder = new DefaultInterpolatedStringHandler(0, 0);
        foreach (var i in indexes)
        {
            builder.AppendFormatted(chars[i - 1]);
        }

        return builder.ToStringAndClear();
    }
}
