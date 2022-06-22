using Ninject.Modules;
using TollBooth.Core.Persistence;

namespace TollBooth.Core.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DatabaseContext>().To<DatabaseContext>().InSingletonScope().WithConstructorArgument(0);
            //Bind<LoginViewModel>().To<LoginViewModel>();
        }
    }
}
