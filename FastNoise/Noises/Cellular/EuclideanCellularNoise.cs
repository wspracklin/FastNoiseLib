using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises.Cellular
{
    public class EuclideanCellularNoise : INoise
    {
        private INoiseSettings _settings;

        public EuclideanCellularNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public float GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public float GetNoise(Vector3 vec)
        {
            throw new NotImplementedException();
        }
    }
}
