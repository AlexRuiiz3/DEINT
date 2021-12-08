using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CRUD_Personas_UI_UWP.Views;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CRUD_Personas_UI_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Cabecera: private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        /// Comentario: Este metodo se encarga de navegar a otra View en funcion de la pestaña que se haya seleccionado
        /// Entradas: NavigationView sender, NavigationViewItemInvokedEventArgs args
        /// Salidas: Ninguna
        /// Precondiciones: args no debera de estar a null
        /// Postcondiciones: Se navegara a la view que tenga asignada la pestaña que se haya selecciondo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string contenido = args.InvokedItem as string;

            if (!string.IsNullOrEmpty(contenido))
            {
                switch (contenido)
                {
                    case "Personas":
                        FrameNavigationView.Navigate(typeof(NavigationViewPersonas));
                        break;
                    case "Departamentos":
                        FrameNavigationView.Navigate(typeof(NavigationViewDepartamentos));
                        break;
                }
            }
        }
        /// <summary>
        /// Cabecera: private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        /// Comentario: Este metodo se encarga de especificar una view por defecto para un navigationView.
        /// Entradas: object sender, RoutedEventArgs e
        /// Salidas: Ninguna
        /// Precondicones: Ninguna.
        /// Postcondiciones: Un navigationView tendra una view que mostrar por defecto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            FrameNavigationView.Navigate(typeof(NavigationViewPersonas));
        }
    }
}
