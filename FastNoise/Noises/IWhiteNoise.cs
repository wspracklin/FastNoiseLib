namespace FastNoise.Noises
{
    public interface IWhiteNoise
    {
        float GetWhiteNoise(float x, float y, float z, float w);
        float GetWhiteNoise(float x, float y, float z);
        float GetWhiteNoise(float x, float y);
    }
}
