using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Interpolators
{
    public class LinearInterpolator : IInterpolator
    {
        public Vector3 Interpolate(Vector3 vec1, Vector3 vec2)
        {
            return vec1 - vec2;
        }
    }
}
