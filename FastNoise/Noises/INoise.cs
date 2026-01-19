namespace FastNoise.Noises
{
    public interface INoise
    {
        double GetNoise(Vector2 vec);
        double GetNoise(Vector3 vec);
    }
}
