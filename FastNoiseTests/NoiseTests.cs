using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FastNoiseTests
{
    [TestClass]
    public class NoiseTests
    {
        xFastNoise noise;
        int seed = 1337;
        float epsilon = 0.00001f;

        [TestInitialize]
        public void Initialize()
        {
            noise = new xFastNoise(seed);
        }

        [TestMethod]
        public void SingleValueNoise_ShouldReturnProperValueForGetNoise()
        {
            noise.SetNoiseType(xFastNoise.NoiseType.Value);
            noise.SetInterp(xFastNoise.Interp.Linear);

            var val1 = noise.GetNoise(0, 0, 0);
            var val2 = noise.GetNoise(1, 1, 1);
            var val3 = noise.GetNoise(2, 2, 2);
            var val4 = noise.GetNoise(1, 2, 3);
            var val5 = noise.GetNoise(3, 2, 1);


            Assert.IsTrue(Math.Abs(val1 - -0.06701785) < epsilon);
            Assert.IsTrue(Math.Abs(val2 - -0.06581626) < epsilon);
            Assert.IsTrue(Math.Abs(val3 - -0.06428894) < epsilon);
            Assert.IsTrue(Math.Abs(val4 - -0.07271209) < epsilon);
            Assert.IsTrue(Math.Abs(val5 - -0.05587651) < epsilon);
 
            //Assert.AreEqual(val5, 0);
        }
    }
}
