namespace Lodestar.Standard.V1.Audio;

/// <summary>Prepared stereo render configuration.</summary>
public readonly struct RenderConfiguration
{
    public RenderConfiguration(double sampleRate, int maximumFrameCount)
    {
        SampleRate = sampleRate;
        MaximumFrameCount = maximumFrameCount;
    }
    public double SampleRate { get; }
    public int MaximumFrameCount { get; }
}

/// <summary>Non-interleaved stereo floating-point buffer boundary.</summary>
public readonly struct StereoBuffer
{
    public StereoBuffer(float[] left, float[] right)
    {
        Left = left;
        Right = right;
    }
    public float[] Left { get; }
    public float[] Right { get; }
}
