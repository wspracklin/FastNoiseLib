namespace FastNoise.Settings
{
    public class DefaultSettings : INoiseSettings
    {
        public DefaultSettings()
        {
            Seed = 1337;
            Octaves = 3;
            Frequency = 0.01;
            Lacunarity = 2;
            Gain = 2;
            FractalBounding = 0.0;
        }

        public int Seed { get; set; }
        public int Octaves { get; set; }
        public double Frequency { get; set; }
        public double Lacunarity { get; set; }
        public double Gain { get; set; }
        public double FractalBounding { get; set; }
    }
}
