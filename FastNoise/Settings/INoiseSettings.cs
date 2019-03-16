using FastNoise.Interpolators;
using FastNoise.Noises;

namespace FastNoise
{
    public interface INoiseSettings
    {
        int Seed { get; set; }
        int Octaves { get; set; }
        float Frequency { get; set; }
        float Lacunarity { get; set; }
        float Gain { get; set; }
        float FractalBounding { get; set; }

        float F3 { get; set; }
        float G3 { get; set; }
        float G33 { get; set; }

        INoise Noise { get; set; }
        IInterpolator Interpolator { get; set; }

        int SizeX { get; set; }
        int SizeY { get; set; }
        int SizeZ { get; set; }
    }
}
