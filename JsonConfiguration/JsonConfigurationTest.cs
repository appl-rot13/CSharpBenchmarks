using System.Text;
using Shouldly;

[TestClass]
public class JsonConfigurationTest
{
    [TestMethod]
    public void DefaultValueTest()
    {
        var json =
            """
            {
              "Key1": ["Value1"],
              "Key3": ["Value3"]
            }
            """;

        var config = CreateConfig<DefaultConfig>(json);

        config.Key1.ShouldBe(["Value1"]);
        config.Key2.ShouldBeNull();
        config.Key3.ShouldBe(["Value3"]);
        config.Key4.ShouldBeEmpty();
    }

    [TestMethod]
    public void ValueStringTest()
    {
        var json =
            """
            {
              "Key": ["1", 2, "Value3"]
            }
            """;

        var valueConfig = CreateConfig<ValueConfig>(json);
        var stringConfig = CreateConfig<StringConfig>(json);

        valueConfig.Key.ShouldBe([1, 2]);
        stringConfig.Key.ShouldBe(["1", "2", "Value3"]);
    }

    [TestMethod]
    public void MixedTypeTest()
    {
        var json =
            """
            {
              "Key": [
                "Value1",
                {
                  "Enabled": false,
                  "Value": "Value2"
                },
                "Value3",
                {
                  "Enabled": true,
                  "Value": "Value4"
                }
              ]
            }
            """;

        var stringConfig = CreateConfig<StringConfig>(json);
        var objectConfig = CreateConfig<ObjectConfig>(json);

        stringConfig.Key.ShouldBe(["Value1", "Value3"]);
        objectConfig.Key.ShouldBe([
            new ConfigValue { Enabled = false, Value = "Value2" },
            new ConfigValue { Enabled =  true, Value = "Value4" },
        ]);
    }

    private static TValue CreateConfig<TValue>(string json)
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        return JsonConfiguration.Load<TValue>(stream);
    }

    private class DefaultConfig
    {
        public required IReadOnlyCollection<string> Key1 { get; init; }

        public required IReadOnlyCollection<string> Key2 { get; init; }

        public IReadOnlyCollection<string> Key3 { get; init; } = [];

        public IReadOnlyCollection<string> Key4 { get; init; } = [];
    }

    private class ValueConfig
    {
        public IReadOnlyCollection<int> Key { get; init; } = [];
    }

    private class StringConfig
    {
        public IReadOnlyCollection<string> Key { get; init; } = [];
    }

    private class ObjectConfig
    {
        public IReadOnlyCollection<ConfigValue> Key { get; init; } = [];
    }

    private record ConfigValue
    {
        public required bool Enabled { get; init; }

        public required string Value { get; init; }
    }
}
