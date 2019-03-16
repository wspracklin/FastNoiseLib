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
        public float GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public float GetNoise(Vector3 vec)
        {
            var seed = _noiseSettings.Seed;

            float sum = new ValueNoise(_interpolator, _noiseSettings).GetNoise(vec);

            float amp = 1;

            var originalSeed = _noiseSettings.Seed;

            for (int i = 1; i < _noiseSettings.Octaves; i++)
            {
                vec *= _noiseSettings.Lacunarity;
                amp *= _noiseSettings.Gain;
                _noiseSettings.Seed++;
                sum += new ValueNoise(_interpolator, _noiseSettings).GetNoise(vec) * amp;
            }

            _noiseSettings.Seed = originalSeed;

            return sum * _noiseSettings.FractalBounding;
        }
    }
}
