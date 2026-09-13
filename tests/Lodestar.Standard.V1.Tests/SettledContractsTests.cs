using Lodestar.Standard.V1.Packages;
using Lodestar.Standard.V1.Routing;
using Xunit;

namespace Lodestar.Standard.V1.Tests;

public sealed class SettledContractsTests
{
    [Fact]
    public void StarPackageUsesStarExtension()
    {
        Assert.Equal(".star", StarPackage.FileExtension);
    }

    [Fact]
    public void BusKindsIncludeSubmixAndSend()
    {
        Assert.Equal(new[] { "Submix", "Send" }, Enum.GetNames<BusKind>());
    }
}
