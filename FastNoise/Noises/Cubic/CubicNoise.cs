using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise
{
    public class CubicNoise : INoise
    {
        private INoiseSettings _settings;

        public CubicNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public float GetNoise(Vector2 vec)
        {
            var x = vec.x;
            var y = vec.y;

            int x1 = NoiseHelper.FastFloor(x);
            int y1 = NoiseHelper.FastFloor(y);

            int x0 = x1 - 1;
            int y0 = y1 - 1;
            int x2 = x1 + 1;
            int y2 = y1 + 1;
            int x3 = x1 + 2;
            int y3 = y1 + 2;

            float xs = x - (float)x1;
            float ys = y - (float)y1;

            var seed = _settings.Seed;
            return NoiseHelper.CubicLerp(
                       NoiseHelper.CubicLerp(NoiseHelper.ValCoord2D(seed, x0, y0), NoiseHelper.ValCoord2D(seed, x1, y0), NoiseHelper.ValCoord2D(seed, x2, y0), NoiseHelper.ValCoord2D(seed, x3, y0),
                           xs),
                       NoiseHelper.CubicLerp(NoiseHelper.ValCoord2D(seed, x0, y1), NoiseHelper.ValCoord2D(seed, x1, y1), NoiseHelper.ValCoord2D(seed, x2, y1), NoiseHelper.ValCoord2D(seed, x3, y1),
                           xs),
                       NoiseHelper.CubicLerp(NoiseHelper.ValCoord2D(seed, x0, y2), NoiseHelper.ValCoord2D(seed, x1, y2), NoiseHelper.ValCoord2D(seed, x2, y2), NoiseHelper.ValCoord2D(seed, x3, y2),
                           xs),
                       NoiseHelper.CubicLerp(NoiseHelper.ValCoord2D(seed, x0, y3), NoiseHelper.ValCoord2D(seed, x1, y3), NoiseHelper.ValCoord2D(seed, x2, y3), NoiseHelper.ValCoord2D(seed, x3, y3),
                           xs),
                       ys) * NoiseHelper.Cubic2DBinding;
        }

        public float GetNoise(Vector3 vec)
        {
            var x = vec.x;
            var y = vec.y;
            var z = vec.z;

            int x1 = NoiseHelper.FastFloor(x);
            int y1 = NoiseHelper.FastFloor(y);
            int z1 = NoiseHelper.FastFloor(z);

            int x0 = x1 - 1;
            int y0 = y1 - 1;
            int z0 = z1 - 1;
            int x2 = x1 + 1;
            int y2 = y1 + 1;
            int z2 = z1 + 1;
            int x3 = x1 + 2;
            int y3 = y1 + 2;
            int z3 = z1 + 2;

            float xs = x - (float)x1;
            float ys = y - (float)y1;
            float zs = z - (float)z1;

            var seed = _settings.Seed;

            return NoiseHelper.CubicLerp(
                NoiseHelper.CubicLerp(
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y0, z0), NoiseHelper.ValCoord3D(seed, x1, y0, z0), NoiseHelper.ValCoord3D(seed, x2, y0, z0), NoiseHelper.ValCoord3D(seed, x3, y0, z0), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y1, z0), NoiseHelper.ValCoord3D(seed, x1, y1, z0), NoiseHelper.ValCoord3D(seed, x2, y1, z0), NoiseHelper.ValCoord3D(seed, x3, y1, z0), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y2, z0), NoiseHelper.ValCoord3D(seed, x1, y2, z0), NoiseHelper.ValCoord3D(seed, x2, y2, z0), NoiseHelper.ValCoord3D(seed, x3, y2, z0), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y3, z0), NoiseHelper.ValCoord3D(seed, x1, y3, z0), NoiseHelper.ValCoord3D(seed, x2, y3, z0), NoiseHelper.ValCoord3D(seed, x3, y3, z0), xs),
                ys),
                NoiseHelper.CubicLerp(
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y0, z1), NoiseHelper.ValCoord3D(seed, x1, y0, z1), NoiseHelper.ValCoord3D(seed, x2, y0, z1), NoiseHelper.ValCoord3D(seed, x3, y0, z1), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y1, z1), NoiseHelper.ValCoord3D(seed, x1, y1, z1), NoiseHelper.ValCoord3D(seed, x2, y1, z1), NoiseHelper.ValCoord3D(seed, x3, y1, z1), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y2, z1), NoiseHelper.ValCoord3D(seed, x1, y2, z1), NoiseHelper.ValCoord3D(seed, x2, y2, z1), NoiseHelper.ValCoord3D(seed, x3, y2, z1), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y3, z1), NoiseHelper.ValCoord3D(seed, x1, y3, z1), NoiseHelper.ValCoord3D(seed, x2, y3, z1), NoiseHelper.ValCoord3D(seed, x3, y3, z1), xs),
                ys),
                NoiseHelper.CubicLerp(
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y0, z2), NoiseHelper.ValCoord3D(seed, x1, y0, z2), NoiseHelper.ValCoord3D(seed, x2, y0, z2), NoiseHelper.ValCoord3D(seed, x3, y0, z2), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y1, z2), NoiseHelper.ValCoord3D(seed, x1, y1, z2), NoiseHelper.ValCoord3D(seed, x2, y1, z2), NoiseHelper.ValCoord3D(seed, x3, y1, z2), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y2, z2), NoiseHelper.ValCoord3D(seed, x1, y2, z2), NoiseHelper.ValCoord3D(seed, x2, y2, z2), NoiseHelper.ValCoord3D(seed, x3, y2, z2), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y3, z2), NoiseHelper.ValCoord3D(seed, x1, y3, z2), NoiseHelper.ValCoord3D(seed, x2, y3, z2), NoiseHelper.ValCoord3D(seed, x3, y3, z2), xs),
                ys),
                NoiseHelper.CubicLerp(
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y0, z3), NoiseHelper.ValCoord3D(seed, x1, y0, z3), NoiseHelper.ValCoord3D(seed, x2, y0, z3), NoiseHelper.ValCoord3D(seed, x3, y0, z3), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y1, z3), NoiseHelper.ValCoord3D(seed, x1, y1, z3), NoiseHelper.ValCoord3D(seed, x2, y1, z3), NoiseHelper.ValCoord3D(seed, x3, y1, z3), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y2, z3), NoiseHelper.ValCoord3D(seed, x1, y2, z3), NoiseHelper.ValCoord3D(seed, x2, y2, z3), NoiseHelper.ValCoord3D(seed, x3, y2, z3), xs),
                NoiseHelper.CubicLerp(NoiseHelper.ValCoord3D(seed, x0, y3, z3), NoiseHelper.ValCoord3D(seed, x1, y3, z3), NoiseHelper.ValCoord3D(seed, x2, y3, z3), NoiseHelper.ValCoord3D(seed, x3, y3, z3), xs),
                ys),
                zs) * NoiseHelper.Cubic3DBounding;
        }
    }
}
