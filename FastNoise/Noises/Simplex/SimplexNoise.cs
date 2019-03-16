using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises.Simplex
{
    class SimplexNoise : INoise
    {
        private INoiseSettings _settings;

        public SimplexNoise(INoiseSettings settings)
        {
            _settings = settings;
        }

        public float GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public float GetNoise(Vector3 vec)
        {
            var x = vec.x;
            var y = vec.y;
            var z = vec.z;

            float t = (x + y + z) * _settings.F3;
            int i = NoiseHelper.FastFloor(x + t);
            int j = NoiseHelper.FastFloor(y + t);
            int k = NoiseHelper.FastFloor(z + t);

            t = (i + j + k) * _settings.G3;
            float x0 = x - (i - t);
            float y0 = y - (j - t);
            float z0 = z - (k - t);

            int i1, j1, k1;
            int i2, j2, k2;

            if (x0 >= y0)
            {
                if (y0 >= z0)
                {
                    i1 = 1; j1 = 0; k1 = 0; i2 = 1; j2 = 1; k2 = 0;
                }
                else if (x0 >= z0)
                {
                    i1 = 1; j1 = 0; k1 = 0; i2 = 1; j2 = 0; k2 = 1;
                }
                else // x0 < z0
                {
                    i1 = 0; j1 = 0; k1 = 1; i2 = 1; j2 = 0; k2 = 1;
                }
            }
            else // x0 < y0
            {
                if (y0 < z0)
                {
                    i1 = 0; j1 = 0; k1 = 1; i2 = 0; j2 = 1; k2 = 1;
                }
                else if (x0 < z0)
                {
                    i1 = 0; j1 = 1; k1 = 0; i2 = 0; j2 = 1; k2 = 1;
                }
                else // x0 >= z0
                {
                    i1 = 0; j1 = 1; k1 = 0; i2 = 1; j2 = 1; k2 = 0;
                }
            }

            float x1 = x0 - i1 + _settings.G3;
            float y1 = y0 - j1 + _settings.G3;
            float z1 = z0 - k1 + _settings.G3;
            float x2 = x0 - i2 + _settings.F3;
            float y2 = y0 - j2 + _settings.F3;
            float z2 = z0 - k2 + _settings.F3;
            float x3 = x0 + _settings.G33;
            float y3 = y0 + _settings.G33;
            float z3 = z0 + _settings.G33;

            float n0, n1, n2, n3;

            t = (float)0.6 - x0 * x0 - y0 * y0 - z0 * z0;
            if (t < 0) n0 = 0;
            else
            {
                t *= t;
                n0 = t * t * NoiseHelper.GradCoord3D(_settings.Seed, i, j, k, x0, y0, z0);
            }

            t = (float)0.6 - x1 * x1 - y1 * y1 - z1 * z1;
            if (t < 0) n1 = 0;
            else
            {
                t *= t;
                n1 = t * t * NoiseHelper.GradCoord3D(_settings.Seed, i + i1, j + j1, k + k1, x1, y1, z1);
            }

            t = (float)0.6 - x2 * x2 - y2 * y2 - z2 * z2;
            if (t < 0) n2 = 0;
            else
            {
                t *= t;
                n2 = t * t * NoiseHelper.GradCoord3D(_settings.Seed, i + i2, j + j2, k + k2, x2, y2, z2);
            }

            t = (float)0.6 - x3 * x3 - y3 * y3 - z3 * z3;
            if (t < 0) n3 = 0;
            else
            {
                t *= t;
                n3 = t * t * NoiseHelper.GradCoord3D(_settings.Seed, i + 1, j + 1, k + 1, x3, y3, z3);
            }

            return 32 * (n0 + n1 + n2 + n3);
        }
    }
}
