using System;

namespace FastNoise.Noises
{
    public class CubicFractalBillow : INoise
    {
        private readonly INoiseSettings _settings;
        private readonly CubicNoise _cubicNoise;

        public CubicFractalBillow(INoiseSettings settings)
        {
            _settings = settings;
            _cubicNoise = new CubicNoise(settings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = Math.Abs(_cubicNoise.GetNoise(vec)) * 2 - 1;
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += (Math.Abs(_cubicNoise.GetNoise(vec)) * 2 - 1) * amp;
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
            double sum = Math.Abs(_cubicNoise.GetNoise(vec)) * 2 - 1;
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += (Math.Abs(_cubicNoise.GetNoise(vec)) * 2 - 1) * amp;
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
