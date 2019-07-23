using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.Helper
{
    internal interface ILightsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lightsGrid">Lights Grid</param>
        /// <param name="x">Index of row that users clicked</param>
        /// <param name="y">Index of column that users clicked</param>
        /// <returns></returns>
        LightsGrid Click(LightsGrid lightsGrid, int x, int y);
    }
}
