using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actividad1.ViewModels.Utilidades;
using Dal;
using Entidades;
using Windows.UI.Xaml;


namespace Actividad1.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private List<ClsPersona> listadoPersonas = GestoraPersonas.obtenerPersonas();

        public List<ClsPersona> ListadoPersonas {
            get { return listadoPersonas; }
            set { listadoPersonas = value; }
        }

        public void button_EliminarPersona(object sender, RoutedEventArgs e) {
            if (ListadoPersonas.Count > 0) {
                ListadoPersonas.RemoveAt(ListadoPersonas.Count - 1);
                NotifyPropertyChanged("ListadoPersonas");
            }
        }
    }
}
