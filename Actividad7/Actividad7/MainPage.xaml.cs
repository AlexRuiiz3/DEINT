using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Actividad7
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {

            Button boton = new Button();

            boton.Content = "Boton 3";
            boton.HorizontalContentAlignment = HorizontalAlignment.Center;
            boton.VerticalContentAlignment = VerticalAlignment.Center;
            boton.Background = new SolidColorBrush(Colors.Blue);
            boton.Height = 70;
            boton.Width = 200;
            boton.FontFamily = new FontFamily("Verdana");
            boton.FontSize = 16;
            boton.FontWeight = FontWeights.Bold;
            boton.BorderBrush = new SolidColorBrush(Colors.Yellow);
            boton.Margin = new Thickness(30);
            boton.Click += Button3_Click; //De esta manera se añade la funcion al hacer click
            panelStack.Children.Add(boton); //Se añade el boton al stackPanel(Que tiene que tener definido un nombre)

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, RoutedEventArgs e) {

            Button boton = Button1;

            panelStack.Children.Remove(Button1);     

        }
    }
}
