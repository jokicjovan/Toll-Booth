﻿using TollBoothManagementSystem.Core.Utility.HelperClasses;

namespace TollBoothManagementSystem.GUI.Utility.Validation
{
    public class ErrorMessageViewModel : ObservableEntity
    {
        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); OnPropertyChanged(nameof(HasError)); }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
