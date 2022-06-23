using Ninject.Modules;
using TollBoothManagementSystem.Core.Features.General.Repository;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;
using TollBoothManagementSystem.Core.Features.UserManagement.Repository;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;
using TollBoothManagementSystem.GUI.Features.Navigation;

namespace TollBoothManagementSystem.Core.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Repositories
            Bind(typeof(ICurrencyRepository)).To(typeof(CurrencyRepository));
            Bind(typeof(ILocationRepository)).To(typeof(LocationRepository));

            Bind(typeof(IFaultReportRepository)).To(typeof(FaultReportRepository));
            Bind(typeof(ITollBoothRepository)).To(typeof(TollBoothRepository));
            Bind(typeof(ITollStationRepository)).To(typeof(TollStationRepository));

            Bind(typeof(IElectronicTollCollectionRepository)).To(typeof(ElectronicTollCollectionRepository));
            Bind(typeof(IETCPaymentRepository)).To(typeof(ETCPaymentRepository));
            Bind(typeof(IPaymentRepository)).To(typeof(PaymentRepository));
            Bind(typeof(IPriceListRepository)).To(typeof(PriceListRepository));
            Bind(typeof(IRoadTollPaymentRepository)).To(typeof(RoadTollPaymentRepository));
            Bind(typeof(IRoadTollPriceRepository)).To(typeof(RoadTollPriceRepository));
            Bind(typeof(IRoadTollRepository)).To(typeof(RoadTollRepository));
            Bind(typeof(ISectionRepository)).To(typeof(SectionRepository));
            Bind(typeof(ISectionInfoRepository)).To(typeof(SectionInfoRepository));

            Bind(typeof(IShiftRepository)).To(typeof(ShiftRepository));
            Bind(typeof(IUserRepository)).To(typeof(UserRepository));

            Bind(typeof(ICrudRepository<>)).To(typeof(CrudRepository<>));

            Bind<DatabaseContext>().To<DatabaseContext>().InSingletonScope().WithConstructorArgument(0);
            Bind<LoginViewModel>().To<LoginViewModel>();
        }
    }
}
