using System;
using System.ComponentModel;
using System.Windows;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.WindowTitle;

namespace TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel? _viewModel;

        public LoginCommand(LoginViewModel lwm)
        {
            _viewModel = lwm;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Email) || e.PropertyName == nameof(_viewModel.Password))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Email) && !string.IsNullOrEmpty(_viewModel.Password) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var user = _viewModel._userRepository.Authenticate(_viewModel.Email, _viewModel.Password);
            if (user == null)
            {
                _viewModel.ErrMsgText = "Email or password is incorrect";
                _viewModel.ErrMsgVisibility = Visibility.Visible;
            }
            else
            {
                Guid guid = GlobalStore.ReadObject<Guid>("CurrentTollBooth");
                TollBooth currentTollBooth;
                TollStation currentTollStation;
                Section currentSection;
                PriceList pricelist;

                switch (user.Role)
                {
                    case Role.Manager:
                        Manager mn = (Manager)user;
                        GlobalStore.AddObject("LoggedUser", mn);

                        currentTollBooth = _viewModel.TollBoothService.Read(guid);
                        currentTollStation = currentTollBooth.TollStation;
                        currentSection = _viewModel.SectionService.GetSection(currentTollStation);
                        pricelist = _viewModel.PriceListService.GetActivePricelist(currentSection);
                        GlobalStore.AddObject("CurrentTollStation", currentTollStation);
                        GlobalStore.AddObject("CurrentSection", currentSection);
                        GlobalStore.AddObject("ActivePricelist", pricelist);

                        EventBus.FireEvent("ManagerLogin");
                        TitleManager.Title = "Manager";
                        break;

                    case Role.Administrator:
                        Administrator admin = (Administrator)user;
                        GlobalStore.AddObject("LoggedUser", admin);
                        EventBus.FireEvent("AdministratorLogin");
                        TitleManager.Title = "Referent";
                        break;

                    case Role.Referent:
                        Referent rf = (Referent)user;
                        GlobalStore.AddObject("LoggedUser", rf);

                        currentTollBooth = _viewModel.TollBoothService.Read(guid);
                        currentTollStation = currentTollBooth.TollStation;
                        currentSection = _viewModel.SectionService.GetSection(currentTollStation);
                        pricelist = _viewModel.PriceListService.GetActivePricelist(currentSection);
                        GlobalStore.AddObject("CurrentTollStation", currentTollStation);
                        GlobalStore.AddObject("CurrentSection", currentSection);
                        GlobalStore.AddObject("ActivePricelist", pricelist);

                        EventBus.FireEvent("ReferentLogin");
                        TitleManager.Title = "Referent";
                        break;

                    default:
                        MessageBox.Show("ERR");
                        return;
                }
            }

        }
    }
}
