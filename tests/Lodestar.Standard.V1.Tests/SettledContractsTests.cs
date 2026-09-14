using Lodestar.Standard.V1.Packages;
using Lodestar.Standard.V1.Providers;
using Lodestar.Standard.V1.Routing;
using Lodestar.Standard.V1.Assets;
using Lodestar.Standard.V1.Effects;
using Lodestar.Standard.V1.Events;
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

    [Fact]
    public void PerformanceOwnsMixerMasterAndOutputConfiguration()
    {
        Assert.NotNull(typeof(IPerformanceDefinition).GetProperty(nameof(IPerformanceDefinition.Mixer)));
        Assert.NotNull(typeof(IPerformanceDefinition).GetProperty(nameof(IPerformanceDefinition.MasterChannel)));
        Assert.NotNull(typeof(IPerformanceDefinition).GetProperty(nameof(IPerformanceDefinition.OutputConfiguration)));
    }

    [Fact]
    public void PackageManifestExposesAssetsAndResources()
    {
        Assert.NotNull(typeof(IPackageManifest).GetProperty(nameof(IPackageManifest.Assets)));
        Assert.NotNull(typeof(IPackageManifest).GetProperty(nameof(IPackageManifest.Resources)));
    }

    [Fact]
    public void SourceAndEffectDefinitionsBothHaveStableIdentity()
    {
        Assert.NotNull(typeof(ISourceDefinition).GetProperty(nameof(ISourceDefinition.Id)));
        Assert.NotNull(typeof(IEffectDefinition).GetProperty(nameof(IEffectDefinition.Id)));
    }

    [Fact]
    public void AdoptedRoutingAndEffectDefaultsAreStable()
    {
        Assert.Equal(SendTap.PostFader, RoutingDefaults.DefaultSendTap);
        Assert.NotNull(typeof(IInsertSlotDefinition).GetProperty(nameof(IInsertSlotDefinition.WetDry)));
    }

    [Fact]
    public void PerformanceHasOnePortableMainOutput()
    {
        Assert.NotNull(typeof(IOutputConfigurationDefinition).GetProperty(nameof(IOutputConfigurationDefinition.MasterOutputId)));
        Assert.Null(typeof(IPerformanceDefinition).GetProperty("SequenceTempoState"));
    }

    [Fact]
    public void AutomationHasRequiredPortableInterpolationModes()
    {
        Assert.Equal(new[] { "Step", "Linear" }, Enum.GetNames<AutomationInterpolation>());
        Assert.NotNull(typeof(IParameterDescriptor).GetProperty(nameof(IParameterDescriptor.Unit)));
        Assert.NotNull(typeof(IParameterDescriptor).GetProperty(nameof(IParameterDescriptor.DisplayName)));
        Assert.NotNull(typeof(IParameterDescriptor).GetProperty(nameof(IParameterDescriptor.Automatable)));
        Assert.NotNull(typeof(IParameterDescriptor).GetProperty(nameof(IParameterDescriptor.ProviderDefinedInterpolationIds)));
    }

    [Fact]
    public void PackageVersionsAndDependenciesUseLogicalPackageVersionNames()
    {
        Assert.NotNull(typeof(IPackageManifest).GetProperty(nameof(IPackageManifest.PackageVersion)));
        Assert.NotNull(typeof(IPackageDependency).GetProperty(nameof(IPackageDependency.PackageVersion)));
        Assert.Null(typeof(IPackageDependency).GetProperty("Required"));
    }

    [Fact]
    public void DeterministicOfflineRenderingHasStableCapabilityName()
    {
        Assert.Equal("deterministicOfflineRendering", StandardCapabilities.DeterministicOfflineRendering);
    }
}
