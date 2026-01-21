using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastNoise.Noises
{
    public class WhiteNoise : INoise
    {
        private readonly INoiseSettings _settings;

        public WhiteNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public double GetNoise(Vector2 vec)
        {
            int xi = NoiseHelper.FloatCast2Int(vec.x);
            int yi = NoiseHelper.FloatCast2Int(vec.y);

            return NoiseHelper.ValCoord2D(_settings.Seed, xi, yi);
        }

        public double GetNoise(Vector3 vec)
        {
            int xi = NoiseHelper.FloatCast2Int(vec.x);
            int yi = NoiseHelper.FloatCast2Int(vec.y);
            int zi = NoiseHelper.FloatCast2Int(vec.z);

            return NoiseHelper.ValCoord3D(_settings.Seed, xi, yi, zi);
        }
    }
}
