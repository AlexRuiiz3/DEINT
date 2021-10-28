using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dal
{
    public class GestoraCitas
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Cita> obtenerCitas() {
            List<Cita> citas = new List<Cita>();

            citas.Add(new Cita("Lunes",25,"Octubre","13:45","Calle Ramon y Cajal","41975"));
            citas.Add(new Cita("Martes", 26, "Octubre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Miercoles", 27, "Octubre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Jueves", 28, "Octubre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Viernes", 29, "Octubre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Sabado", 30, "Octubre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Domingo", 31, "Octubre","13:45", "Calle Ramon y Cajal", "41975"));

            return citas;
        }
    }
}
