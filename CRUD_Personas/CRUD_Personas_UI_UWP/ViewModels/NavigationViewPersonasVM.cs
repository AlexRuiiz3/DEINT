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
using CRUD_Personas_UI_UWP.Models;
using System.Collections.ObjectModel;

namespace CRUD_Personas_UI_UWP.ViewModels
{
    public class NavigationViewPersonasVM : clsVMBase
    {

        private ObservableCollection<ClsPersona> listaPersonas;
        private ObservableCollection<ClsDepartamento> listaDepartamentos;
        private ClsPersonaModel personaSeleccionada;
        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;

        public NavigationViewPersonasVM()
        {
            listaPersonas = ListadosBL.obtenerPersonas();
            personaSeleccionada = null;
        }

        public DelegateCommand EditarCommand
        {
            get
            {
                return editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecuted);
            }
        }

        private void EditarCommand_Executed() { 
        
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

        public ClsPersonaModel PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                ClsPersona persona = value;
                ClsPersonaModel personaModel = new ClsPersonaModel(persona.Nombre,persona.Apellidos,persona.Direccion);
                personaModel.NombreDepartamento = "Se llama a un metodo que lo obtenga";
                personaSeleccionada = personaModel;
                cambiarImagen();
                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        public ImageSource Imagen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private void cambiarImagen()
        {
            ImageSource imagen = null;
            if (personaSeleccionada != null && personaSeleccionada.Foto.Length > 0)
            {
                imagen = prepararImagenAsync().Result;
            }
            else
            {
                imagen = new BitmapImage(new Uri("ms-appx:/Images/ImagenDefault.png", UriKind.RelativeOrAbsolute));
            }
            Imagen = imagen;
            NotifyPropertyChanged("Imagen");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<ImageSource> prepararImagenAsync()
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                BitmapImage imagen = new BitmapImage();
                await stream.WriteAsync(personaSeleccionada.Foto.AsBuffer());
                stream.Seek(0);
                imagen.SetSource(stream);
                return imagen;
            }
        }
    }
}
