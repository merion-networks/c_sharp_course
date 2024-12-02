using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace MyFourthProgram.UI.Helper
{
    public class DirectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ListSortDirection)
            {
                return ((ListSortDirection)value) == ListSortDirection.Ascending ? "По возрастанию" : "По убыванию";
            }
            return value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
