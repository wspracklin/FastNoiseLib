using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises
{
    public class SimplexFractalFBM : INoise
    {
        private readonly INoiseSettings _settings;
        private readonly SimplexNoise _simplexNoise;

        public SimplexFractalFBM(INoiseSettings settings)
        {
            _settings = settings;
            _simplexNoise = new SimplexNoise(settings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = _simplexNoise.GetNoise(vec);
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += _simplexNoise.GetNoise(vec) * amp;
                }
            }
            finally
            {
                _settings.Seed = originalSeed;
            }

            return sum * _settings.FractalBounding;
        }

        public double GetNoise(Vector3 vec)
        {
            double sum = _simplexNoise.GetNoise(vec);
            double amp = 1;

            var originalSeed = _settings.Seed;
            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += _simplexNoise.GetNoise(vec) * amp;
                }
            }
            finally
            {
                _settings.Seed = originalSeed;
            }

            return sum * _settings.FractalBounding;
        }
    }
}
