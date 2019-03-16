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
            F3 = 1.0 / 3.0;
            G3 = 1.0 / 6.0;
            G33 = G3 * 3 - 1;
        }

        public int Seed { get; set; }
        public int Octaves { get; set; }
        public double Frequency { get; set; }
        public double Lacunarity { get; set; }
        public double Gain { get; set; }
        public double FractalBounding { get; set; }
        public double F3 { get; set; }
        public double G3 { get; set; }
        public double G33 { get; set; }

    }
}
