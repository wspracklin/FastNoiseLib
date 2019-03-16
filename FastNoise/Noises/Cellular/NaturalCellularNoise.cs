using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises.Cellular
{
    public class NaturalCellularNoise : INoise
    {
        private INoiseSettings _settings;

        public NaturalCellularNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public double GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public double GetNoise(Vector3 vec)
        {
            throw new NotImplementedException();
        }
    }
}
