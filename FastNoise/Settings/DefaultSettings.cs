using FastNoise.Interpolators;
using FastNoise;

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
            F3 = 1.0f / 3.0f;
            G3 = 1.0f / 6.0f;
            G33 = G3 * 3 - 1;
        }

        public int Seed { get; set; }
        public int Octaves { get; set; }
        public float Frequency { get; set; }
        public float Lacunarity { get; set; }
        public float Gain { get; set; }
        public float FractalBounding { get; set; }
        public float F3 { get; set; }
        public float G3 { get; set; }
        public float G33 { get; set; }
        public INoise Noise { get; set; }
        public IInterpolator Interpolator { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
    }
}
