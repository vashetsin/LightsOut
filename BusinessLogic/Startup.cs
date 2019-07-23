using Autofac;
using BusinessLogic.Lights;
using BusinessLogic.Lights.Helper;
using BusinessLogic.Lights.LightsPopulator;
using DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Startup : IDependencyRegistrator
    {
        private static Startup _current;
        public static Startup Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new Startup();
                }

                return _current;
            }
        }

        public void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<LightsPopulator>().As<ILightsPopulator>();
            builder.RegisterType<LightsManager>().As<ILightsManager>();
            builder.RegisterType<LightsHelper>().As<ILightsHelper>();
        }
    }
}
