using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unidad16Ejercicio1Entidades;
using Unidad16Ejercicio1UI.ViewModels.Utilidades;
using Unidad16Ejercicio1BL.Gestora;
using Unidad16Ejercicio1BL.Listados;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace Unidad16Ejercicio1UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private ClsPersona personaSeleccionada;
        private List<ClsPersona> listaPersonas;
        private DelegateCommand listarCommand;
        private DelegateCommand eliminarCommand;
        private bool visibilidadIndicadorCargando;

        public MainPageVM()
        {
            listaPersonas = new List<ClsPersona>();
            visibilidadIndicadorCargando = false;
            NotifyPropertyChanged("VisibilidadIndicadorCargando");
        }

        public DelegateCommand ListarCommand
        {
            get { return listarCommand = new DelegateCommand(ListarCommand_Executed, ListarCommand_CanExecuted); }
        }

        private async void ListarCommand_Executed()
        {
            visibilidadIndicadorCargando = true;
            NotifyPropertyChanged("VisibilidadIndicadorCargando");

            try
            {
                listaPersonas = await ListadosBL.obtenerPersonas();
                NotifyPropertyChanged("ListaPersonas");
            }
            catch (Exception)
            {
                //Notificar error
            }

            visibilidadIndicadorCargando = false;
            NotifyPropertyChanged("VisibilidadIndicadorCargando");
        }

        private bool ListarCommand_CanExecuted()
        {
            return listaPersonas.Count == 0;
        }

        public DelegateCommand EliminarCommand
        {
            get { return eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted); }
        }

        public async void EliminarCommand_Executed()
        {
            try
            {//Preguntar borrar y el estado.En funcion del estado devuelto informar mensaje determinado
                HttpStatusCode estadoRespuesta = await GestoraPersonasBL.eliminarPersona(personaSeleccionada.ID);
                if (estadoRespuesta == HttpStatusCode.NotFound)
                {
                    //Recurso no encontrado
                }
                else if(estadoRespuesta == HttpStatusCode.OK)
                {
                    listaPersonas = new List<ClsPersona>(from persona in listaPersonas
                                                         where persona.ID != personaSeleccionada.ID
                                                         select persona);
                    NotifyPropertyChanged("ListaPersonas");
                }
            }
            catch (Exception)
            {
                //Notificar error
            }
        }

        public bool EliminarCommand_CanExecuted()
        {
            return personaSeleccionada != null;
        }

        public ClsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public List<ClsPersona> ListaPersonas
        {
            get { return listaPersonas; }
            set
            {
                listaPersonas = value;
            }
        }

        public bool VisibilidadIndicadorCargando { get { return visibilidadIndicadorCargando; } }
    }
}
