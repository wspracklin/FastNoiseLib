using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises.Simplex
{
    public class SimplexFractalFBM : INoise
    {
        private INoiseSettings _settings;

        public SimplexFractalFBM(INoiseSettings settings)
        {
            _settings = settings;
        }

        public double GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public double GetNoise(Vector3 vec)
        {
            var x = vec.x;
            var y = vec.y;
            var z = vec.z;

            double sum = new SimplexNoise(_settings).GetNoise(vec);
            double amp = 1;

            var originalSeed = _settings.Seed;

            for (int i = 1; i < _settings.Octaves; i++)
            {
                vec *= _settings.Lacunarity;
                amp *= _settings.Gain;
                _settings.Seed++;
                sum += new SimplexNoise(_settings).GetNoise(vec) * amp;
            }

            _settings.Seed = originalSeed;

            return sum * _settings.FractalBounding;
        }
    }
}
