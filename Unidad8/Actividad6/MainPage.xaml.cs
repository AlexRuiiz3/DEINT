using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        private void onClickButtonAdd(object sender, RoutedEventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxApellidos.Text = "";
            textBoxFechaNacim.Text = "";
        }

        private void onClickButtonSave(object sender, RoutedEventArgs e)
        {
            Boolean datosValidos = true;

            if (Validaciones.Validacion.comprobarCadenaVaciaONull(textBoxNombre.Text)) {


                datosValidos = false; 
                textBlockErrorNombre.Text = "El nombre no puede estar vacio";
            }
            else
            {
                textBlockErrorNombre.Text = "El nombre es correcto";
            }

            if (Validaciones.Validacion.comprobarCadenaVaciaONull(textBoxApellidos.Text))
            {


                datosValidos = false;
                textBlockErrorApellidos.Text = "El apellido no puede estar vacio";
            }
            else 
            {
                textBlockErrorApellidos.Text = "El apellido es valido";
            }


            if (Validaciones.Validacion.comprobarCadenaVaciaONull(textBoxNombre.Text))
            {


                datosValidos = false;
            }

            if (datosValidos) {
                


            }

        }

        private void onClickButtonDelete(object sender, RoutedEventArgs e)
        {

        }
    }
}
