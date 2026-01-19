using System;

namespace FastNoise.Noises
{
    public class ManhattanCellularNoise : INoise
    {
        private readonly INoiseSettings _settings;

        public ManhattanCellularNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public double GetNoise(Vector2 vec)
        {
            var x = vec.x * _settings.Frequency;
            var y = vec.y * _settings.Frequency;

            int xr = NoiseHelper.FastRound(x);
            int yr = NoiseHelper.FastRound(y);

            double distance = 999999;
            int xc = 0, yc = 0;

            for (int xi = xr - 1; xi <= xr + 1; xi++)
            {
                for (int yi = yr - 1; yi <= yr + 1; yi++)
                {
                    Vector2 vec2 = NoiseHelper.CELL_2D[NoiseHelper.Hash2D(_settings.Seed, xi, yi) & 255];

                    double vecX = xi - x + vec2.x * _settings.CellularJitter;
                    double vecY = yi - y + vec2.y * _settings.CellularJitter;

                    double newDistance = Math.Abs(vecX) + Math.Abs(vecY);

                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        xc = xi;
                        yc = yi;
                    }
                }
            }

            return distance;
        }

        public double GetNoise(Vector3 vec)
        {
            var x = vec.x * _settings.Frequency;
            var y = vec.y * _settings.Frequency;
            var z = vec.z * _settings.Frequency;

            int xr = NoiseHelper.FastRound(x);
            int yr = NoiseHelper.FastRound(y);
            int zr = NoiseHelper.FastRound(z);

            double distance = 999999;

            for (int xi = xr - 1; xi <= xr + 1; xi++)
            {
                for (int yi = yr - 1; yi <= yr + 1; yi++)
                {
                    for (int zi = zr - 1; zi <= zr + 1; zi++)
                    {
                        Vector3 vec3 = NoiseHelper.CELL_3D[NoiseHelper.Hash3D(_settings.Seed, xi, yi, zi) & 255];

                        double vecX = xi - x + vec3.x * _settings.CellularJitter;
                        double vecY = yi - y + vec3.y * _settings.CellularJitter;
                        double vecZ = zi - z + vec3.z * _settings.CellularJitter;

                        double newDistance = Math.Abs(vecX) + Math.Abs(vecY) + Math.Abs(vecZ);

                        if (newDistance < distance)
                        {
                            distance = newDistance;
                        }
                    }
                }
            }

            return distance;
        }
    }
}
