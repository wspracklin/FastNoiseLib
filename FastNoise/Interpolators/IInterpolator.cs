using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Interpolators
{
    public interface IInterpolator
    {
        Vector3 Interpolate(Vector3 vec1, Vector3 vec2);
    }
}
