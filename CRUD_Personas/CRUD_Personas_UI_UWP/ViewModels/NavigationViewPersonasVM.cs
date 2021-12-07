using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using CRUD_Personas_UI_UWP.ViewModels.Utilidades;
using System.Collections.ObjectModel;
using CRUD_Personas_UI_UWP.Models;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_Entidades;
using Windows.Storage;
using Windows.UI.Popups;
using System.Data.SqlClient;
using System.Linq;

namespace CRUD_Personas_UI_UWP.ViewModels
{
    public class NavigationViewPersonasVM : clsVMBase
    {
        #region Atributos
        private ObservableCollection<ClsPersonaConDepartamento> listaPersonasOriginal;
        private ObservableCollection<ClsPersonaConDepartamento> listaPersonasBuscadas;
        private ObservableCollection<ClsDepartamento> listaDepartamentos;

        private ClsPersonaConDepartamento personaSeleccionada;
        private ClsPersonaConDepartamento personaSeleccionadaSinModificar;
        private ImageSource imagenPersona;
        private string textBoxBuscar;

        private Visibility visibilidadCampos;
        private Visibility visibilidadCamposEditables;
        private Visibility visibilidadCamposResultados;

        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand guardarCommand;
        private DelegateCommand cambiarFotoCommand;
        private DelegateCommand atrasCommand;
        private DelegateCommand buscarCommand;
        #endregion

        public NavigationViewPersonasVM()
        {
            try
            {
                //Preparacion Listas 
                listaDepartamentos = new ObservableCollection<ClsDepartamento>(ListadosBL.obtenerDepartamentos());
                llenarListaPersonasOriginal();
                listaPersonasBuscadas = listaPersonasOriginal;
            }
            catch (SqlException)
            {
                mostrarMensajeErrorAsync();
            }

            //Inicializacion Commands
            atrasCommand = new DelegateCommand(AtrasCommand_Executed, AtrasCommand_CanExecuted);
            guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecuted);
            cambiarFotoCommand = new DelegateCommand(CambiarFotoCommand_Executed, CambiarFotoCommand_CanExecuted);
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
            personaSeleccionadaSinModificar = new ClsPersonaConDepartamento(personaSeleccionada);//Se guarda la persona seleccionada con los valores sin editar, por que puede ser que el usuario edite algun campo pero luego haga click en Atras por lo tanto, personaSeleccionada tiene que volver a tener los mismos valores que antes de entrar en el modo editar
            visibilidadCampos = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadCamposEditables = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCamposEditables");
            visibilidadCamposResultados = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCamposResultados");

            guardarCommand.RaiseCanExecuteChanged();
            cambiarFotoCommand.RaiseCanExecuteChanged();
            atrasCommand.RaiseCanExecuteChanged();
        }

