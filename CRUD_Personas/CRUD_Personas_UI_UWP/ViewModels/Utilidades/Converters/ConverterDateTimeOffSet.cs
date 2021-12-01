using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_UI_UWP.ViewModels.Utilidades.Converters
{
    public class ConverterDateTimeOffSet : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;

            DateTimeOffset dateTimeOffset = dateTime;

            return dateTimeOffset;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset dateTimeOffset = (DateTimeOffset)value;

            return dateTimeOffset.UtcDateTime;
        }
    }
}
