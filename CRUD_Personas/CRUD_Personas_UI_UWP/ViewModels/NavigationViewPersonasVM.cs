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

namespace CRUD_Personas_UI_UWP.ViewModels
{
    public class NavigationViewPersonasVM
    {

        private List<ClsPersona> listaPersonas;
        private ClsPersona personaSeleccionada;

        public NavigationViewPersonasVM() {
            listaPersonas = Listados.obtenerPersonasBL();
            personaSeleccionada = listaPersonas[5];
        }

        public List<ClsPersona> ListaPersonas {
            get { return listaPersonas; }
            set { listaPersonas = value; }
        }

        public ClsPersona PersonaSeleccionada {
            get { return personaSeleccionada; }
            set { value = PersonaSeleccionada; }
        }
        
        public ImageSource Imagen
        {
            get {
                return prepararImagenAsync().Result;
            }
        }
        private async Task<ImageSource> prepararImagenAsync() { 
            //if (personaSeleccionada != null && personaSeleccionada.Foto.Length > 0) {

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
