using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CRUD_Personas_UI_UWP.ViewModels.Utilidades;
using CRUD_Personas_UI_UWP.Models;
using CRUD_Personas_Entidades;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Gestora;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using System.Data.SqlClient;

namespace CRUD_Personas_UI_UWP.ViewModels
{
    public class NavigationViewDepartamentosVM : clsVMBase
    {

        private ObservableCollection<ClsDepartamentoConPersonas> listaDepartamentosOriginal;
        private ObservableCollection<ClsDepartamentoConPersonas> listaDepartamentosBuscados;

        private ClsDepartamentoConPersonas departamentoSeleccionado;
        private ClsDepartamentoConPersonas departamentoSeleccionadoSinModificar;
        private string textBoxBuscar;

        private Visibility visibilidadCampos;
        private Visibility visibilidadCamposEditables;
        private Visibility visibilidadCamposResultados;

        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand guardarCommand;
        private DelegateCommand atrasCommand;
        private DelegateCommand buscarCommand;

        public NavigationViewDepartamentosVM()
        {
            try
            {
                //Preparacion Listas
                llenarListaDepartamentosOriginal();
                listaDepartamentosBuscados = listaDepartamentosOriginal;
            }
            catch (Exception)
            {
                mostrarMensajeErrorAsync();
            }

            //Inicializacion Commands
            atrasCommand = new DelegateCommand(AtrasCommand_Executed, AtrasCommand_CanExecuted);
            guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecuted);
            eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
            editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecuted);


