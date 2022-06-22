using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.GUI.Features.Navigation;
using TollBoothManagementSystem.GUI.Utility.WindowTitle;

namespace TollBoothManagementSystem.GUI.Utility.ViewModel
{
    public class MainViewModel : NavigableViewModel
    {
        private string _viewTitle;
        public string ViewTitle
        {
            get => _viewTitle;
        }
        private void OnTitleChanged()
        {
            _viewTitle = TitleManager.Title;
            OnPropertyChanged(nameof(ViewTitle));
        }
        public LoginViewModel Lvm { get; set; }
        public MainViewModel(LoginViewModel lvm)
        {
            TitleManager.TitleChanged += OnTitleChanged;
            TitleManager.Title = "Login";
            Lvm = lvm;
            SwitchCurrentViewModel(lvm);
        }

    }
}
