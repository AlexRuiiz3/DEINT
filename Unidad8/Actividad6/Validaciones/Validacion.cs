using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad6.Validaciones
{
    class Validacion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns> true: nombre es null o esta vacio
        ///           false: nombre no se ni null ni esta vacio
        /// </returns>
        public static Boolean comprobarCadenaVaciaONull(String nombre) => String.IsNullOrEmpty(nombre);
    }
}