        private bool EditarCommand_CanExecuted()
        {
            return personaSeleccionada != null && personaSeleccionada.ID != 0; //La persona que tenga el id 0 sera una persona por defecto
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
            try {
                GestoraPersonasBL.eliminarPersona(personaSeleccionada.ID);
                llenarListaPersonasOriginal();
                listaPersonasBuscadas = listaPersonasOriginal;
                NotifyPropertyChanged("ListaPersonasBuscadas");

                if (listaPersonasOriginal.Count > 0)
                {
                    personaSeleccionada = listaPersonasOriginal.ElementAt(0);
                }
                else { //Cuando sea haya eliminado la ultima persona de la lista, se mostrara una por defecto
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
                cambiarFotoCommand.RaiseCanExecuteChanged();
                atrasCommand.RaiseCanExecuteChanged();
            }
            catch (SqlException) {
                mostrarMensajeErrorAsync();
            }

        }

        private bool EliminarCommand_CanExecuted()
        {
            return personaSeleccionada != null && personaSeleccionada.ID != 0;
        }
        //Command guardar
        public DelegateCommand GuardarCommand
        {
            get
            {
                return guardarCommand;
            }
        }

        private void GuardarCommand_Executed()
        {
            try
            {

                int idPersonaSeleccionada = personaSeleccionada.ID;
                //Si el nombre o apellido o direccion o telefono de la persona estan vacios
                //Trim() Elimina los espacios es blanco tanto del principio como del final
                if (string.IsNullOrEmpty(personaSeleccionada.Nombre.Trim()) || string.IsNullOrEmpty(personaSeleccionada.Apellidos.Trim())
                    || string.IsNullOrEmpty(personaSeleccionada.Telefono.Trim()) || string.IsNullOrEmpty(personaSeleccionada.Direccion.Trim())) {
                    mostrarMensajeDatoInvalidoAsync();
                }
                else { 
                    if (personaSeleccionada.ID != 0) //Si el id de la persona es distinto de 0, significa que es una persona que ya existe y no una nueva
                    {
                        GestoraPersonasBL.editarPersona(personaSeleccionada);
                    }
                    else
                    {
                        GestoraPersonasBL.anhadirPersona(personaSeleccionada);
                    }
                    llenarListaPersonasOriginal();
                    listaPersonasBuscadas = listaPersonasOriginal;
                    NotifyPropertyChanged("ListaPersonasBuscadas");

                    

                    //Al volver a obtener las listas, personaSeleccionada es igual a null, por lo tanto se busca cual es la persona seleccionada editada o añadida
                    if (idPersonaSeleccionada == 0) { //Si es igual a 0 significa que se añadio una persona, por lo tanto hay que buscar en la lista de personas original la ultima persona añadida y coger su ID
                        idPersonaSeleccionada = listaPersonasOriginal.ElementAt(listaPersonasOriginal.Count()-1).ID;
                    }
                    personaSeleccionada = (from persona in listaPersonasOriginal
                                           where persona.ID == idPersonaSeleccionada
                                           select persona).ElementAt(0);
                    NotifyPropertyChanged("PersonaSeleccionada");
                    cambiarImagenAsync();


                    visibilidadCampos = Visibility.Visible;
                    NotifyPropertyChanged("VisibilidadCampos");
                    visibilidadCamposEditables = Visibility.Collapsed;
                    NotifyPropertyChanged("VisibilidadCamposEditables");
                    visibilidadCamposResultados = Visibility.Visible;
                    NotifyPropertyChanged("VisibilidadCamposResultados");

                    editarCommand.RaiseCanExecuteChanged();
                    eliminarCommand.RaiseCanExecuteChanged();
                    guardarCommand.RaiseCanExecuteChanged();
                    cambiarFotoCommand.RaiseCanExecuteChanged();
                    atrasCommand.RaiseCanExecuteChanged();
                }
            }
            catch (SqlException)
            {
                mostrarMensajeErrorAsync();
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
                return atrasCommand;
            }
        }

        private void AtrasCommand_Executed()
        {
            /* Cuando se modifica un atributo de la personaSelecionada en los Texbox, por referencia se modifica 
             * en la persona que esta en la listaPersonasBuscada y listaPersonasOriginal. Por eso tengo que modificar 
             * la persona seleccionada de esta manera, para que asi por referencia se modifique en la persona que esta tanto
             * en listaPersonasBuscada como den ListaPersonasOriginal
             */
            personaSeleccionada.Nombre = personaSeleccionadaSinModificar.Nombre;
            personaSeleccionada.Apellidos = personaSeleccionadaSinModificar.Apellidos;
            personaSeleccionada.Direccion = personaSeleccionadaSinModificar.Direccion;
            personaSeleccionada.Telefono = personaSeleccionadaSinModificar.Telefono;
            personaSeleccionada.Foto = personaSeleccionadaSinModificar.Foto;
            personaSeleccionada.FechaNacimiento = personaSeleccionadaSinModificar.FechaNacimiento;
            personaSeleccionada.IdDepartamento = personaSeleccionadaSinModificar.IdDepartamento;
            personaSeleccionada.NombreDepartamento = personaSeleccionadaSinModificar.NombreDepartamento;
            NotifyPropertyChanged("PersonaSeleccionada");

            visibilidadCampos = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadCamposEditables = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCamposEditables");

            cambiarImagenAsync();
            guardarCommand.RaiseCanExecuteChanged();
            atrasCommand.RaiseCanExecuteChanged();
            cambiarFotoCommand.RaiseCanExecuteChanged();
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
            personaSeleccionada = new ClsPersonaConDepartamento();
            NotifyPropertyChanged("PersonaSeleccionada");

            visibilidadCampos = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadCamposEditables = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCamposEditables");
            visibilidadCamposResultados = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCamposResultados");

            TextBoxBuscar = string.Empty;//Se resetea el texto del textBox

            editarCommand.RaiseCanExecuteChanged();
            guardarCommand.RaiseCanExecuteChanged();
            eliminarCommand.RaiseCanExecuteChanged();

            cambiarFotoCommand.RaiseCanExecuteChanged();
            cambiarImagenAsync();
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
            listaPersonasBuscadas = new ObservableCollection<ClsPersonaConDepartamento>(from persona in listaPersonasOriginal
                                                                                        where persona.Nombre.ToLower().Contains(textBoxBuscar) ||
                                                                                        persona.Apellidos.ToLower().Contains(textBoxBuscar)
                                                                                        select persona);
            NotifyPropertyChanged("ListaPersonasBuscadas");
        }

        private bool buscarCommand_CanExecuted()
        {
            bool textBoxLleno = true;
            if (string.IsNullOrEmpty(textBoxBuscar))
            {
                textBoxLleno = false;
                listaPersonasBuscadas = listaPersonasOriginal;
                NotifyPropertyChanged("ListaPersonasBuscadas");
            }
            return textBoxLleno;
        }

        //Command cambiarFoto
        public DelegateCommand CambiarFotoCommand
        {
            get
            {
                return cambiarFotoCommand;
            }
        }

        private async void CambiarFotoCommand_Executed()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                BitmapImage imagen = new BitmapImage();

                //Se cambia el atributo imagen(Que sera visto en la vista)
                using (var randomAccessStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    imagen.SetSource(randomAccessStream);
                    imagenPersona = imagen;
                    NotifyPropertyChanged("Imagen");
                }

                //Se guarda en la propiedad Foto de la persona seleccionada la foto(En array de byte)
                using (var inputStream = await file.OpenSequentialReadAsync())
                {
                    var readStream = inputStream.AsStreamForRead();

                    //Crea un array de bytes con el tamaño del stream de lectura.
                    var byteArray = new byte[readStream.Length];

                    //Lee la secuencia de bytes del readStream (creo?) y lo va guardando en el array byteArray definido arriba.
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);

                    personaSeleccionada.Foto = byteArray;
                }
            }
        }

        private bool CambiarFotoCommand_CanExecuted()
        {
            return visibilidadCamposEditables == Visibility.Visible;
        }

        #endregion

        #region Propiedades
        //ListaPersonasBuscadas
        public ObservableCollection<ClsPersonaConDepartamento> ListaPersonasBuscadas
        {
            get { return listaPersonasBuscadas; }
            set { listaPersonasBuscadas = value; }
        }
        //ListaDepatamentos
        public ObservableCollection<ClsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }
        //PersonaSeleccionada
        public ClsPersonaConDepartamento PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");

                visibilidadCampos = Visibility.Visible;
                NotifyPropertyChanged("VisibilidadCampos");
                visibilidadCamposEditables = Visibility.Collapsed;
                NotifyPropertyChanged("VisibilidadCamposEditables");
                visibilidadCamposResultados = Visibility.Collapsed;
                NotifyPropertyChanged("VisibilidadCamposResultados");

                cambiarImagenAsync();

                editarCommand.RaiseCanExecuteChanged();
                eliminarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
                atrasCommand.RaiseCanExecuteChanged();
            }
        }
        //Imagen
        public ImageSource Imagen { get { return imagenPersona; } }

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

        #region Metodos privados
        /// <summary>
        /// Cabecera: private async void cambiarImagenAsync()
        /// Comentario: Este metodo se encarga de cambiar el valor del atriburo imagen, en fucion del atributo 
        ///             personaSeleccionada que valor tenga su atributo Foto.
        /// Entradas: Ninguna
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se modificara el atributo imagen, el cual puede tomar dos valores posibles:
        ///                  -Si la personaSeleccionada es una persona que existe(Es distinto de null) y la longitud del array de bytes de su atributo 
        ///                   foto es mayor que 0, a el atributo imagen se le asignara la imagen que tiene la personaSeleccionada.
        ///                  -Si la personaSeleccionada es igual a null o la longitud del array de bytes de su atributo 
        ///                   foto es menor o igual a 0, a imagen se le asginara una imagen por defecto.
        /// </summary>
        private async void cambiarImagenAsync()
        {
            BitmapImage imagen;
            if (personaSeleccionada != null && personaSeleccionada.Foto.Length > 0)//Si es una persona que tiene una foto
            {
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    imagen = new BitmapImage();
                    await stream.WriteAsync(personaSeleccionada.Foto.AsBuffer());
                    stream.Seek(0);
                    imagen.SetSource(stream);
                }
            }
            else //Sino se guarda una foto por defecto
            {
                imagen = new BitmapImage(new Uri("ms-appx:/Images/ImagenDefault.png", UriKind.RelativeOrAbsolute));
            }
            imagenPersona = imagen;
            NotifyPropertyChanged("Imagen");
        }
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
            var dialog = new MessageDialog("Ha ocurrido un error. Algunos datos son obligatorios: \n-Nombre.\n-Apellidos.\n-Telefono.\n-Direccion.");
            await dialog.ShowAsync();
        }
        private void llenarListaPersonasOriginal()
        {
            List<ClsPersona> personasBL = ListadosBL.obtenerPersonas();
            listaPersonasOriginal = new ObservableCollection<ClsPersonaConDepartamento>();
            foreach (ClsPersona persona in personasBL)
            {
                listaPersonasOriginal.Add(new ClsPersonaConDepartamento(persona, encontrarYObtenerNombreDepartamento(persona.IdDepartamento)));
            }
        }

        private string encontrarYObtenerNombreDepartamento(int idDepartamento)
        {
            string nombreDepatamento = "";

            for (int i = 0; i < listaDepartamentos.Count && nombreDepatamento.Equals(""); i++)
            {
                if (listaDepartamentos.ElementAt(i).ID == idDepartamento)
                {
                    nombreDepatamento = listaDepartamentos.ElementAt(i).Nombre;
                }
            }


            return nombreDepatamento;
        }
        #endregion
    }
}
