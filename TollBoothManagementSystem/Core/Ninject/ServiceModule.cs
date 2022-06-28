using Ninject.Modules;
using TollBoothManagementSystem.Core.Features.General.Repository;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Repository;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Repository;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Repository;
using TollBoothManagementSystem.Core.Features.UserManagement.Service;
using TollBoothManagementSystem.Core.Persistence;
using TollBoothManagementSystem.Core.Utility;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.Dialog;

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
            Bind(typeof(IEmployeeRepository)).To(typeof(EmployeeRepository));

            Bind(typeof(ICrudRepository<>)).To(typeof(CrudRepository<>));

            // Services
            Bind(typeof(ICurrencyService)).To(typeof(CurrencyService));
            Bind(typeof(ILocationService)).To(typeof(LocationService));

            Bind(typeof(IFaultReportService)).To(typeof(FaultReportService));
            Bind(typeof(ITollBoothService)).To(typeof(TollBoothService));
            Bind(typeof(ITollStationService)).To(typeof(TollStationService));

            Bind(typeof(IElectronicTollCollectionService)).To(typeof(ElectronicTollCollectionService));
            Bind(typeof(IETCPaymentService)).To(typeof(ETCPaymentService));
            Bind(typeof(IPriceListService)).To(typeof(PriceListService));
            Bind(typeof(IRoadTollPaymentService)).To(typeof(RoadTollPaymentService));
            Bind(typeof(IRoadTollPriceService)).To(typeof(RoadTollPriceService));
            Bind(typeof(IRoadTollService)).To(typeof(RoadTollService));
            Bind(typeof(ISectionService)).To(typeof(SectionService));
            Bind(typeof(ISectionInfoService)).To(typeof(SectionInfoService));

            Bind(typeof(IShiftService)).To(typeof(ShiftService));
            Bind(typeof(IUserService)).To(typeof(UserService));
            Bind(typeof(IEmployeeService)).To(typeof(EmployeeService));

            Bind(typeof(IDialogService)).To(typeof(DialogService));

            Bind<DatabaseContext>().To<DatabaseContext>().InSingletonScope().WithConstructorArgument(0);
            Bind<LoginViewModel>().To<LoginViewModel>();
        }
    }
}
