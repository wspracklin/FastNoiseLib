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
        public double GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public double GetNoise(Vector3 vec)
        {
            var seed = _noiseSettings.Seed;

            double sum = new ValueNoise(_interpolator, _noiseSettings).GetNoise(vec);

            double amp = 1;

            for (int i = 1; i < _noiseSettings.Octaves; i++)
            {
                vec *= _noiseSettings.Lacunarity;
                amp *= _noiseSettings.Gain;
                _noiseSettings.Seed++;
                sum += new ValueNoise(_interpolator, _noiseSettings).GetNoise(vec) * amp;
                _noiseSettings.Seed--;
            }

            return sum * _noiseSettings.FractalBounding;
        }
    }
}
