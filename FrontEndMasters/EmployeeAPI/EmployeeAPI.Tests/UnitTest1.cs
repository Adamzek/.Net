
namespace EmployeeAPI.Tests;

public class UnitTest1
{
    [Fact]
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
    private readonly WebApplicationFactory<Program> _factory;

    public BasicTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    }
}
