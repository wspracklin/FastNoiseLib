namespace FastNoise.Noises
{
    public interface INoise
    {
        double GetNoise(int seed, Vector2 vec);
        double GetNoise(int seed, Vector3 vec);
    }
}
