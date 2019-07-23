using BusinessLogic.Lights.Helper;
using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.LightsPopulator
{
    internal partial class LightsPopulator : ILightsPopulator
    {
        private ILightsHelper _helper;

        public LightsPopulator(ILightsHelper helper)
        {
            _helper = helper;
        }

        public LightsGrid InitLightsGrid(int dimension)
        {
            var retVal = new LightsGrid();
            retVal.Lights = new List<List<Light>>();

            for (int i = 1; i <= dimension; i++)
            {
                var row = new List<Light>();
                for (int j = 1; j <= dimension; j++)
                {
                    row.Add(new Light());
                }
                retVal.Lights.Add(row);
            }

            return retVal;
        }

        public LightsGrid PopulateSolvableState(LightsGrid lightsGrid)
        {
            var retVal = lightsGrid;

            var step = 0;
            var random = new Random();

            do
            {
                var x = random.Next(0, lightsGrid.Lights.Count - 1);
                var y = random.Next(0, lightsGrid.Lights.Count - 1);
                retVal = _helper.Click(retVal, x, y);
                step++;
            }
            while (step < 100  // loop at least 100 times
                && AnyLightOn(lightsGrid)); // make sure that any light in state on

            return retVal;
        }

        public LightsGrid ResetAllLights(LightsGrid lightsGrid)
        {
            lightsGrid.Lights
                .SelectMany(x => x)
                .ToList()
                .ForEach(x => x.LightState = LightStateType.Off);

            return lightsGrid;
        }
    }
}
