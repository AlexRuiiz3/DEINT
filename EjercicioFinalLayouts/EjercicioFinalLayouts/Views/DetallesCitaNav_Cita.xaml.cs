using EjercicioFinalLayouts.ViewModels;
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
    public sealed partial class DetallesCitaNav_Cita : Page
    {

        public DetallesCitaNavCitaViewVM DetallesCitaNavCitaViewVM { get; set; }

        public DetallesCitaNav_Cita()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Metodo para coger el parametro que recibe esta view
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            /*De esta manera esta View obtiene el objeto Cita que se seleciono, no se si es la marea correcta ya que para crear
              el ViewModel DetallesCitaNavCitaViewVM se necesita el objeto Cita creado, por lo tanto se tiene que crear el
              ViewModel aqui*/
            DetallesCitaNavCitaViewVM = new DetallesCitaNavCitaViewVM((Cita)e.Parameter, "Mariano Rajoy", "645813975");
        }
    }
}
