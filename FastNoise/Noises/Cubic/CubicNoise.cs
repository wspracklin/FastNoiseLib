using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises
{
    public class CubicNoise : INoise
    {
        private readonly INoiseSettings _settings;

        private const double CUBIC_2D_BOUNDING = 1 / (1.5 * 1.5);
        private const double CUBIC_3D_BOUNDING = 1 / (1.5 * 1.5 * 1.5);

        public CubicNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public double GetNoise(Vector2 vec)
        {
            var x = vec.x * _settings.Frequency;
            var y = vec.y * _settings.Frequency;

            int x1 = NoiseHelper.FastFloor(x);
            int y1 = NoiseHelper.FastFloor(y);

            int x0 = x1 - 1;
            int y0 = y1 - 1;
            int x2 = x1 + 1;
            int y2 = y1 + 1;
            int x3 = x1 + 2;
            int y3 = y1 + 2;

            double xs = x - (double)x1;
            double ys = y - (double)y1;

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
                       ys) * CUBIC_2D_BOUNDING;
        }

        public double GetNoise(Vector3 vec)
        {
            var x = vec.x * _settings.Frequency;
            var y = vec.y * _settings.Frequency;
            var z = vec.z * _settings.Frequency;

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

            double xs = x - (double)x1;
            double ys = y - (double)y1;
            double zs = z - (double)z1;

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
                zs) * CUBIC_3D_BOUNDING;
        }
    }
}
