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
        /*
        public async ImageSource Imagen()
        {
            get {
                //ImageSource imagen;
                BitmapImage imagen2 = new BitmapImage(); ;
                //if (personaSeleccionada != null && personaSeleccionada.Foto.Length > 0) {

                BitmapImage image = new BitmapImage();
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await stream.WriteAsync(bytes.AsBuffer());
                    stream.Seek(0);
                    await image.SetSourceAsync(stream);
                }
                return image;
            }
        }*/
        public void holaAsync() {


            //if (personaSeleccionada != null && personaSeleccionada.Foto.Length > 0) {


        }
    }
}
