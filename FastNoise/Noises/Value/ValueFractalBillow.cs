﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises.Value
{
    public class ValueFractalBillow : INoise
    {
        private INoiseSettings _settings;

        public ValueFractalBillow(INoiseSettings settings)
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
