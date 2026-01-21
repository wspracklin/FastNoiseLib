using FastNoise.Interpolators;
using FastNoise.Noises;

namespace FastNoise
{
    public interface INoiseSettings
    {
        int Seed { get; set; }
        int Octaves { get; set; }
        double Frequency { get; set; }
        double Lacunarity { get; set; }
        double Gain { get; set; }
        double FractalBounding { get; set; }

        double F2 { get; set; }
        double G2 { get; set; }

        double F3 { get; set; }
        double G3 { get; set; }
        double G33 { get; set; }

        double CellularJitter { get; set; }

        INoise Noise { get; set; }
        IInterpolator Interpolator { get; set; }

        int SizeX { get; set; }
        int SizeY { get; set; }
        int SizeZ { get; set; }
    }
}
