using FastNoise.Interpolators;
using FastNoise.Noises;

namespace FastNoise.Settings
{
    public class DefaultSettings : INoiseSettings
    {
        public DefaultSettings()
        {
            Seed = 1337;
            Octaves = 3;
            Frequency = 0.01f;
            Lacunarity = 2;
            Gain = 2;
            FractalBounding = 0.0f;

            F2 = 1.0f / 2.0f;
            G2 = 1.0f / 4.0f;

            F3 = 1.0f / 3.0f;
            G3 = 1.0f / 6.0f;
            G33 = G3 * 3 - 1;
            CellularJitter = 0.45f;
        }

        public int Seed { get; set; }
        public int Octaves { get; set; }
        public double CellularJitter { get; set; }
        public double Frequency { get; set; }
        public double Lacunarity { get; set; }
        public double Gain { get; set; }
        public double FractalBounding { get; set; }
        public double F2 { get; set; }
        public double G2 { get; set; }
        public double F3 { get; set; }
        public double G3 { get; set; }
        public double G33 { get; set; }
        public INoise Noise { get; set; }
        public IInterpolator Interpolator { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
    }
}
