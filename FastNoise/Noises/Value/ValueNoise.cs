using FastNoise.Interpolators;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise.Noises
{
    public class ValueNoise : INoise
    {
        private IInterpolator _interpolator;
        private INoiseSettings _noiseSettings;

        public ValueNoise(IInterpolator interpolator, INoiseSettings noiseSettings)
        {
            _interpolator = interpolator;
            _noiseSettings = noiseSettings;
        }

        public double GetNoise(Vector2 vec)
        {
            throw new NotImplementedException();
        }

        public double GetNoise(Vector3 vec)
        {
            var seed = _noiseSettings.Seed;
            vec = NoiseHelper.GetVectorTimesFrequencyFor(vec);

            int x0 = NoiseHelper.FastFloor(vec.x);
            int y0 = NoiseHelper.FastFloor(vec.y);
            int z0 = NoiseHelper.FastFloor(vec.z);
            int x1 = x0 + 1;
            int y1 = y0 + 1;
            int z1 = z0 + 1;

            var vec1 = new Vector3(x0, y0, z0);
            var vec2 = new Vector3(x1, y1, z1);

            Vector3 interpVector = _interpolator.Interpolate(vec, vec1);

            //double xs, ys, zs;
            //switch (_interpolator)
            //{
            //    default:
            //    case Interp.Linear:
            //        xs = x - x0;
            //        ys = y - y0;
            //        zs = z - z0;
            //        break;
            //    case Interp.Hermite:
            //        xs = NoiseHelper.InterpHermiteFunc(x - x0);
            //        ys = NoiseHelper.InterpHermiteFunc(y - y0);
            //        zs = NoiseHelper.InterpHermiteFunc(z - z0);
            //        break;
            //    case Interp.Quintic:
            //        xs = NoiseHelper.InterpQuinticFunc(x - x0);
            //        ys = NoiseHelper.InterpQuinticFunc(y - y0);
            //        zs = NoiseHelper.InterpQuinticFunc(z - z0);
            //        break;
            //}

            double xf00 = NoiseHelper.Lerp(NoiseHelper.ValCoord3D(seed, x0, y0, z0), NoiseHelper.ValCoord3D(seed, x1, y0, z0), interpVector.x);
            double xf10 = NoiseHelper.Lerp(NoiseHelper.ValCoord3D(seed, x0, y1, z0), NoiseHelper.ValCoord3D(seed, x1, y1, z0), interpVector.x);
            double xf01 = NoiseHelper.Lerp(NoiseHelper.ValCoord3D(seed, x0, y0, z1), NoiseHelper.ValCoord3D(seed, x1, y0, z1), interpVector.x);
            double xf11 = NoiseHelper.Lerp(NoiseHelper.ValCoord3D(seed, x0, y1, z1), NoiseHelper.ValCoord3D(seed, x1, y1, z1), interpVector.x);

            double yf0 = NoiseHelper.Lerp(xf00, xf10, interpVector.y);
            double yf1 = NoiseHelper.Lerp(xf01, xf11, interpVector.y);

            return NoiseHelper.Lerp(yf0, yf1, interpVector.z);
        }
    }
}
