using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Interpolators
{
    public class QuinticInterpolator : IInterpolator
    {
        public Vector3 Interpolate(Vector3 vec1, Vector3 vec2)
        {
            var x = InterpQuinticFunc(vec1.x - vec2.x);
            var y = InterpQuinticFunc(vec1.y - vec2.y);
            var z = InterpQuinticFunc(vec1.z - vec2.z);

            return new Vector3(x, y, z);
        }

        private static double InterpQuinticFunc(double t) { return t * t * t * (t * (t * 6 - 15) + 10); }
    }
}
