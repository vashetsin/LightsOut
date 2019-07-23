using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights
{
    public interface ILightsManager
    {
        /// <summary>
        /// Initialize Lights Grid
        /// </summary>
        /// <param name="dimension">Dimension (n x n)</param>
        /// <returns></returns>
        LightsGrid InitLightsGridInSolvableState(int dimension);

        LightsGrid Click(LightsGrid lightsGrid, int x, int y);
    }
}
