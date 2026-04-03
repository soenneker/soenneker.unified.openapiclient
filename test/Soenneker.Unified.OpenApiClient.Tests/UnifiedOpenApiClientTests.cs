using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Unified.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class UnifiedOpenApiClientTests : FixturedUnitTest
{
    public UnifiedOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
