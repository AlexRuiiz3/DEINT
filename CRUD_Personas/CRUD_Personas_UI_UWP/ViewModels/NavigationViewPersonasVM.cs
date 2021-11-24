﻿using System;
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
using Windows.Storage;
using System.Drawing;
using Windows.UI.Popups;
using System.Data.SqlClient;

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
        private DelegateCommand crearCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand guardarCommand;
        private DelegateCommand cambiarFotoCommand;
        private DelegateCommand detallesCommand;


        public NavigationViewPersonasVM()
        {
            try
            {
                List<ClsPersona> personasBL = ListadosBL.obtenerPersonas();
                listaPersonas = new ObservableCollection<ClsPersonaConDepartamento>();
                foreach (ClsPersona persona in personasBL)
                {
                    listaPersonas.Add(new ClsPersonaConDepartamento(persona, ListadosBL.obtenerNombreDepartamento(persona.IdDepartamento)));
                }
                listaDepartamentos = new ObservableCollection<ClsDepartamento>(ListadosBL.obtenerDepartamentos());
            }
            catch (SqlException) {
                mostrarMensajeError();
            }
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
            cambiarFotoCommand.RaiseCanExecuteChanged();
            detallesCommand.RaiseCanExecuteChanged();
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
            try
            {
                if (GestoraPersonasBL.editarPersona(personaSeleccionada) > 0)
                {
                    visibilidadCampos = Visibility.Visible;
                    NotifyPropertyChanged("VisibilidadCampos");
                    visibilidadTextBox = Visibility.Collapsed;
                    NotifyPropertyChanged("VisibilidadTextBox");
                    guardarCommand.RaiseCanExecuteChanged();
                    cambiarFotoCommand.RaiseCanExecuteChanged();

                    List<ClsPersona> personasBL = ListadosBL.obtenerPersonas();
                    listaPersonas = new ObservableCollection<ClsPersonaConDepartamento>();
                    foreach (ClsPersona persona in personasBL)
                    {
                        listaPersonas.Add(new ClsPersonaConDepartamento(persona, ListadosBL.obtenerNombreDepartamento(persona.IdDepartamento)));
                    }
                }
            }
            catch (SqlException) {
                mostrarMensajeError();
            }
        }

        private bool GuardarCommand_CanExecuted()
        {
            return visibilidadTextBox == Visibility.Visible;
        }

        //Command cambiarFoto
        public DelegateCommand CambiarFotoCommand
        {
            get
            {
                return cambiarFotoCommand = new DelegateCommand(CambiarFotoCommand_Executed, CambiarFotoCommand_CanExecuted);
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
            return visibilidadTextBox == Visibility.Visible;
        }

        //Command detalles
        public DelegateCommand DetallesCommand
        {
            get
            {
                return detallesCommand = new DelegateCommand(DetallesCommand_Executed, DetallesCommand_CanExecuted);
            }
        }

        private void DetallesCommand_Executed()
        {
            visibilidadCampos = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadTextBox = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadTextBox");
            guardarCommand.RaiseCanExecuteChanged();
            detallesCommand.RaiseCanExecuteChanged();
            cambiarFotoCommand.RaiseCanExecuteChanged();
        }

        private bool DetallesCommand_CanExecuted()
        {
            return visibilidadTextBox == Visibility.Visible;
        }

        //Command crear
        public DelegateCommand CrearCommand
        {
            get
            {
                return crearCommand = new DelegateCommand(CrearCommand_Executed, CrearCommand_CanExecuted);
            }
        }

        private void CrearCommand_Executed()
        {
            personaSeleccionada = null;
            cambiarImagenAsync();

            NotifyPropertyChanged("PersonaSeleccionada");
            visibilidadCampos = Visibility.Collapsed;
            NotifyPropertyChanged("VisibilidadCampos");
            visibilidadTextBox = Visibility.Visible;
            NotifyPropertyChanged("VisibilidadTextBox");

            editarCommand.RaiseCanExecuteChanged();
            guardarCommand.RaiseCanExecuteChanged();
            eliminarCommand.RaiseCanExecuteChanged();


        }

        private bool CrearCommand_CanExecuted()
        {
            return true;
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

                crearCommand.RaiseCanExecuteChanged();
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

        private async void mostrarMensajeError() {

            var dialog = new MessageDialog("¡--ERROR-- Ha ocurrido un error en el acceso a la base datos!");

            await dialog.ShowAsync();
        }

    }
}
