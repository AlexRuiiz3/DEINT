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
        private List<Cita> citas = GestoraCitas.obtenerCitas();

        public List<Cita> Citas {

            get { return citas; }
            set { citas = value; }
        }
    }
}
