using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actividad4.Models;

namespace Actividad4.ViewModels
{
    public class MainPageViewVM : INotifyPropertyChanged
    {
        private ObservableCollection<ClsPersona> listaPersonas = new ObservableCollection<ClsPersona>(ClsListados.obtenerPersonas());
        private ClsPersona personaSeleccionada;

        public ObservableCollection<ClsPersona> ListaPersonas { get { return listaPersonas; } }

        public ClsPersona PersonaSeleccionada
        {

            get { return personaSeleccionada; }
            set { 
                personaSeleccionada = value;
                OnPropertyChanged("PersonaSeleccionada");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
