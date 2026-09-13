using Lodestar.Standard.V1.Packages;
using Lodestar.Standard.V1.Providers;
using Lodestar.Standard.V1.Routing;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Effects;
using Lodestar.Standard.V1.Sources;
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

    [Fact]
    public void ReusableAssetsExposeSharedMetadata()
    {
        Assert.NotNull(typeof(IInstrumentDefinition).GetProperty(nameof(IInstrumentDefinition.Metadata)));
        Assert.NotNull(typeof(IPerformanceDefinition).GetProperty(nameof(IPerformanceDefinition.Metadata)));
        Assert.NotNull(typeof(ISourcePresetDefinition).GetProperty(nameof(ISourcePresetDefinition.Metadata)));
        Assert.NotNull(typeof(IEffectPresetDefinition).GetProperty(nameof(IEffectPresetDefinition.Metadata)));
        Assert.NotNull(typeof(IEffectChainDefinition).GetProperty(nameof(IEffectChainDefinition.Metadata)));
    }

    [Fact]
    public void PresetsIdentifyExactlyOneProvider()
    {
        Assert.Equal(typeof(ProviderId), typeof(ISourcePresetDefinition).GetProperty(nameof(ISourcePresetDefinition.ProviderId))!.PropertyType);
        Assert.Equal(typeof(ProviderId), typeof(IEffectPresetDefinition).GetProperty(nameof(IEffectPresetDefinition.ProviderId))!.PropertyType);
    }
}
