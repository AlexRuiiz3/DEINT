using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Actividad6
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
           InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickButtonAdd(object sender, RoutedEventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxApellidos.Text = "";
            textBoxFechaNacim.Text = "";

            textBlockErrorNombre.Visibility = Visibility.Collapsed;
            textBlockErrorApellidos.Visibility = Visibility.Collapsed;
            textBlockErrorFechaNacimiento.Visibility = Visibility.Collapsed;
            textBlockResultadoOperacion.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickButtonSave(object sender, RoutedEventArgs e)
        {
            Boolean datosValidos = true, fechaNacimientoValida = false;

            //Nombre
            if (Validaciones.Validacion.comprobarCadenaVaciaONull(textBoxNombre.Text)) {

                datosValidos = false;
                textBlockErrorNombre.Foreground = new SolidColorBrush(Colors.Red);
                textBlockErrorNombre.Text = "El nombre no puede estar vacio";
            }
            else
            {
                textBlockErrorNombre.Foreground = new SolidColorBrush(Colors.Green);
                textBlockErrorNombre.Text = "El nombre es correcto";
            }

            //Apellidos
            if (Validaciones.Validacion.comprobarCadenaVaciaONull(textBoxApellidos.Text))
            {
                datosValidos = false;
                textBlockErrorApellidos.Foreground = new SolidColorBrush(Colors.Red);
                textBlockErrorApellidos.Text = "El apellido no puede estar vacio";
               
            }
            else 
            {
                textBlockErrorApellidos.Foreground = new SolidColorBrush(Colors.Green);
                textBlockErrorApellidos.Text = "El apellido es valido";
            }


            //FechaNacimiento
            if (!fechaNacimientoValida)
            {
                datosValidos = false;
                textBlockErrorFechaNacimiento.Foreground = new SolidColorBrush(Colors.Red);
                textBlockErrorFechaNacimiento.Text = "La fecha no es valida";
            }
            else {
                textBlockErrorFechaNacimiento.Foreground = new SolidColorBrush(Colors.Green);
                textBlockErrorFechaNacimiento.Text = "La fecha es valida";
            }

            if (datosValidos) {

                textBlockResultadoOperacion.Text = "Los datos se guardaron de forma correcta";
                textBlockResultadoOperacion.Visibility = Visibility.Visible;

            }

            //Sean correctos o no los campos, se tienen que mostrar
            textBlockErrorNombre.Visibility = Visibility.Visible;
            textBlockErrorApellidos.Visibility = Visibility.Visible;
            textBlockErrorFechaNacimiento.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onClickButtonDelete(object sender, RoutedEventArgs e)
        {

            if (!textBoxNombre.Text.Equals("") || !textBoxApellidos.Text.Equals("") || !textBoxFechaNacim.Text.Equals(""))
            {
                //Mejor con el content dialog 
                var messageDialog = new MessageDialog("¿Quieres eliminar a esa persona?", "Eliminar datos persona");
                UICommand commadButtonOk = new UICommand("Ok", new UICommandInvokedHandler(CommandOkEliminarDatos));
                messageDialog.Commands.Add(commadButtonOk);

                UICommand commadButtonCancel = new UICommand("Cancel");
                messageDialog.Commands.Add(commadButtonCancel);

                await messageDialog.ShowAsync(); //Se espera hasta que se cierre el MesasgeDialog
            }
        }

        /// <summary>
        ///  Comentario: Este metodo que ira integrado en un messageDialog y cuya funcion es eliminar los datos que hay en los campos y mostrar un 
        ///              mensaje se exito.
        /// </summary>
        /// <param name="command"></param>
        private void CommandOkEliminarDatos(IUICommand command)
        {
            textBoxNombre.Text = "";
            textBoxApellidos.Text = "";
            textBoxFechaNacim.Text = "";

            textBlockErrorNombre.Visibility = Visibility.Collapsed;
            textBlockErrorApellidos.Visibility = Visibility.Collapsed;
            textBlockErrorFechaNacimiento.Visibility = Visibility.Collapsed;

            textBlockResultadoOperacion.Text = "Los datos se han borrado correctamente";
            textBlockResultadoOperacion.Visibility = Visibility.Visible;
        }

    }
}
