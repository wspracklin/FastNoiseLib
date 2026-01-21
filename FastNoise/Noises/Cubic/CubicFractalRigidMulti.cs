using System;

namespace FastNoise.Noises
{
    public class CubicFractalRigidMulti : INoise
    {
        private readonly INoiseSettings _settings;
        private readonly CubicNoise _cubicNoise;

        public CubicFractalRigidMulti(INoiseSettings settings)
        {
            _settings = settings;
            _cubicNoise = new CubicNoise(settings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = 1 - Math.Abs(_cubicNoise.GetNoise(vec));
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;

                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum -= (1 - Math.Abs(_cubicNoise.GetNoise(vec))) * amp;
                }
            }
            finally
            {
                _settings.Seed = originalSeed;
            }

            return sum;
        }

        public double GetNoise(Vector3 vec)
        {
            double sum = 1 - Math.Abs(_cubicNoise.GetNoise(vec));
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;

                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum -= (1 - Math.Abs(_cubicNoise.GetNoise(vec))) * amp;
                }
            }
            finally
            {
                _settings.Seed = originalSeed;
            }

            return sum;
        }
    }
}
