#if DEBUG

using BusinessLogic.Lights.Helper;
using BusinessLogic.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Lights;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.LightsPopulator.Tests
{
    [TestClass]
    public class LightsPopulatorTest
    {
        [TestMethod]
        public void Test_InitLightsGrid_method()
        {
            var dimension = 5;

            var mng = new LightsPopulator(null);

            var result = mng.InitLightsGrid(dimension);

            Assert.AreEqual(result.Lights.Count, dimension); // 5 rows
            Assert.AreEqual(result.Lights.SelectMany(x => x).Count(), Math.Pow(dimension, 2)); // 25 lights
        }

        [TestMethod]
        public void Test_ResetAllLights_method()
        {
            var lightsGrid = TestHelper.Get5x5LightsGrid(LightStateType.On);

            var mng = new LightsPopulator(null);

            var result = mng.ResetAllLights(lightsGrid);

            Assert.IsTrue(result.Lights
                .SelectMany(x => x)
                .All(x => x.LightState == LightStateType.Off));
        }

        [TestMethod]
        public void Test_PopulateSolvableState_method()
        {
            // This is not ideal test.
            // Needs more time to think about its implementation :)
            var lightsGrid = TestHelper.Get5x5LightsGrid(LightStateType.Off);
            lightsGrid.Lights[0][0].LightState = LightStateType.On;

            var helper = new Mock<ILightsHelper>();
            helper.Setup(x => x.Click(lightsGrid, It.IsAny<int>(), It.IsAny<int>())).Returns(lightsGrid);

            var mng = new LightsPopulator(helper.Object);

            var result = mng.PopulateSolvableState(lightsGrid);
            
            Assert.IsTrue(result.Lights
                .SelectMany(x => x)
                .Count(x => x.LightState == LightStateType.On) > 0);
        }
    }
}

#endif