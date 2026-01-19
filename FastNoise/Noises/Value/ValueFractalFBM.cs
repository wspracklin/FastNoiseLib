using FastNoise.Interpolators;
using System;

namespace FastNoise.Noises
{
    public class ValueFractalFBM : INoise
    {
        private IInterpolator _interpolator;
        private INoiseSettings _noiseSettings;

        public ValueFractalFBM(IInterpolator interpolator, INoiseSettings noiseSettings)
        {
            _interpolator = interpolator;
            _noiseSettings = noiseSettings;
        }
        private readonly ValueNoise _valueNoise;

        public double GetNoise(Vector2 vec)
        {
            double sum = _valueNoise.GetNoise(vec);
            double amp = 1;

            var originalSeed = _noiseSettings.Seed;

            try
            {
                for (int i = 1; i < _noiseSettings.Octaves; i++)
                {
                    vec *= _noiseSettings.Lacunarity;
                    amp *= _noiseSettings.Gain;
                    _noiseSettings.Seed++;
                    sum += _valueNoise.GetNoise(vec) * amp;
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
            double sum = _valueNoise.GetNoise(vec);
            double amp = 1;

            var originalSeed = _noiseSettings.Seed;

            try
            {
                for (int i = 1; i < _noiseSettings.Octaves; i++)
                {
                    vec *= _noiseSettings.Lacunarity;
                    amp *= _noiseSettings.Gain;
                    _noiseSettings.Seed++;
                    sum += _valueNoise.GetNoise(vec) * amp;
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