            visibilidadCampos = Visibility.Visible;
            visibilidadCamposEditables = Visibility.Collapsed;
            visibilidadCamposResultados = Visibility.Collapsed;
        }

        #region Commands
        //Command editar
        public DelegateCommand EditarCommand
        {
            get
            {
                return editarCommand;
            }
        }

        private void EditarCommand_Executed()
        {
            departamentoSeleccionadoSinModificar = departamentoSeleccionado;
            visibilidadCampos = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadCamposEditables = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCamposEditables");
            visibilidadCamposResultados = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCamposResultados");

            guardarCommand.RaiseCanExecuteChanged();
            atrasCommand.RaiseCanExecuteChanged();
        }

        private bool EditarCommand_CanExecuted()
        {
            return departamentoSeleccionado != null && departamentoSeleccionado.ID != 0; //La persona que tenga el id 0 sera una persona por defecto
        }
        //Command eliminar
        public DelegateCommand EliminarCommand
        {
            get
            {
                return eliminarCommand;
            }
        }

        private void EliminarCommand_Executed()
        {
            if (departamentoSeleccionado.ListaPersonas.Count == 0)
            {
                try
                {
                    GestoraDepartamentoBL.eliminarDepartamento(departamentoSeleccionado.ID);
                    llenarListaPersonasOriginal();
                    listaPersonasBuscadas = listaPersonasOriginal;
                    NotifyPropertyChanged("ListaPersonasBuscadas");

                    if (listaPersonasOriginal.Count > 0)
                    {
                        personaSeleccionada = listaPersonasOriginal.ElementAt(0);
                    }
                    else
                    { //Cuando sea haya eliminado la ultima persona de la lista, se mostrara una por defecto
                        personaSeleccionada = new ClsPersonaConDepartamento();
                    }
                    NotifyPropertyChanged("PersonaSeleccionada");
                    cambiarImagenAsync();

                    //Modificacion visibilidad campos
                    visibilidadCampos = Visibility.Visible;
                    NotifyPropertyChanged("VisibilidadCampos");
                    visibilidadCamposEditables = Visibility.Collapsed;
                    NotifyPropertyChanged("VisibilidadCamposEditables");
                    visibilidadCamposResultados = Visibility.Visible;
                    NotifyPropertyChanged("VisibilidadCamposResultados");

                    //Comprobacion estado Commands
                    guardarCommand.RaiseCanExecuteChanged();
                    eliminarCommand.RaiseCanExecuteChanged();
                    editarCommand.RaiseCanExecuteChanged();
                    atrasCommand.RaiseCanExecuteChanged();
                }
                catch (SqlException)
                {
                    mostrarMensajeErrorAsync();
                }
            }
            else
            {
                mostrarMensajeErrorEliminarAsync();
            }
        }

        private bool EliminarCommand_CanExecuted()
        {
            return departamentoSeleccionado != null && departamentoSeleccionado.ID != 0;
        }
        //Command guardar
        public DelegateCommand GuardarCommand
        {
            get
            {
                return guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecuted);
            }
        }

        private void GuardarCommand_Executed()
        {
            try
            {
                if (departamentoSeleccionado.ID != 0) //Si el id de la persona es distinto de 0, significa que es una persona que ya existe y no una nueva
                {
                    GestoraDepartamentoBL.editarDepartamento(departamentoSeleccionado);
                }
                else
                {
                    GestoraDepartamentoBL.anhadirDepartamento(departamentoSeleccionado);
                }
                llenarListaDepartamentosOriginal();
                listaDepartamentosBuscados = listaDepartamentosOriginal;
                NotifyPropertyChanged("ListaDepartamentosBuscados");

                visibilidadCampos = Visibility.Visible;
                NotifyPropertyChanged("VisibilidadCampos");
                visibilidadCamposEditables = Visibility.Collapsed;
                NotifyPropertyChanged("VisibilidadCamposEditables");
                visibilidadCamposResultados = Visibility.Visible;
                NotifyPropertyChanged("VisibilidadCamposResultados");

                guardarCommand.RaiseCanExecuteChanged();
                atrasCommand.RaiseCanExecuteChanged();
            }

            catch (SqlException)
            {
                mostrarMensajeDatoInvalidoAsync();
            }
        }

        private bool GuardarCommand_CanExecuted()
        {
            return visibilidadCamposEditables == Visibility.Visible;
        }


        //Command detalles
        public DelegateCommand AtrasCommand
        {
            get
            {
                return atrasCommand = new DelegateCommand(AtrasCommand_Executed, AtrasCommand_CanExecuted);
            }
        }

        private void AtrasCommand_Executed()
        {
            visibilidadCampos = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadCamposEditables = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCamposEditables");

            guardarCommand.RaiseCanExecuteChanged();
            atrasCommand.RaiseCanExecuteChanged();
        }

        private bool AtrasCommand_CanExecuted()
        {
            return visibilidadCamposEditables == Visibility.Visible;
        }

        //Command añadir
        public DelegateCommand AnhadirCommand
        {
            get
            {
                return new DelegateCommand(anhadirCommand_Executed);
            }
        }

        private void anhadirCommand_Executed()
        {
            departamentoSeleccionado = new ClsDepartamentoConPersonas();
            NotifyPropertyChanged("DepartamentoSeleccionado");

            visibilidadCampos = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadCamposEditables = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCamposEditables");
            visibilidadCamposResultados = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCamposResultados");

            TextBoxBuscar = "";//Se resetea el texto del textBox

            editarCommand.RaiseCanExecuteChanged();
            guardarCommand.RaiseCanExecuteChanged();
            eliminarCommand.RaiseCanExecuteChanged();
        }
        //Command buscar
        public DelegateCommand BuscarCommand
        {
            get
            {
                return buscarCommand = new DelegateCommand(bucarCommand_Executed, buscarCommand_CanExecuted);
            }
        }

        private void bucarCommand_Executed()
        {
            listaDepartamentosBuscados = new ObservableCollection<ClsDepartamentoConPersonas>(from departamento in listaDepartamentosOriginal
                                                                                              where departamento.Nombre.ToLower().Contains(textBoxBuscar)
                                                                                              select departamento);
            NotifyPropertyChanged("ListaDepartamentosBuscados");
        }

        private bool buscarCommand_CanExecuted()
        {
            bool textBoxLleno = true;
            if (string.IsNullOrEmpty(textBoxBuscar))
            {
                textBoxLleno = false;
                listaDepartamentosBuscados = listaDepartamentosOriginal;
                NotifyPropertyChanged("ListaDepartamentosBuscados");
            }
            return textBoxLleno;
        }
        #endregion

        #region Propiedades
        //ListaDepartamentosBuscados
        public ObservableCollection<ClsDepartamentoConPersonas> ListaDepartamentosBuscados
        {
            get { return listaDepartamentosBuscados; }
            set { listaDepartamentosBuscados = value; }
        }
        //DepartamentoSeleccionado
        public ClsDepartamentoConPersonas DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged("DepartamentoSelccionado");

                visibilidadCampos = Visibility.Visible;
                NotifyPropertyChanged("VisibilidadCampos");
                visibilidadCamposEditables = Visibility.Collapsed;
                NotifyPropertyChanged("VisibilidadCamposEditables");
                visibilidadCamposResultados = Visibility.Collapsed;
                NotifyPropertyChanged("VisibilidadCamposResultados");

                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
                atrasCommand.RaiseCanExecuteChanged();
            }
        }
        //TextBoxBuscar
        public string TextBoxBuscar
        {
            get
            {
                return textBoxBuscar;
            }
            set
            {
                textBoxBuscar = value;
                NotifyPropertyChanged("TextBoxBuscar");

                buscarCommand.RaiseCanExecuteChanged();
            }
        }
        //VisibiliadCamposEdibles
        public Visibility VisibilidadCamposEditables
        {
            get { return visibilidadCamposEditables; }
        }

        //VisibilidadCampos
        public Visibility VisibilidadCampos
        {
            get { return visibilidadCampos; }
        }

        //VisibilidadCamposResultados
        public Visibility VisibilidadCamposResultados
        {
            get { return visibilidadCamposResultados; }
        }
        #endregion

        /// <summary>
        /// Cabecera: private async void mostrarMensajeErrorAsync()
        /// Comentario: Este metodo se encarga de mostrar un MessageDialog con un mensaje que tendra una opcion de cerrar.
        /// Entradas: Ninguna
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se mostrara un mensaje al usuario en un MessageDialog, que contentra una opcion de cerrar.
        /// </summary>
        private async void mostrarMensajeErrorAsync()
        {
            var dialog = new MessageDialog("¡Ha ocurrido un error al establecer la conexion a la base de datos!.\n-El servicio puede no estar disponible.\n-Asegurece de estar conectado a una red Wifi.");
            await dialog.ShowAsync();
        }
        /// <summary>
        /// Cabecera: private async void mostrarMensajeDatoInvalidoAsync()
        /// Comentario: Este metodo se encarga de mostrar un MessageDialog con un mensaje que tendra una opcion de cerrar.
        /// Entradas: Ninguna
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se mostrara un mensaje al usuario en un MessageDialog, que contentra una opcion de cerrar.
        /// </summary>
        private async void mostrarMensajeDatoInvalidoAsync()
        {
            var dialog = new MessageDialog("Ha ocurrido un error. Estos pueden ser alguno de los motivos: \n-Algun dato ingresado no es valido o es obligatorio.\n-Error al establecer la conexion a la base de datos.");
            await dialog.ShowAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        private async void mostrarMensajeErrorEliminarAsync()
        {
            var dialog = new MessageDialog("Ha ocurrido un error. No se puede eliminar un departamento que tiene personas asociadas.");
            await dialog.ShowAsync();
        }
        private void llenarListaDepartamentosOriginal()
        {

            List<ClsPersona> listaPersonas = ListadosBL.obtenerPersonas();
            List<ClsDepartamento> listaDepartamentos = ListadosBL.obtenerDepartamentos();
            List<ClsPersona> listaPersonasDeUnDepartamento = new List<ClsPersona>();

            listaDepartamentosOriginal = new ObservableCollection<ClsDepartamentoConPersonas>();

            foreach (ClsDepartamento departamento in listaDepartamentos)
            {
                listaPersonasDeUnDepartamento = new List<ClsPersona>(from persona in listaPersonas
                                                                     where persona.IdDepartamento == departamento.ID
                                                                     select persona);

                listaDepartamentosOriginal.Add(new ClsDepartamentoConPersonas(departamento, listaPersonasDeUnDepartamento));
            }
        }
    }
}
