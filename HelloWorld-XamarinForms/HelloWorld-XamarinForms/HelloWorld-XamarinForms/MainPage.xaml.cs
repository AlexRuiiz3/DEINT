using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entidades;

namespace HelloWorld_XamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonVerResultado(object sender, EventArgs e)
        {
            String valorEntry = entryNombre.Text;

            if (!String.IsNullOrEmpty(valorEntry))
            {
                ClsPersona persona = new ClsPersona(valorEntry);
                DisplayAlert("Bienvenido", $"Hola: {persona.Nombre}", "Ok");
            }
            else {
                DisplayAlert("Alert", "No dejes el nombre vacio", "Ok");
            }
            
    
            
        }
    }


}
