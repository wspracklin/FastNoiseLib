using System;
using FastNoise.Interpolators;

namespace FastNoise.Noises
{
    public class PerlinFractalBillow : INoise
    {
        private readonly IInterpolator _interpolator;
        private readonly INoiseSettings _noiseSettings;
        private readonly PerlinNoise _perlinNoise;

        public PerlinFractalBillow(IInterpolator interpolator, INoiseSettings noiseSettings)
        {
            _interpolator = interpolator;
            _noiseSettings = noiseSettings;
            _perlinNoise = new PerlinNoise(_interpolator, _noiseSettings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = Math.Abs(_perlinNoise.GetNoise(vec)) * 2 - 1;
            double amp = 1;

            var originalSeed = _noiseSettings.Seed;

            try
            {
                for (int i = 1; i < _noiseSettings.Octaves; i++)
                {
                    vec *= _noiseSettings.Lacunarity;
                    amp *= _noiseSettings.Gain;
                    _noiseSettings.Seed++;
                    sum += (Math.Abs(_perlinNoise.GetNoise(vec)) * 2 - 1) * amp;
                }
            }
            finally
            {
                _noiseSettings.Seed = originalSeed;
            }

            return sum * _noiseSettings.FractalBounding;
        }

        public double GetNoise(Vector3 vec)
        {
            double sum = Math.Abs(_perlinNoise.GetNoise(vec)) * 2 - 1;
            double amp = 1;

            var originalSeed = _noiseSettings.Seed;

            try
            {
                for (int i = 1; i < _noiseSettings.Octaves; i++)
                {
                    vec *= _noiseSettings.Lacunarity;
                    amp *= _noiseSettings.Gain;
                    _noiseSettings.Seed++;
                    sum += (Math.Abs(_perlinNoise.GetNoise(vec)) * 2 - 1) * amp;
                }
            }
            finally
            {
                _noiseSettings.Seed = originalSeed;
            }

            return sum * _noiseSettings.FractalBounding;
        }
    }
}
