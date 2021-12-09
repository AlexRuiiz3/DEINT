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
        private const string MENSAJE_DATO_INVALIDO = "Ha ocurrido un error. Algunos datos son obligatorios\n-Nombre (Maximo 20 caracteres).\n-Apellidos (Maximo 30 caracteres).\n-Telefono (9 Digitos numericos y debe comenzar por 6 o 9).\n-Direccion (Maximo 35 caracteres).";
        private const string MENSAJE_ERROR_CONEXION_BBDD = "¡Ha ocurrido un error al establecer la conexion a la base de datos!.\n-El servicio puede no estar disponible.\n-Asegurese de estar conectado a una red Wifi.";
      
        //Expecifico las longitudes maximas de estos campos de la tabla Persona de la base de datos para asi poder mostrar el mensaje de error correspondiente
        private const int LONGITUD_MAXIMA_NOMBRE = 20;
        private const int LONGITUD_MAXIMA_APELLIDOS = 30;
        private const int LONGITUD_MAXIMA_DIRECCION = 35;


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

        #region Constructores
        //Constructor sin parametros
        public NavigationViewPersonasVM()
        {
            try
            {
                //Preparacion Listas 
                listaDepartamentos = new ObservableCollection<ClsDepartamento>(ListadosBL.obtenerDepartamentos());
                llenarListaPersonasOriginal();
                listaPersonasBuscadas = listaPersonasOriginal;

                //Inicializacion personaSeleccionada
                if (listaPersonasOriginal.Count > 0)
                {
                    personaSeleccionada = listaPersonasOriginal.ElementAt(0);
                }
                else
                {
                    personaSeleccionada = new ClsPersonaConDepartamento();
                }
                cambiarImagenAsync();
            }
            catch (SqlException)
            {
                mostrarMensajeAsync(MENSAJE_ERROR_CONEXION_BBDD);
            }

            //Inicializacion Commands
            editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecuted);
            guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecuted);
            eliminarCommand = new DelegateCommand(EliminarCommand_ExecutedAsync, EliminarCommand_CanExecuted);
            cambiarFotoCommand = new DelegateCommand(CambiarFotoCommand_Executed, CambiarFotoCommand_CanExecuted);
            atrasCommand = new DelegateCommand(AtrasCommand_Executed, AtrasCommand_CanExecuted);

            visibilidadCampos = Visibility.Visible;
            visibilidadCamposEditables = Visibility.Collapsed;
            visibilidadCamposResultados = Visibility.Collapsed;
        }
        #endregion

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
        private async void EliminarCommand_ExecutedAsync()
        {
            MessageDialog dialog = new MessageDialog("¿Esta seguro de eliminar la persona?", "Eliminar persona");
            dialog.Commands.Add(new UICommand("Yes", null));
            dialog.Commands.Add(new UICommand("No", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var dialogCommand = await dialog.ShowAsync();

            if (dialogCommand.Label == "Yes")
            {
                try
                {
                    GestoraPersonasBL.eliminarPersona(personaSeleccionada.ID);
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
                    cambiarFotoCommand.RaiseCanExecuteChanged();
                    atrasCommand.RaiseCanExecuteChanged();
                }
                catch (SqlException)
                {
                    mostrarMensajeAsync(MENSAJE_ERROR_CONEXION_BBDD);
                }
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
                if (string.IsNullOrEmpty(personaSeleccionada.Nombre.Trim()) || personaSeleccionada.Nombre.Length > LONGITUD_MAXIMA_NOMBRE
                    || string.IsNullOrEmpty(personaSeleccionada.Apellidos.Trim()) || personaSeleccionada.Apellidos.Length > LONGITUD_MAXIMA_APELLIDOS
                    || !validarNumeroTelefono(personaSeleccionada.Telefono) 
                    || string.IsNullOrEmpty(personaSeleccionada.Direccion.Trim()) || personaSeleccionada.Direccion.Length > LONGITUD_MAXIMA_DIRECCION)
                {
                    mostrarMensajeAsync(MENSAJE_DATO_INVALIDO);
                }
                else
                {
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
                    if (idPersonaSeleccionada == 0)
                    { //Si es igual a 0 significa que se añadio una persona, por lo tanto hay que buscar en la lista de personas original la ultima persona añadida y coger su ID
                        idPersonaSeleccionada = listaPersonasOriginal.ElementAt(listaPersonasOriginal.Count() - 1).ID;
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
                mostrarMensajeAsync(MENSAJE_ERROR_CONEXION_BBDD);
            }
        }
        private bool GuardarCommand_CanExecuted()
        {
            return visibilidadCamposEditables == Visibility.Visible;
        }

        //Command Atras
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
             * en listaPersonasBuscada como en ListaPersonasOriginal
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
            //A la nueva persona se le asigna por defecto el id departamento que este primero en la lista de departamentos, siempre y cuando haya departamentos en la lista
            if (listaDepartamentos.Count > 0)
            {
                personaSeleccionada.IdDepartamento = listaDepartamentos.ElementAt(0).ID;
            }
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
                                                                                        where persona.Nombre.ToLower().Contains(textBoxBuscar.ToLower()) ||
                                                                                        persona.Apellidos.ToLower().Contains(textBoxBuscar.ToLower())
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
        /// Cabecera: private async void mostrarMensajeAsync(string mensaje)
        /// Comentario: Este metodo se encarga de mostrar un MessageDialog con un mensaje que tendra una opcion de cerrar.
        /// Entradas: string mensaje
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se mostrara un mensaje al usuario en un MessageDialog, que contentra una opcion de cerrar.
        /// </summary>
        /// <param name="mensaje"></param>
        private async void mostrarMensajeAsync(string mensaje)
        {
            var dialog = new MessageDialog(mensaje);
            await dialog.ShowAsync();
        }
        /// <summary>
        /// Cabecera: private void llenarListaPersonasOriginal()
        /// Comentario: Este metodo se encarga de llenar una lista con personas ClsPersonasConDepartamento en funcion de una lista de personas que se obtenga de la tabla Persona de una base de datos
        /// Entradas: Ninguna
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se llenara una lista con objetos de tipo ClsPersonasConDepartamentos, en funcion
        ///                  de las personas que se obtenga de la tabla Personas de una base de datos, si la lista de 
        ///                  personas que se obtienen de la base de datos esta vacia listaPersonasOriginal estara vacia. 
        /// </summary>
        private void llenarListaPersonasOriginal()
        {
            List<ClsPersona> personasBL = ListadosBL.obtenerPersonas();
            listaPersonasOriginal = new ObservableCollection<ClsPersonaConDepartamento>();
            foreach (ClsPersona persona in personasBL)
            {
                listaPersonasOriginal.Add(new ClsPersonaConDepartamento(persona, obtenerNombreDepartamento(persona.IdDepartamento)));
            }
        }
        /// <summary>
        /// Cabecera: private string obtenerNombreDepartamento(int idDepartamento)
        /// Comentario: Este metodo se encarga de obtener de una lista de objetos ClsDepartamento, el nombre del departamento cuyo id sea igual al recibido.
        /// Entradas: int idDepartamento
        /// Salidas: string nombreDepartamento 
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se devolvera un string que cuyo valor sera el nombre de un departamento cuyo id sea igual al recibido.
        ///                  Si el id recibido no coincide con el de ningun departamento, el valor del string devuelto sera vacio.
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns>string nombreDepartamento</returns>
        private string obtenerNombreDepartamento(int idDepartamento)
        {
            string nombreDepartamento = "";

            for (int i = 0; i < listaDepartamentos.Count && nombreDepartamento.Equals(""); i++)
            {
                if (listaDepartamentos.ElementAt(i).ID == idDepartamento)
                {
                    nombreDepartamento = listaDepartamentos.ElementAt(i).Nombre;
                }
            }
            return nombreDepartamento;
        }
        /// <summary>
        /// Cabecera: private bool validarNumeroTelefono(string telefono)
        /// Comentario: Este metodo se encarga de validar que la cadena que recibe sea un numero de telefono valido.
        /// Entradas: string telefono
        /// Salidas: bool 
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se devuelve un booleano que tomara dos valores:
        ///                  -true: Cuando el string recibido tenga una longitud de 9 caracteres y comience por 6 o 9.
        ///                  -false: Cuando el string recibido no tenga una longitud de 9 caracteres o no comience ni por 6 o 9.
        /// </summary>
        /// <param name="telefono"></param>
        /// <returns>bool</returns>
        private bool validarNumeroTelefono(string telefono)
        {
            return !string.IsNullOrEmpty(telefono.Trim()) && telefono.Length == 9 && (telefono.StartsWith("6") || telefono.StartsWith("9"));
        }
        #endregion
    }
}
