using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises
{
    public class SimplexFractalBillow : INoise
    {
        private readonly INoiseSettings _settings;
        private readonly SimplexNoise _simplexNoise;

        public SimplexFractalBillow(INoiseSettings settings)
        {
            _settings = settings;
            _simplexNoise = new SimplexNoise(settings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = Math.Abs(_simplexNoise.GetNoise(vec)) * 2 - 1;
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += (Math.Abs(_simplexNoise.GetNoise(vec)) * 2 - 1) * amp;
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
            double sum = Math.Abs(_simplexNoise.GetNoise(vec)) * 2 - 1;
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += (Math.Abs(_simplexNoise.GetNoise(vec)) * 2 - 1) * amp;
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
