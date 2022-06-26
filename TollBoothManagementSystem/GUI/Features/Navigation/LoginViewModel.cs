using System.Windows;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Repository;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class LoginViewModel : ViewModelBase
    {

        public readonly IUserRepository _userRepository;
        private readonly ISectionService _sectionService;
        private readonly IPriceListService _priceListService;
        private readonly ITollBoothService _tollBoothService;

        private string? _email = "@example.com";
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string? _password = "test123";
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _errMsgText;
        public string ErrMsgText
        {
            get => _errMsgText;
            set
            {
                _errMsgText = value;
                OnPropertyChanged(nameof(ErrMsgText));
            }
        }

        private Visibility _errMsgVisibility;
        public Visibility ErrMsgVisibility
        {
            get => _errMsgVisibility;
            set
            {
                _errMsgVisibility = value;
                OnPropertyChanged(nameof(ErrMsgVisibility));
            }
        }

        public ICommand? LoginCommand { get; }

        public ISectionService SectionService => _sectionService;
        public ITollBoothService TollBoothService => _tollBoothService;

        public IPriceListService PriceListService => _priceListService;

        public LoginViewModel(IUserRepository userRepository, ISectionService sectionService, IPriceListService priceListService, ITollBoothService tollBoothService)
        {
            _errMsgVisibility = Visibility.Hidden;
            _errMsgText = "";
            _userRepository = userRepository;
            _sectionService = sectionService;
            LoginCommand = new LoginCommand(this);
            _priceListService = priceListService;
            _tollBoothService = tollBoothService;
        }

    }
}
