using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen1DEINT_UI.ViewModels.Utilidades;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Examen1DEINT_Entidades;
using Examen1DEINT_UI.Models;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Examen1DEINT_BL.Gestora;
using Examen1DEINT_BL.Listados;
using Examen1DEINT_BL.Utilidad;

namespace Examen1DEINT_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        /* No he conseguido bindear la cantidad que se defina de las plantas con la propiedad ClsPlantaConCantidad cantidad.
        /  Me faltan por comprobar muchas cosas, no estoy contento con el resultado del examen, he hecho muchas cosas rapido.
        */
        
        private const string MENSAJE_ERROR_CONEXION_BBDD = "¡Ha ocurrido un error al establecer la conexion a la base de datos!.\n-El servicio puede no estar disponible.\n-Asegurese de estar conectado a una red Wifi.";
        private ObservableCollection<ClsPlantaConCantidad> listaPlantas;
        private Visibility visibilidadCamposResultados;//Esto es para el text de los resultados cuando se pulse calcular recaudacion, no me da tiempo implementarlo

        private ClsContabilidad contabilidad;
        private DelegateCommand guardarCommand;
        private DelegateCommand calcularRecaudacionCommand;

        public MainPageVM()
        {
            contabilidad = new ClsContabilidad();
            try
            {

                List<ClsPlanta> listaClsPlantas = ListadosBL.obtenerPlantas();
                listaPlantas = new ObservableCollection<ClsPlantaConCantidad>();
                foreach (ClsPlanta planta in listaClsPlantas)
                {
                    listaPlantas.Add(new ClsPlantaConCantidad(planta, 0));
                }
            }
            catch (SqlException)
            {
                mostrarMensajeAsync(MENSAJE_ERROR_CONEXION_BBDD);
            }
        }

        #region Commands
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
            
            if (Contabilidad.RecaudacionesDada == 0)
            {
                mostrarMensajeAsync("Campos dinero Adso obligatorio");
            }
            else
            {
                try {
                    if (UtilidadesBL.comprobarExistenciaContabilidad(Contabilidad.Fecha))
                    {
                        GestoraContabilidadBL.actualizarContabilidad(Contabilidad);
                    }
                    else {
                        GestoraContabilidadBL.anhadirContabilidad(Contabilidad);
                    }
                }
                catch (SqlException) {
                    mostrarMensajeAsync(MENSAJE_ERROR_CONEXION_BBDD);
                }
            }
        }

        private bool GuardarCommand_CanExecuted()
        {
            return true;
        }

        //Command CalcularRecaudacion
        public DelegateCommand CalcularRecaudacionCommand
        {
            get
            {
                return calcularRecaudacionCommand = new DelegateCommand(CalcularRecaudacionCommand_Executed, CalcularRecaudacionCommand_CanExecuted);
            }
        }
        private void CalcularRecaudacionCommand_Executed()
        {
            double recaudacion = 0;
            foreach (ClsPlantaConCantidad clsPlanta in listaPlantas) {
                recaudacion += (clsPlanta.Precio * clsPlanta.Cantidad);
            }
            Contabilidad.RecaudacionesReal = recaudacion;
        }

        private bool CalcularRecaudacionCommand_CanExecuted()
        {
            return true;
        }
        #endregion
        #region Propiedades
        //listaPlantas
        public ObservableCollection<ClsPlantaConCantidad> ListaPLantas
        {
            get { return listaPlantas; }
            set { listaPlantas = value; }
        }

        //Contabilidad
        public ClsContabilidad Contabilidad { get { return contabilidad; } set { contabilidad = value; } }
        
        //VisibilidadCamposResultados
        public Visibility VisibilidadCamposResultados
        {
            get { return visibilidadCamposResultados; }
        }
        #endregion
        #region Metodos privados
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
        #endregion

    }
}
