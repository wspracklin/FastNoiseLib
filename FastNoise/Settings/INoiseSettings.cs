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
    }
}
