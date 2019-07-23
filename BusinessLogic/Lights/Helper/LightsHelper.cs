using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Lights;

namespace BusinessLogic.Lights.Helper
{
    // TODO: choose a better name
    internal partial class LightsHelper : ILightsHelper
    {
        public LightsGrid Click(LightsGrid lightsGrid, int x, int y)
        {
            var lights = lightsGrid.Lights;
            
            var xToCheckArr = new int[] { x - 1, x, x + 1 };
            var yToCheckArr = new int[] { y - 1, y, y + 1 };

            for (int i = 0; i < lights.Count; i++)
            {
                if (xToCheckArr.Contains(i))
                {
                    for (int j = 0; j < lights.Count; j++)
                    {
                        if (yToCheckArr.Contains(j))
                        {
                            if (i == x || j == y)
                            {
                                var light = lights[i][j];
                                light.LightState = ToggleLightState(light.LightState);
                            }
                        }
                    }
                }
            }

            return lightsGrid;
        }
    }
}
