using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TollBoothManagementSystem.GUI.Utility.Validation
{
    public class IsEmptyStringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? val = value.ToString();
            if (string.IsNullOrEmpty(val))
            {
                return new ValidationResult(false, "This field cannot be empty");
            }
            return ValidationResult.ValidResult;
        }
    }
}
