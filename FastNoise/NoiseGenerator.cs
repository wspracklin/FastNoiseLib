using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise
{
    public class NoiseGenerator
    {
        public float[,] Generate2DNoise(INoiseSettings settings)
        {
            float[,] noise = new float[settings.SizeX,settings.SizeY];

            for(int x = 0; x < settings.SizeX; x++)
            {
                for(int y = 0; y < settings.SizeY; y++)
                {
                    var val = settings.Noise.GetNoise(new Vector3(x, y, 0));
                    noise[x,y] = val;
                }
            }

            return noise;
        }
    }
}
