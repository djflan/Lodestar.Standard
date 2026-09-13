using Lodestar.Standard.V1.Packages;
using Lodestar.Standard.V1.Providers;
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

    [Fact]
    public void MixerScopesRemainInstrumentAndPerformance()
    {
        Assert.Equal(new[] { "Instrument", "Performance" }, Enum.GetNames<MixerScope>());
    }

    [Fact]
    public void ProviderRolesRemainSourceAndEffect()
    {
        Assert.Equal(new[] { "Source", "Effect" }, Enum.GetNames<ProviderRole>());
    }

    [Fact]
    public void ContractNamespaceVersionAndPackageStandardVersionAreDistinct()
    {
        Assert.Equal("1-draft", StarPackage.StandardVersion);
        Assert.Equal(".star", StarPackage.FileExtension);
    }
}
