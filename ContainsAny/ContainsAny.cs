
using System.Buffers;

public class ContainsAny
{
    public static bool WithLinq(string source, IEnumerable<string> keywords, StringComparison comparisonType)
    {
        return keywords.Any(keyword => source.Contains(keyword, comparisonType));
    }

    public static bool WithSpan(string source, ReadOnlySpan<string> keywords, StringComparison comparisonType)
    {
        return source.AsSpan().ContainsAny(SearchValues.Create(keywords, comparisonType));
    }

    public static bool WithSpanPrepared(string source, SearchValues<string> values)
    {
        return source.AsSpan().ContainsAny(values);
    }
}
