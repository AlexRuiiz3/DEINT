using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dal;
using Actividad3.ViewModels.Utilidades;

namespace Actividad3.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private String textBoxBuscar;
        private ObservableCollection<ClsPersona> listaPersonasOriginal;
        private ObservableCollection<ClsPersona> listaPersonasBuscadas;
        private DelegateCommand filtrarCommand;
        private DelegateCommand eleminarCommand;
        private ClsPersona personaSeleccionada;

        //Constructor
        public MainPageVM()
        {
            listaPersonasOriginal = GestoraPersonas.obtenerPersonas();
            listaPersonasBuscadas = listaPersonasOriginal;
            eleminarCommand = new DelegateCommand(eliminarCommand_Execute, eliminarCommand_CanExecute);
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

        public String TextBoxBuscar
        {
            get { return textBoxBuscar; }
            set
            {
                textBoxBuscar = value;
                filtrarCommand.RaiseCanExecuteChanged();
            }
        }

        public ClsPersona PersonaSeleccionada
        {

            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                eleminarCommand.RaiseCanExecuteChanged();
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
            ListaPersonas = new ObservableCollection<ClsPersona>(from persona in listaPersonasOriginal
                                                                 where persona.Nombre.Contains(textBoxBuscar) ||
                                                                       persona.Apellidos.Contains(textBoxBuscar)
                                                                 select persona);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>bool texBoxBuscarLleno</returns>
        private bool filtrarCommand_CanExecute()
        {
            bool texBoxBuscarLleno = true;

            if (String.IsNullOrEmpty(textBoxBuscar)) //Si en el contenido del textBox no ha nada
            {
                texBoxBuscarLleno = false;
                ListaPersonas = listaPersonasOriginal;
            }
            return texBoxBuscarLleno;
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                return eleminarCommand;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void eliminarCommand_Execute()
        {
            int posicionPersona = listaPersonasBuscadas.IndexOf(personaSeleccionada);
            listaPersonasBuscadas.RemoveAt(posicionPersona);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> bool </returns>
        private bool eliminarCommand_CanExecute()
        {
            return (personaSeleccionada != null);
        }

    }
}
