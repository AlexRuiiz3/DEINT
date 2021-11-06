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
using Entidades;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EjercicioFinalLayouts.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetallesCita : Page
    {
        private Cita Cita { get; set; } 

        public DetallesCita()
        {
            this.InitializeComponent();

        }
        /// <summary>
        /// Metodo para coger el parametro que recibe esta view. En este caso una Cita
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Cita = (Cita)e.Parameter;
        }

        /// <summary>
        /// Metodo asociado al elemento seleccionado de Navigationview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            String content = args.InvokedItem as String;
            if (!String.IsNullOrEmpty(content)) {

                switch (content) {
                    case "Cita":
                        ContNavigationView.Navigate(typeof(DetallesCitaNav_Cita), Cita);
                    break;

                    case "Fotos":
                        ContNavigationView.Navigate(typeof(DetallesCitaNav_Fotos));
                    break;

                    case "Anotaciones":
                        ContNavigationView.Navigate(typeof(DetallesCitaNav_Anotaciones));
                    break;

                }
            }
        }

        /// <summary>
        /// Metodo asociado al boton de atras de NavigationView, el cual llevara a la view de las citas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.Navigate(typeof(CitasPage));
        }

        /// <summary>
        /// Metodo para que NavigationView tenga una pagina que mostrar por defecto, en este caso la view con los detalles de la cita 
        /// seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContNavigationView.Navigate(typeof(DetallesCitaNav_Cita), Cita);
        }
    }
}

