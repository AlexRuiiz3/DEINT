using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EjercicioFinalLayouts.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetallesCitaNav_Anotaciones : Page
    {
        public DetallesCitaNav_Anotaciones()
        {
            this.InitializeComponent();
            
        }

        /// <summary>
        /// Evento asociado a un boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_EnviarInforme(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Datos enviados correctamente");

            await dialog.ShowAsync();
        }
    }
}
