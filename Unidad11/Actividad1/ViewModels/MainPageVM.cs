using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actividad1.ViewModels.Utilidades;
using Dal;
using Entidades;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Actividad1.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<ClsPersona> listadoPersonas = GestoraPersonas.obtenerPersonas();
        private ClsPersona personaSeleccionada;
        public ObservableCollection<ClsPersona> ListadoPersonas { get { return listadoPersonas; } set { listadoPersonas = value; } }
        
        public ClsPersona PersonaSeleccionada { get { return personaSeleccionada; } set { personaSeleccionada = value; } }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_EliminarPersona(object sender, RoutedEventArgs e)
        {
            bool eliminada = false;

            if (personaSeleccionada != null)
            {
                for (int i = 0; i < listadoPersonas.Count && !eliminada; i++)
                {
                    if (personaSeleccionada.Equals(listadoPersonas.ElementAt(i)))
                    {
                        listadoPersonas.RemoveAt(i);
                        eliminada = true;
                    }
                }
            }

        }
    }
}
