namespace FastNoise.Noises
{
    public class CubicFractalFBM : INoise
    {
        private readonly INoiseSettings _settings;
        private readonly CubicNoise _cubicNoise;

        public CubicFractalFBM(INoiseSettings settings)
        {
            _settings = settings;
            _cubicNoise = new CubicNoise(settings);
        }

        public double GetNoise(Vector2 vec)
        {
            double sum = _cubicNoise.GetNoise(vec);
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += _cubicNoise.GetNoise(vec) * amp;
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
            double sum = _cubicNoise.GetNoise(vec);
            double amp = 1;

            var originalSeed = _settings.Seed;

            try
            {
                for (int i = 1; i < _settings.Octaves; i++)
                {
                    vec *= _settings.Lacunarity;
                    amp *= _settings.Gain;
                    _settings.Seed++;
                    sum += _cubicNoise.GetNoise(vec) * amp;
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
