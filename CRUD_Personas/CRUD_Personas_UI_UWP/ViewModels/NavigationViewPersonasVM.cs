using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using CRUD_Personas_UI_UWP.ViewModels.Utilidades;
using System.Collections.ObjectModel;

namespace CRUD_Personas_UI_UWP.ViewModels
{
    public class NavigationViewPersonasVM : clsVMBase
    {

        private ObservableCollection<ClsPersona> listaPersonas;
        private ObservableCollection<ClsDepartamento> listaDepartamentos;
        private ClsPersona personaSeleccionada;
        private ImageSource imagenPersona;
        private Visibility visibilidadTextBox;
        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;

        public NavigationViewPersonasVM()
        {
            listaPersonas = ListadosBL.obtenerPersonas();
            personaSeleccionada = null;
            visibilidadTextBox = Visibility.Collapsed;
        }

        public DelegateCommand EditarCommand
        {
            get
            {
                return editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecuted);
            }
        }

        private void EditarCommand_Executed() {
            visibilidadTextBox = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadTextBox");

        }

        private bool EditarCommand_CanExecuted() {
            return personaSeleccionada!=null;
        }

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
            return personaSeleccionada!=null;
        }

        public ObservableCollection<ClsPersona> ListaPersonas
        {
            get { return listaPersonas; }
            set { listaPersonas = value; }
        }

        public ClsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                ClsPersona persona = value;
                //ClsPersonaModel personaModel = new ClsPersonaModel(persona.Nombre,persona.Apellidos,persona.Direccion);
                //persona.NombreDepartamento = "Se llama a un metodo que lo obtenga";
                personaSeleccionada = persona;
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
            else {
                imagen = new BitmapImage(new Uri("ms-appx:/Images/ImagenDefault.png", UriKind.RelativeOrAbsolute));
            }
            imagenPersona = imagen;
            NotifyPropertyChanged("Imagen");
        }

        public Visibility VisibilidadTextBox
        {
            get 
            {
                return visibilidadTextBox;
            }
        }
    }
}
