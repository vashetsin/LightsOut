using Model.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lights.Helper
{
    internal partial class LightsHelper
    {
        private LightStateType ToggleLightState(LightStateType lightState)
        {
            switch (lightState)
            {
                case LightStateType.Off:
                    return LightStateType.On;
                case LightStateType.On:
                    return LightStateType.Off;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
