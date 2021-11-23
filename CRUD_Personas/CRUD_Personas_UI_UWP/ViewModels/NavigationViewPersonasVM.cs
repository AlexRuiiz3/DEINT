using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using CRUD_Personas_UI_UWP.ViewModels.Utilidades;
using System.Collections.ObjectModel;
using CRUD_Personas_UI_UWP.Models;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_UWP.ViewModels
{
    public class NavigationViewPersonasVM : clsVMBase
    {

        private ObservableCollection<ClsPersonaConDepartamento> listaPersonas;
        private ObservableCollection<ClsDepartamento> listaDepartamentos;
        private ClsPersonaConDepartamento personaSeleccionada;
        private ImageSource imagenPersona;
        private Visibility visibilidadCampos;
        private Visibility visibilidadTextBox;
        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand guardarCommand;

        public NavigationViewPersonasVM()
        {
            List<ClsPersona> personasBL = ListadosBL.obtenerPersonas();
            listaPersonas = new ObservableCollection<ClsPersonaConDepartamento>();
            foreach (ClsPersona persona in personasBL)
            {
                listaPersonas.Add(new ClsPersonaConDepartamento(persona, ListadosBL.obtenerNombreDepartamento(persona.IdDepartamento)));
            }
            listaDepartamentos = new ObservableCollection<ClsDepartamento>(ListadosBL.obtenerDepartamentos());
            personaSeleccionada = null;
            visibilidadCampos = Visibility.Visible;
            visibilidadTextBox = Visibility.Collapsed;
        }
         #region Commands
        //Command editar
        public DelegateCommand EditarCommand
        {
            get
            {
                return editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecuted);
            }
        }
       
        private void EditarCommand_Executed()
        {
            visibilidadCampos = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadTextBox = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadTextBox");
            guardarCommand.RaiseCanExecuteChanged();

        }

        private bool EditarCommand_CanExecuted()
        {
            return personaSeleccionada != null;
        }
        //Command eliminar
        public DelegateCommand EliminarCommand
        {
            get
            {
                return eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
            }
        }

        private void EliminarCommand_Executed()
        {

        }

        private bool EliminarCommand_CanExecuted()
        {
            return personaSeleccionada != null;
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
            if (GestoraPersonasBL.editarPersona(personaSeleccionada) > 0) {
                visibilidadCampos = Visibility.Visible;
                NotifyPropertyChanged("VisibilidadCampos");
                visibilidadTextBox = Visibility.Collapsed;
                NotifyPropertyChanged("VisibilidadTextBox");
                guardarCommand.RaiseCanExecuteChanged();

                List<ClsPersona> personasBL = ListadosBL.obtenerPersonas();
                listaPersonas = new ObservableCollection<ClsPersonaConDepartamento>();
                foreach (ClsPersona persona in personasBL)
                {
                    listaPersonas.Add(new ClsPersonaConDepartamento(persona, ListadosBL.obtenerNombreDepartamento(persona.IdDepartamento)));
                }
            }
        }

        private bool GuardarCommand_CanExecuted()
        {
            return visibilidadTextBox == Visibility.Visible;
        }
        #endregion
        public ObservableCollection<ClsPersonaConDepartamento> ListaPersonas
        {
            get { return listaPersonas; }
            set { listaPersonas = value; }
        }

        public ClsPersonaConDepartamento PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");

                cambiarImagenAsync();

                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public ImageSource Imagen { get { return imagenPersona; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async void cambiarImagenAsync()
        {
            BitmapImage imagen;
            if (personaSeleccionada != null && personaSeleccionada.Foto.Length > 0)
            {
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    imagen = new BitmapImage();
                    await stream.WriteAsync(personaSeleccionada.Foto.AsBuffer());
                    stream.Seek(0);
                    imagen.SetSource(stream);
                }
            }
            else
            {
                imagen = new BitmapImage(new Uri("ms-appx:/Images/ImagenDefault.png", UriKind.RelativeOrAbsolute));
            }
            imagenPersona = imagen;
            NotifyPropertyChanged("Imagen");
        }

        public Visibility VisibilidadTextBox
        {
            get { return visibilidadTextBox; }
        }
        public Visibility VisibilidadCampos
        {
            get { return visibilidadCampos; }
        }
    }
}
