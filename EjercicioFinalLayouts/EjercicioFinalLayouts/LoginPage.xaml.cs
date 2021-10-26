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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EjercicioFinalLayouts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_IniciarSesion(object sender, RoutedEventArgs e)
        {
            Boolean datosValidos = true;

            if (String.IsNullOrEmpty(txtbUsuarioLogin.Text) ) {
                txtblErrorUsuarioLogin.Visibility = Visibility.Visible;
                datosValidos = false;
            }
            else {
                txtblErrorUsuarioLogin.Visibility = Visibility.Collapsed;
            }
            if (String.IsNullOrEmpty(pswbContrasenhaLogin.Password)) {
                txtblErrorPasswordLogin.Visibility = Visibility.Visible;
                datosValidos = false;
            }
            else {
                txtblErrorPasswordLogin.Visibility = Visibility.Collapsed;
            }

            if (datosValidos) {
                Frame.Navigate(typeof(CitasPage));
            }
        }
    }
}
