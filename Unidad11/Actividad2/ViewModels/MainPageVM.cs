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
        private String textBoxBuscar;
        private ObservableCollection<ClsPersona> listaPersonasOriginal;
        private ObservableCollection<ClsPersona> listaPersonasBuscadas;
        private DelegateCommand filtrarCommand;

        //Constructor
        public MainPageVM()
        {
            listaPersonasOriginal = GestoraPersonas.obtenerPersonas();
            listaPersonasBuscadas = listaPersonasOriginal;
        }

        public ObservableCollection<ClsPersona> ListaPersonasBuscadas
        {
            get { return listaPersonasBuscadas; }
            /*set
            { Mejor no poner set y notificar la propiedad privada cuando cambie
                listaPersonasBuscadas = value;
                NotifyPropertyChanged("ListaPersonasBuscadas");
            }*/
        }

        public String TextBoxBuscar
        {
            get { return textBoxBuscar; }
            set
            {
                textBoxBuscar = value;
                filtrarCommand.RaiseCanExecuteChanged();

                if (String.IsNullOrEmpty(textBoxBuscar))
                {
                    listaPersonasBuscadas = listaPersonasOriginal;
                    NotifyPropertyChanged("ListaPersonasBuscadas");
                }
            }
        }

        public DelegateCommand FiltrarCommand
        {
            get
            {
                return filtrarCommand = new DelegateCommand(filtrarCommand_Executed, filtrarCommand_CanExecute);
            }
        }
        /// <summary>
        /// Cabecera:
        /// Comentario:
        /// </summary>
        private void filtrarCommand_Executed()
        {

            listaPersonasBuscadas = new ObservableCollection<ClsPersona>(from persona in listaPersonasOriginal
                                                                 where persona.Nombre.ToLower().Contains(textBoxBuscar) ||
                                                                       persona.Apellidos.ToLower().Contains(textBoxBuscar)
                                                                 select persona);
            NotifyPropertyChanged("ListaPersonasBuscadas");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>bool texBoxBuscarLleno</returns>
        private bool filtrarCommand_CanExecute()
        {
            return !String.IsNullOrEmpty(textBoxBuscar);
        }
    }
}
