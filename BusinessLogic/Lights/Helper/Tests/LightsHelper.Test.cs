#if DEBUG

using BusinessLogic.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.Helper.Tests
{
    [TestClass]
    public class LightsHelperTest
    {
        private int GetCountOfLightsWithState(LightsGrid lightsGrid, LightStateType lightState)
        {
            return lightsGrid.Lights
                .SelectMany(x => x)
                .Count(x => x.LightState == lightState);
        }

        [TestMethod]
        public void Test_Click_method()
        {
            var lightsGrid = TestHelper.Get5x5LightsGrid(LightStateType.Off);

            var mng = new LightsHelper();

            var result = mng.Click(lightsGrid, 0, 0);
            Assert.IsTrue(result.Lights[0][0].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[0][1].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[1][0].LightState == LightStateType.On);
            Assert.IsTrue(GetCountOfLightsWithState(result, LightStateType.On) == 3);

            result = mng.Click(result, 1, 1);
            Assert.IsTrue(result.Lights[0][0].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[1][1].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[1][2].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[2][1].LightState == LightStateType.On);
            Assert.IsTrue(GetCountOfLightsWithState(result, LightStateType.On) == 4);

            result = mng.Click(result, 2, 2);
            Assert.IsTrue(result.Lights[0][0].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[1][1].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[2][2].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[2][3].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[3][2].LightState == LightStateType.On);
            Assert.IsTrue(GetCountOfLightsWithState(result, LightStateType.On) == 5);

            result = mng.Click(result, 3, 3);
            Assert.IsTrue(result.Lights[0][0].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[1][1].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[2][2].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[3][3].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[3][4].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[4][3].LightState == LightStateType.On);
            Assert.IsTrue(GetCountOfLightsWithState(result, LightStateType.On) == 6);

            result = mng.Click(result, 4, 4);
            Assert.IsTrue(result.Lights[0][0].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[1][1].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[2][2].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[3][3].LightState == LightStateType.On);
            Assert.IsTrue(result.Lights[4][4].LightState == LightStateType.On);
            Assert.IsTrue(GetCountOfLightsWithState(result, LightStateType.On) == 5);
        }
    }
}

#endif