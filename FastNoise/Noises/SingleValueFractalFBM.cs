using FastNoise.Interpolators;
using System;

namespace FastNoise.Noises
{
    public class SingleValueFractalFBM : INoise
    {
        private IInterpolator _interpolator;

        public SingleValueFractalFBM(IInterpolator interpolator)
        {
            _interpolator = interpolator;
        }
        public double GetNoise(int seed, Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public double GetNoise(int seed, Vector3 vec)
        {
            double sum = new SingleValueNoise(_interpolator).GetNoise(seed, vec);

            double amp = 1;

            for (int i = 1; i < NoiseHelper.Octaves; i++)
            {
                vec *= NoiseHelper.Lacunarity;
                amp *= NoiseHelper.Gain;
                sum += new SingleValueNoise(_interpolator).GetNoise(++seed, vec) * amp;
            }

            return sum * NoiseHelper.FractalBounding;
        }
    }
}
