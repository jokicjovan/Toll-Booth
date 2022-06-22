using Ninject.Modules;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.GUI.Features.Navigation;

namespace TollBoothManagementSystem.Core.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DatabaseContext>().To<DatabaseContext>().InSingletonScope().WithConstructorArgument(0);
            Bind<LoginViewModel>().To<LoginViewModel>();
        }
    }
}
