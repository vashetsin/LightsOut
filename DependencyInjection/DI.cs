using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class DI
    {
        private static IContainer _container = null;
        public static IContainer Container
        {
            get
            {
                return _container;
            }
        }

        public static void RegisterDependenciesOnStartup(params IDependencyRegistrator[] registers)
        {
            var builder = new ContainerBuilder();

            foreach (var register in registers)
            {
                register.RegisterDependencies(builder);
            }

            _container = builder.Build();
        }

        public static R CallOnScope<T, R>(Func<T, R> func)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                return CallOnScope(scope, func);
            }
        }

        public static R CallOnScope<T, R>(ILifetimeScope scope, Func<T, R> func)
        {
            var t = scope.Resolve<T>();
            return func(t);
        }

        public static void CallOnScope<T>(Action<T> action)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                CallOnScope(scope, action);
            }
        }

        public static void CallOnScope<T>(ILifetimeScope scope, Action<T> action)
        {
            var t = scope.Resolve<T>();
            action(t);
        }
    }
}
