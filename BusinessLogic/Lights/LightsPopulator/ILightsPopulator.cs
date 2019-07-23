using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.LightsPopulator
{
    internal interface ILightsPopulator
    {
        LightsGrid InitLightsGrid(int dimension);

        LightsGrid ResetAllLights(LightsGrid lightsGrid);

        LightsGrid PopulateSolvableState(LightsGrid lightsGrid);
    }
}
