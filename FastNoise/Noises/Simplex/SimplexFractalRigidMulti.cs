using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Simplex
{
    public class SimplexFractalRigidMulti : INoise
    {
        private INoiseSettings _settings;

        public SimplexFractalRigidMulti(INoiseSettings settings)
        {
            _settings = settings;
        }

        public float GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public float GetNoise(Vector3 vec)
        {
            int seed = _settings.Seed;
            float sum = 1 - Math.Abs(new SimplexNoise(_settings).GetNoise(vec));
            float amp = 1;

            var originalSeed = _settings.Seed;

            for (int i = 1; i < _settings.Octaves; i++)
            {
                vec *= _settings.Lacunarity;

                amp *= _settings.Gain;
                _settings.Seed++;
                sum -= (1 - Math.Abs(new SimplexNoise(_settings).GetNoise(vec))) * amp;
            }

            _settings.Seed = originalSeed;

            return sum;
        }
    }
}
