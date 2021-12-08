using System;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_UI_UWP.ViewModels.Utilidades.Converters
{
    public class ConverterDateTimeOffSet : IValueConverter
    {
        /// <summary>
        /// Cabecera: public object Convert(object value, Type targetType, object parameter, string language)
        /// Comentario: Este metodo se encarga de convertir un objeto recibido de tipo DateTime a el tipo DateTimeOffset.
        /// Entradas: object value, Type targetType, object parameter, string language
        /// Salidas: object
        /// Precondiciones: El objeto recibido tiene que ser de tipo DateTime.
        /// PostCondiciones: Se devolvera un objeto que sera de tipo DateTimeOffset.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>object</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;

            DateTimeOffset dateTimeOffset = dateTime;

            return dateTimeOffset;
        }
        /// <summary>
        /// Cabecera: public object ConvertBack(object value, Type targetType, object parameter, string language)
        /// Comentario: Este metodo se encarga de convertir un objeto recibido de tipo DateTimeOffset a el tipo DateTime.
        /// Entradas: object value, Type targetType, object parameter, string language
        /// Salidas: object
        /// Precondiciones: El objeto recibido tiene que ser de tipo DateTimeOffset.
        /// PostCondiciones: Se devolvera un objeto que sera de tipo DateTime.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset dateTimeOffset = (DateTimeOffset)value;

            return dateTimeOffset.UtcDateTime;
        }
    }
}
