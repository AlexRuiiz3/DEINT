using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Entidades;

namespace EjercicioFinalLayouts.ViewModels
{
    public class CitasViewVM
    {
        #region Atributos
        private List<Cita> citas = GestoraCitas.obtenerCitas();
        #endregion

        #region Metodos fundamentales
        public List<Cita> Citas {

            get { return citas; }
            set { citas = value; }
        }
        #endregion
    }
}
