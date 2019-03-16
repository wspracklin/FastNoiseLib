using FastNoise.Interpolators;
using System;

namespace FastNoise.Noises
{
    public class SingleValueFractalFBM : INoise
    {
        private IInterpolator _interpolator;
        private INoiseSettings _noiseSettings;

        public SingleValueFractalFBM(IInterpolator interpolator, INoiseSettings noiseSettings)
        {
            _interpolator = interpolator;
            _noiseSettings = noiseSettings;
        }
        public double GetNoise(int seed, Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public double GetNoise(int seed, Vector3 vec)
        {
            double sum = new SingleValueNoise(_interpolator, _noiseSettings).GetNoise(seed, vec);

            double amp = 1;

            for (int i = 1; i < _noiseSettings.Octaves; i++)
            {
                vec *= _noiseSettings.Lacunarity;
                amp *= _noiseSettings.Gain;
                sum += new SingleValueNoise(_interpolator, _noiseSettings).GetNoise(++seed, vec) * amp;
            }

            return sum * _noiseSettings.FractalBounding;
        }
    }
}
