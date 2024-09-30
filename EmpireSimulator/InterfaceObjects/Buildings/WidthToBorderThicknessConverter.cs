using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace EmpireSimulator.InterfaceObjects.Buildings
{
    public class WidthToBorderThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width)
            {
                double thickness = width * 0.05;
                return new Thickness(thickness);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
