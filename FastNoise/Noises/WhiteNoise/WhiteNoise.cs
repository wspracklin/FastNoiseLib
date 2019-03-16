using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastNoise
{
    public class WhiteNoise : INoise
    {
        private INoiseSettings _settings;

        public WhiteNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public float GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public float GetNoise(Vector3 vec)
        {
            int xi = NoiseHelper.FloatCast2Int(vec.x);
            int yi = NoiseHelper.FloatCast2Int(vec.y);
            int zi = NoiseHelper.FloatCast2Int(vec.z);

            return NoiseHelper.ValCoord3D(_settings.Seed, xi, yi, zi);
        }
    }
}
