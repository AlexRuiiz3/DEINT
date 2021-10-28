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
using EjercicioFinalLayouts.ViewModels;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EjercicioFinalLayouts.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetallesCita : Page
    {
        public DetallesCita()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DetallesCitaViewVM = (DetallesCitaViewVM)e.Parameter;
           
        }

        public DetallesCitaViewVM DetallesCitaViewVM{get;set;}

        private void Button_SeleccionarFotos(object sender, RoutedEventArgs e)
        {
            ListaFotos.Visibility = Visibility.Visible;
        }

        private void Button_IncluirFotos(object sender, RoutedEventArgs e)
        {
            if (ListaFotos.Visibility == Visibility)//Si "hay" fotos selecionadas se envian 
            {
                txtbFotosIncluidas.Visibility = Visibility.Visible;
            }
            else {
                txtbFotosIncluidas.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_EliminarFotos(object sender, RoutedEventArgs e)
        {
            ListaFotos.Visibility = Visibility.Collapsed;
            txtbFotosIncluidas.Visibility = Visibility.Collapsed;
        }

        private async void Button_EnviarInforme(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Datos enviados correctamente");

            await dialog.ShowAsync();
        }
    }
}

