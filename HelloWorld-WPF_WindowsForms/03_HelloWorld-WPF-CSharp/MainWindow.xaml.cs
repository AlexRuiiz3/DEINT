using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MisClases;

namespace _03_HelloWorld_WPF_CSharp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Prototipo: private void Button_Click(object sender, RoutedEventArgs e)
        /// Comentario: Evento asociado al hacer click en el boton 'soy un boton'
        /// Entradas: object sender, RoutedEventArgs e
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se trata de un procedimiento el cual al llamarse se mostrata un mensaje con el 
        ///                  valor que hay un Texbox llamado texbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*Simplificado, si no se define ningun constructor:
                ClsPersona persona = new ClsPersona { Nombre = TextBox.Text }; 
            */
            ClsPersona persona;

            if (!String.IsNullOrEmpty(txtNombre.Text)) //Comprueba si una cadena esta vacia o null
            {
                persona = new ClsPersona(txtNombre.Text);
                MessageBox.Show($"Hola {persona.Nombre}");
            }
            else
            {
                MessageBox.Show("Ingrese un nombre.");
            }
        }
    }
}
