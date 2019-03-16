namespace FastNoise
{
    public interface IWhiteNoise
    {
        double GetWhiteNoise(double x, double y, double z, double w);
        double GetWhiteNoise(double x, double y, double z);
        double GetWhiteNoise(double x, double y);
    }
}
