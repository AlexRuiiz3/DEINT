using System.Linq;
using Windows.UI.Xaml.Controls;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CRUD_Personas_UI_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class NavigationViewPersonas : Page
    {
        public NavigationViewPersonas()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Metodo asociado a un Evento de un textBox que solo permite la entrada de numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TextBoxTelefono_TextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
