using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Lights;
using BusinessLogic.Lights.LightsPopulator;
using BusinessLogic.Lights.Helper;

namespace BusinessLogic.Lights
{
    internal class LightsManager : ILightsManager
    {
        private ILightsPopulator _populator;
        private ILightsHelper _helper;

        public LightsManager(
            ILightsPopulator populator,
            ILightsHelper helper)
        {
            _populator = populator;
            _helper = helper;
        }

        public LightsGrid Click(LightsGrid lightsGrid, int x, int y)
        {
            // TODO: move to LightsValidator
            if (x > lightsGrid.Lights.Count - 1
                || y > lightsGrid.Lights.Count - 1)
            {
                throw new ApplicationException();
            }

            return _helper.Click(lightsGrid, x, y);
        }

        public LightsGrid InitLightsGridInSolvableState(int dimension)
        {
            var retVal = _populator.InitLightsGrid(dimension);
            retVal = _populator.ResetAllLights(retVal);
            retVal = _populator.PopulateSolvableState(retVal);
            return retVal;
        }
    }
}
