using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class TestHelper
    {
        private static List<Light> Get5Lights(LightStateType lightState)
        {
            return new List<Light> {
                new Light { LightState = lightState },
                new Light { LightState = lightState },
                new Light { LightState = lightState },
                new Light { LightState = lightState },
                new Light { LightState = lightState }
            };
        }

        public static LightsGrid Get5x5LightsGrid(LightStateType lightState)
        {
            var retVal = new LightsGrid();
            retVal.Lights = new List<List<Light>>
            {
                Get5Lights(lightState),
                Get5Lights(lightState),
                Get5Lights(lightState),
                Get5Lights(lightState),
                Get5Lights(lightState)
            };
            return retVal;
        }

    }
}
