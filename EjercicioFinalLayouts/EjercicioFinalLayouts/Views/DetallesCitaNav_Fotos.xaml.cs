using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EjercicioFinalLayouts.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetallesCitaNav_Fotos : Page
    {
        public DetallesCitaNav_Fotos()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Cabecera: private void Button_SeleccionarFotos(object sender, RoutedEventArgs e)
        /// Comentario: Este metodo esta asociado a un boton, cuando es llamado se encarga de añadir un elemento a una lista(GridView o ListView).
        /// Entradas: object sender, RoutedEventArgs e
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Este metodo se trata de un procedimiento ya que no se devuelve ningun valor. En esta caso solo 
        ///                  se amñadira un elemento a una lista View.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SeleccionarFotos(object sender, RoutedEventArgs e)
        {
            txtbFotosIncluidas.Visibility = Visibility.Collapsed;
            gridViewFotos.Items.Add("/Assets/icono.png"); //Aqui se deberia de llamar a la galeria, para poder seleccionar una foto e incluirla
            
        }

        /// <summary>
        /// Evento asociado al boton Incluir fotos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_IncluirFotos(object sender, RoutedEventArgs e)
        {
            if (gridViewFotos.Items.Count > 0)
            {
                txtbFotosIncluidas.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Cabecera: private void Button_EliminarFotos(object sender, RoutedEventArgs e)
        /// Comentario: Este metodo esta asociado a un boton, cuando es llamado se encarga de eliminar de una lista(GridView o ListView) el ultimo elemento que contenga.
        /// Entradas: object sender, RoutedEventArgs e
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Este metodo se trata de un procedimiento ya que no se devuelve ningun valor. En esta caso solo 
        ///                  se eliminara de una lista View el ultimo elemento que contenga siempre que haya algun elemento en la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_EliminarFotos(object sender, RoutedEventArgs e)
        { 
           if (gridViewFotos.Items.Count > 0) {
                txtbFotosIncluidas.Visibility = Visibility.Collapsed;
                gridViewFotos.Items.RemoveAt(gridViewFotos.Items.Count - 1);
            } 
        }
    }
}
