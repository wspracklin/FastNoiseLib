using FastNoise.Interpolators;

namespace FastNoise.Noises
{
    public class PerlinNoise : INoise
    {
        private readonly IInterpolator _interpolator;
        private readonly INoiseSettings _noiseSettings;

        public PerlinNoise(IInterpolator interpolator, INoiseSettings noiseSettings)
        {
            _interpolator = interpolator;
            _noiseSettings = noiseSettings;
        }

        public double GetNoise(Vector2 vec)
        {
            var seed = _noiseSettings.Seed;
            vec = new Vector2(vec.x * _noiseSettings.Frequency, vec.y * _noiseSettings.Frequency);

            int x0 = NoiseHelper.FastFloor(vec.x);
            int y0 = NoiseHelper.FastFloor(vec.y);
            int x1 = x0 + 1;
            int y1 = y0 + 1;

            var vec1 = new Vector2(x0, y0);

            Vector2 interpVector = _interpolator.Interpolate(vec, vec1);

            double xd0 = vec.x - x0;
            double yd0 = vec.y - y0;
            double xd1 = xd0 - 1;
            double yd1 = yd0 - 1;

            double xf0 = NoiseHelper.Lerp(NoiseHelper.GradCoord2D(seed, x0, y0, xd0, yd0), NoiseHelper.GradCoord2D(seed, x1, y0, xd1, yd0), interpVector.x);
            double xf1 = NoiseHelper.Lerp(NoiseHelper.GradCoord2D(seed, x0, y1, xd0, yd1), NoiseHelper.GradCoord2D(seed, x1, y1, xd1, yd1), interpVector.x);

            return NoiseHelper.Lerp(xf0, xf1, interpVector.y);
        }

        public double GetNoise(Vector3 vec)
        {
            var seed = _noiseSettings.Seed;
            vec = new Vector3(vec.x * _noiseSettings.Frequency, vec.y * _noiseSettings.Frequency, vec.z * _noiseSettings.Frequency);

            int x0 = NoiseHelper.FastFloor(vec.x);
            int y0 = NoiseHelper.FastFloor(vec.y);
            int z0 = NoiseHelper.FastFloor(vec.z);
            int x1 = x0 + 1;
            int y1 = y0 + 1;
            int z1 = z0 + 1;

            var vec1 = new Vector3(x0, y0, z0);

            Vector3 interpVector = _interpolator.Interpolate(vec, vec1);

            double xd0 = vec.x - x0;
            double yd0 = vec.y - y0;
            double zd0 = vec.z - z0;
            double xd1 = xd0 - 1;
            double yd1 = yd0 - 1;
            double zd1 = zd0 - 1;

            double xf00 = NoiseHelper.Lerp(NoiseHelper.GradCoord3D(seed, x0, y0, z0, xd0, yd0, zd0), NoiseHelper.GradCoord3D(seed, x1, y0, z0, xd1, yd0, zd0), interpVector.x);
            double xf10 = NoiseHelper.Lerp(NoiseHelper.GradCoord3D(seed, x0, y1, z0, xd0, yd1, zd0), NoiseHelper.GradCoord3D(seed, x1, y1, z0, xd1, yd1, zd0), interpVector.x);
            double xf01 = NoiseHelper.Lerp(NoiseHelper.GradCoord3D(seed, x0, y0, z1, xd0, yd0, zd1), NoiseHelper.GradCoord3D(seed, x1, y0, z1, xd1, yd0, zd1), interpVector.x);
            double xf11 = NoiseHelper.Lerp(NoiseHelper.GradCoord3D(seed, x0, y1, z1, xd0, yd1, zd1), NoiseHelper.GradCoord3D(seed, x1, y1, z1, xd1, yd1, zd1), interpVector.x);

            double yf0 = NoiseHelper.Lerp(xf00, xf10, interpVector.y);
            double yf1 = NoiseHelper.Lerp(xf01, xf11, interpVector.y);

            return NoiseHelper.Lerp(yf0, yf1, interpVector.z);
        }
    }
}
