using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Entidades;
using Dal;
using Actividad2.ViewModels.Utilidades;


namespace Actividad2.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<ClsPersona> listaPersonasOriginal;
        private ObservableCollection<ClsPersona> listaPersonasBuscadas;
        private DelegateCommand filtrarCommand;

        //Constructor
        public MainPageVM()
        {
            listaPersonasOriginal = GestoraPersonas.obtenerPersonas();
            listaPersonasBuscadas = listaPersonasOriginal;
        }

        public ObservableCollection<ClsPersona> ListaPersonas
        {
            get { return listaPersonasBuscadas; }
            set
            {
                listaPersonasBuscadas = value;
                NotifyPropertyChanged("ListaPersonas");
            }
        }

        public String textBoxBuscar
        {
            get { return ""; }
            set { filtrarCommand.RaiseCanExecuteChanged(); }
        }

        public DelegateCommand FiltrarCommand
        {
            get
            {
                return filtrarCommand = new DelegateCommand(filtrarCommand_Executed, filtrarCommand_CanExecute);
            }
        }

        private void filtrarCommand_Executed()
        {

            ListaPersonas = new ObservableCollection<ClsPersona>(from p in listaPersonasOriginal
                                                                 where p.Nombre.Contains("1") || p.Apellidos.Contains("1")
                                                                 select p);
        }
        private bool filtrarCommand_CanExecute()
        {
            bool algoEscrito = true;

            return algoEscrito;
        }
    }
}
