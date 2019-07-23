using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.LightsPopulator
{
    internal partial class LightsPopulator
    {
        private bool AnyLightOn(LightsGrid lightsGrid)
        {
            return lightsGrid.Lights
                .SelectMany(x => x)
                .Any(x => x.LightState == LightStateType.On);
        }
    }
}
