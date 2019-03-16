using System;
using System.Runtime.CompilerServices;

namespace FastNoise
{
    public class NoiseHelper
    {
        public const Int16 FN_INLINE = 256;
        public static int Octaves = 3;
        public static double Frequency = 0.01;
        public static double Lacunarity = 2.0;
        public static double Gain = 0.5;
        public static double FractalBounding;

        public const double Cubic3DBounding = 1 / (1.5 * 1.5 * 1.5);
        public const double Cubic2DBinding = 1 / (1.5 * 1.5);

        [MethodImplAttribute(FN_INLINE)]
        public static int FastFloor(double f) { return (f >= 0 ? (int)f : (int)f - 1); }

        [MethodImplAttribute(FN_INLINE)]
        public static int FastRound(double f) { return (f >= 0) ? (int)(f + 0.5) : (int)(f - 0.5); }

        [MethodImplAttribute(FN_INLINE)]
        public static double Lerp(double a, double b, double t) { return a + t * (b - a); }

        [MethodImplAttribute(FN_INLINE)]
        public static double InterpHermiteFunc(double t) { return t * t * (3 - 2 * t); }

        [MethodImplAttribute(FN_INLINE)]
        public static double InterpQuinticFunc(double t) { return t * t * t * (t * (t * 6 - 15) + 10); }

        [MethodImplAttribute(FN_INLINE)]
        public static double CubicLerp(double a, double b, double c, double d, double t)
        {
            double p = (d - c) - (a - b);
            return t * t * t * p + t * t * ((a - b) - p) + t * (c - a) + b;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static Vector3 GetVectorTimesFrequencyFor(Vector3 vec) => new Vector3(vec.x * Frequency, vec.y * Frequency, vec.z * Frequency);

        [MethodImplAttribute(FN_INLINE)]
        public static int FloatCast2Int(double f)
        {
            var i = BitConverter.DoubleToInt64Bits(f);

            return (int)(i ^ (i >> 32));
        }

        private static readonly Vector2[] GRAD_2D = {
        new Vector2(-1,-1), new Vector2( 1,-1), new Vector2(-1, 1), new Vector2( 1, 1),
        new Vector2( 0,-1), new Vector2(-1, 0), new Vector2( 0, 1), new Vector2( 1, 0),
        };

        private static readonly Vector3[] GRAD_3D = {
        new Vector3( 1, 1, 0), new Vector3(-1, 1, 0), new Vector3( 1,-1, 0), new Vector3(-1,-1, 0),
        new Vector3( 1, 0, 1), new Vector3(-1, 0, 1), new Vector3( 1, 0,-1), new Vector3(-1, 0,-1),
        new Vector3( 0, 1, 1), new Vector3( 0,-1, 1), new Vector3( 0, 1,-1), new Vector3( 0,-1,-1),
        new Vector3( 1, 1, 0), new Vector3( 0,-1, 1), new Vector3(-1, 1, 0), new Vector3( 0,-1,-1),
        };

        //public void CalculateFractalBounding()
        //{
        //    double amp = m_gain;
        //    double ampFractal = 1;
        //    for (int i = 1; i < m_octaves; i++)
        //    {
        //        ampFractal += amp;
        //        amp *= m_gain;
        //    }
        //    m_fractalBounding = 1 / ampFractal;
        //}

        // Hashing
        public const int X_PRIME = 1619;
        public const int Y_PRIME = 31337;
        public const int Z_PRIME = 6971;
        public const int W_PRIME = 1013;

        [MethodImplAttribute(FN_INLINE)]
        public static int Hash2D(int seed, int x, int y)
        {
            int hash = seed;
            hash ^= X_PRIME * x;
            hash ^= Y_PRIME * y;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            return hash;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static int Hash3D(int seed, int x, int y, int z)
        {
            int hash = seed;
            hash ^= X_PRIME * x;
            hash ^= Y_PRIME * y;
            hash ^= Z_PRIME * z;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            return hash;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static int Hash4D(int seed, int x, int y, int z, int w)
        {
            int hash = seed;
            hash ^= X_PRIME * x;
            hash ^= Y_PRIME * y;
            hash ^= Z_PRIME * z;
            hash ^= W_PRIME * w;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            return hash;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static double ValCoord2D(int seed, int x, int y)
        {
            int n = seed;
            n ^= X_PRIME * x;
            n ^= Y_PRIME * y;

            return (n * n * n * 60493) / 2147483648.0;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static double ValCoord3D(int seed, int x, int y, int z)
        {
            int n = seed;
            n ^= X_PRIME * x;
            n ^= Y_PRIME * y;
            n ^= Z_PRIME * z;

            return (n * n * n * 60493) / 2147483648.0;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static double ValCoord4D(int seed, int x, int y, int z, int w)
        {
            int n = seed;
            n ^= X_PRIME * x;
            n ^= Y_PRIME * y;
            n ^= Z_PRIME * z;
            n ^= W_PRIME * w;

            return (n * n * n * 60493) / 2147483648.0;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static double GradCoord2D(int seed, int x, int y, double xd, double yd)
        {
            int hash = seed;
            hash ^= X_PRIME * x;
            hash ^= Y_PRIME * y;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            Vector2 g = GRAD_2D[hash & 7];

            return xd * g.x + yd * g.y;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static double GradCoord3D(int seed, int x, int y, int z, double xd, double yd, double zd)
        {
            int hash = seed;
            hash ^= X_PRIME * x;
            hash ^= Y_PRIME * y;
            hash ^= Z_PRIME * z;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            Vector3 g = GRAD_3D[hash & 15];

            return xd * g.x + yd * g.y + zd * g.z;
        }

        [MethodImplAttribute(FN_INLINE)]
        public static double GradCoord4D(int seed, int x, int y, int z, int w, double xd, double yd, double zd, double wd)
        {
            int hash = seed;
            hash ^= X_PRIME * x;
            hash ^= Y_PRIME * y;
            hash ^= Z_PRIME * z;
            hash ^= W_PRIME * w;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            hash &= 31;
            double a = yd, b = zd, c = wd;            // X,Y,Z
            switch (hash >> 3)
            {          // OR, DEPENDING ON HIGH ORDER 2 BITS:
                case 1: a = wd; b = xd; c = yd; break;     // W,X,Y
                case 2: a = zd; b = wd; c = xd; break;     // Z,W,X
                case 3: a = yd; b = zd; c = wd; break;     // Y,Z,W
            }
            return ((hash & 4) == 0 ? -a : a) + ((hash & 2) == 0 ? -b : b) + ((hash & 1) == 0 ? -c : c);
        }
    }
}
