
using System.Security.Cryptography;

public class ComputeHash
{
    private static readonly HashAlgorithm HashAlgorithm = SHA1.Create();

    public static byte[] ComputeHashWithLock(string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            lock (HashAlgorithm)
            {
                return HashAlgorithm.ComputeHash(stream);
            }
        }
    }

    public static byte[] ComputeHashWithoutLock(string filePath)
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (var hashAlgorithm = SHA1.Create())
        {
            return hashAlgorithm.ComputeHash(stream);
        }
    }
}
