using System;
using System.Globalization;
using System.Windows.Controls;

namespace TollBoothManagementSystem.GUI.Utility.Validation
{
    public class IsPositiveNumericValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double valueDouble;
            try
            {
                valueDouble = Convert.ToDouble(value);
            }
            catch
            {
                return new ValidationResult(false, "This field must contain numeric value");
            }
            if(valueDouble < 0)
            {
                return new ValidationResult(false, "This field cannot contain negative value");
            }
            return ValidationResult.ValidResult;
        }
    }
}
