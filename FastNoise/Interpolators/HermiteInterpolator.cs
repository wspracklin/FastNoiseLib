using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Interpolators
{
    public class HermiteInterpolator : IInterpolator
    {
        public Vector3 Interpolate(Vector3 vec1, Vector3 vec2)
        {
            var x = InterpHermiteFunc(vec1.x - vec2.x);
            var y = InterpHermiteFunc(vec1.y - vec2.y);
            var z = InterpHermiteFunc(vec1.z - vec2.z);

            return new Vector3(x, y, z);
        }

        private static float InterpHermiteFunc(float t) { return t * t * (3 - 2 * t); }
    }
}
