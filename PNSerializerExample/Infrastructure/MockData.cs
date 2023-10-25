using AutoFixture;

namespace PNSerializerExample.Infrastructure;

public static class MockData
{
    private static readonly Fixture Fixture = new();

    public static T Get<T>() where T : class
    {
        return Fixture.Create<T>();
    }
}