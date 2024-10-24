
public class CompareByteArray
{
    public static bool CompareWithForLoop(byte[] first, byte[] second)
    {
        if (first.Length != second.Length)
        {
            return false;
        }

        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool CompareWithSequenceEqual(byte[] first, byte[] second)
    {
        return first.SequenceEqual(second);
    }

    public static bool CompareCastToReadOnlySpan(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
    {
        return first.SequenceEqual(second);
    }

    public static bool CompareCastToSpan(Span<byte> first, Span<byte> second)
    {
        return first.SequenceEqual(second);
    }

    public static bool CompareAsSpan(byte[] first, byte[] second)
    {
        return first.AsSpan().SequenceEqual(second.AsSpan());
    }
}
