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
using Entidades;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EjercicioFinalLayouts.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CitasPage : Page
    {
        public CitasPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento click asociado a los elementos de un gridView, el cual se activara cuando se haga click en un elemento 
        /// y llevara a la view detalles cita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridCitas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(DetallesCita), (Cita)e.ClickedItem);//Se pasa a DetallesCita el objeto Cita seleccionado
        }
    }
}
