namespace FastNoise
{
    public interface INoise
    {
        float GetNoise(Vector2 vec);
        float GetNoise(Vector3 vec);
    }
}
