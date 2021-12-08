using System;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_UI_UWP.ViewModels.Utilidades.Converters
{
    public class ConverterDateTimeSimplificado: IValueConverter
    {
        /// <summary>
        /// Cabecera: public object Convert(object value, Type targetType, object parameter, string language)
        /// Comentario: Este metodo se encarga de convertir un objeto recibido de tipo DateTime a string, simplificando las horas/minutos/segundos.
        /// Entradas: object value, Type targetType, object parameter, string language
        /// Salidas: object
        /// Precondiciones: El objeto recibido tiene que ser de tipo DateTime.
        /// PostCondiciones: Se devolvera un objeto que sera de tipo string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>object</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;
            return dateTime.ToShortDateString();
        }

        /// <summary>
        /// Cabecera: public object ConvertBack(object value, Type targetType, object parameter, string language)
        /// Comentario: Este metodo se encarga de devolver el objeto que recibe, sin ninguna modificacion.  
        /// Entradas: object value, Type targetType, object parameter, string language
        /// Salidas: object
        /// Precondiciones: Ninguna.
        /// PostCondiciones: Se devolvera el mismo objeto que se recibe.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns>object</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;// se devuelve value porque el usuario no va a modificar la fecha, estara en un textBlock
        }
    }
}
