using System;
using FastNoise.Interpolators;

namespace FastNoise.Noises
{
    public class PerlinFractalRigidMulti : INoise
    {
        private readonly IInterpolator _interpolator;
        private readonly INoiseSettings _noiseSettings;
        private readonly PerlinNoise _perlinNoise;

        public PerlinFractalRigidMulti(IInterpolator interpolator, INoiseSettings noiseSettings)
        {
            _interpolator = interpolator;
            _noiseSettings = noiseSettings;
            _perlinNoise = new PerlinNoise(_interpolator, _noiseSettings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = 1 - Math.Abs(_perlinNoise.GetNoise(vec));
            double amp = 1;

            var originalSeed = _noiseSettings.Seed;

            try
            {
                for (int i = 1; i < _noiseSettings.Octaves; i++)
                {
                    vec *= _noiseSettings.Lacunarity;

                    amp *= _noiseSettings.Gain;
                    _noiseSettings.Seed++;
                    sum -= (1 - Math.Abs(_perlinNoise.GetNoise(vec))) * amp;
                }
            }
            finally
            {
                _noiseSettings.Seed = originalSeed;
            }

            return sum;
        }

        public double GetNoise(Vector3 vec)
        {
            double sum = 1 - Math.Abs(_perlinNoise.GetNoise(vec));
            double amp = 1;

            var originalSeed = _noiseSettings.Seed;

            try
            {
                for (int i = 1; i < _noiseSettings.Octaves; i++)
                {
                    vec *= _noiseSettings.Lacunarity;

                    amp *= _noiseSettings.Gain;
                    _noiseSettings.Seed++;
                    sum -= (1 - Math.Abs(_perlinNoise.GetNoise(vec))) * amp;
                }
            }
            finally
            {
                _noiseSettings.Seed = originalSeed;
            }

            return sum;
        }
    }
}
