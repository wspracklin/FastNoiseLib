using FastNoise;
using FastNoise.Noises;
using FastNoise.Interpolators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FastNoiseTests.Noises
{
    [TestClass]
    public class SingleValueNoiseTests
    {
        SingleValueNoise noise;
        int seed = 1337;
        float epsilon = 0.00001f;

        [TestInitialize]
        public void Initialize()
        {
            noise = new SingleValueNoise(new LinearInterpolator());
        }

        [TestMethod]
        public void SingleValueNoise_ShouldReturnProperValueForGetNoise()
        {
            var val1 = noise.GetNoise(seed, new Vector3(0, 0, 0));
            var val2 = noise.GetNoise(seed, new Vector3(1, 1, 1));
            var val3 = noise.GetNoise(seed, new Vector3(2, 2, 2));
            var val4 = noise.GetNoise(seed, new Vector3(1, 2, 3));
            var val5 = noise.GetNoise(seed, new Vector3(3, 2, 1));

            //Assert.AreEqual(val1, 0);
            //Assert.AreEqual(val2, 0);
            //Assert.AreEqual(val3, 0);
            //Assert.AreEqual(val4, 0);
            //Assert.AreEqual(val5, 0);

            Assert.IsTrue(Math.Abs(val1 - -0.06701785) < epsilon);
            Assert.IsTrue(Math.Abs(val2 - -0.06581626) < epsilon);
            Assert.IsTrue(Math.Abs(val3 - -0.06428894) < epsilon);
            Assert.IsTrue(Math.Abs(val4 - -0.07271209) < epsilon);
            Assert.IsTrue(Math.Abs(val5 - -0.05587651) < epsilon);
        }
    }
}
