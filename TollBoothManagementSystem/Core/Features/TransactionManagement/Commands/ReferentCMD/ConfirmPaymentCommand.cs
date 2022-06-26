using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.TransactionManagement;

namespace TollBoothManagementSystem.Core.Features.TransactionManagement.Commands.ReferentCMD
{
    public class ConfirmPaymentCommand : CommandBase
    {
        private readonly RoadTollPaymentViewModel _viewModel;

        public ConfirmPaymentCommand(RoadTollPaymentViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            DateTime enterDateTime = _viewModel.EnterDateTime;
            if(enterDateTime > DateTime.Now.AddMinutes(-1))
            {
                MessageBox.Show("Enter time error", "Enter time error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TollStation enterStation = _viewModel.SelectedStation;

            TollStation exitStation = _viewModel.CurrentStation;

            VehicleType vehicleType = _viewModel.SelectedVehicleCategory;

            double distance = _viewModel.SectionInfoService.CalculateDistance(enterStation, exitStation);

            string licencePlateNumber = _viewModel.LicencePlateNumber;

            double price = _viewModel.Price;

            double avarageSpeed = distance / (DateTime.Now - enterDateTime).TotalHours;

            TollBooth tollBooth = _viewModel.TollBoothService.Read(GlobalStore.ReadObject<Guid>("CurrentTollBooth"));

            Currency currency = _viewModel.SelectedCurrency;

            RoadTollPayment payment = new RoadTollPayment
            {
                EnterTime = enterDateTime,
                Distance = distance,
                EnterTollStation = enterStation,
                ExitTime = DateTime.Now,
                VehicleCategory = vehicleType,
                LicencePlateNumber = licencePlateNumber,
                Price = price,
                AvarageSpeed = avarageSpeed,
                TollBooth = tollBooth,
                Currency = currency
            };
            _viewModel.RoadTollPaymentService.Create(payment);
            _viewModel.ResetForm();
            MessageBox.Show("Payment has been processed.");
        }
    }
}
