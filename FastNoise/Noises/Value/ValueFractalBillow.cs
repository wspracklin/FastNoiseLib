using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise
{
    public class ValueFractalBillow : INoise
    {
        private INoiseSettings _settings;

        public ValueFractalBillow(INoiseSettings settings)
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
