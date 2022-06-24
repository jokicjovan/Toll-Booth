using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TollBoothManagementSystem.Core.Features.General.Model;

namespace TollBoothManagementSystem.GUI.Utility.Converter
{
    public class StringToVehicleCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.ToString().Equals(parameter))
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "Category1A":
                    return VehicleType.Category1A;
                case "Category1":
                    return VehicleType.Category1;
                case "Category2":
                    return VehicleType.Category2;
                case "Category3":
                    return VehicleType.Category3;
                case "Category4":
                    return VehicleType.Category4;
                default:
                    return null;
            }
        }
    }
}
