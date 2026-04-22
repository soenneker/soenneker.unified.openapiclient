using Soenneker.Tests.HostedUnit;

namespace Soenneker.Unified.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class UnifiedOpenApiClientTests : HostedUnitTest
{
    public UnifiedOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
