using Microsoft.Extensions.Configuration;

public static class JsonConfiguration
{
    public static TValue Load<TValue>(Stream stream)
    {
        var value = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build()
            .Get<TValue>();

        return value ?? throw new InvalidOperationException();
    }
}
