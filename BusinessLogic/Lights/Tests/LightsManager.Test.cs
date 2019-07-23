using BusinessLogic.Lights.Helper;
using BusinessLogic.Lights.LightsPopulator;
using BusinessLogic.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Lights;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.Tests
{
    [TestClass]
    public class LightsManagerTest
    {
        [TestMethod]
        public void Test_InitLightsGridInSolvableState_method()
        {
            var dimension = 5;

            var populator = new Mock<ILightsPopulator>();
            var lightsGrid1 = It.IsAny<LightsGrid>();
            populator.Setup(p => p.InitLightsGrid(dimension)).Returns(lightsGrid1);
            var lightsGrid2 = It.IsAny<LightsGrid>();
            populator.Setup(p => p.ResetAllLights(lightsGrid1)).Returns(lightsGrid2);
            var lightsGrid3 = It.IsAny<LightsGrid>();
            populator.Setup(p => p.PopulateSolvableState(lightsGrid2)).Returns(lightsGrid3);

            var mng = new LightsManager(populator.Object, null);

            var result = mng.InitLightsGridInSolvableState(dimension);

            populator.Verify(p => p.InitLightsGrid(dimension), Times.Once);
            populator.Verify(p => p.ResetAllLights(lightsGrid1), Times.Once);
            populator.Verify(p => p.PopulateSolvableState(lightsGrid2), Times.Once);
            Assert.AreSame(result, lightsGrid3);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Click_method_thorws_exception()
        {
            var lightsGrid = TestHelper.Get5x5LightsGrid(LightStateType.Off);

            var mng = new LightsManager(null, null);

            var result = mng.Click(lightsGrid, 5, 5);
        }

        [TestMethod]
        public void Test_Click_method()
        {
            var lightsGrid = TestHelper.Get5x5LightsGrid(LightStateType.Off);
            var x = 4;
            var y = 4;

            var lightsHelper = new Mock<ILightsHelper>();
            var lightsGridAfterClick = It.IsAny<LightsGrid>();
            lightsHelper.Setup(h => h.Click(lightsGrid, x, y)).Returns(lightsGridAfterClick);

            var mng = new LightsManager(null, lightsHelper.Object);

            var result = mng.Click(lightsGrid, x, y);

            Assert.AreSame(result, lightsGridAfterClick);
        }
    }
}
