using System.Windows;
using System.Windows.Input;
using TollBoothManagementSystem.Core.Features.ApplicationAccess.Commands;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.Navigation
{
    public class LoginViewModel : ViewModelBase
    {

        //public readonly IUserRepository<User> _userRepository;

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

        public LoginViewModel()
        {
            _errMsgVisibility = Visibility.Hidden;
            _errMsgText = "";
            //_userRepository = userRepository;
            LoginCommand = new LoginCommand(this);
        }

    }
}
