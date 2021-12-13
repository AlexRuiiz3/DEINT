using System;
using System.Collections.Generic;
using System.Text;

namespace Examen1DEINT_Entidades
{
    public class ClsContabilidad
    {

        #region Constructores
        //Constructor por defecto
        public ClsContabilidad()
        {
            Fecha = DateTime.Now;
            RecaudacionesDada = 0;
            RecaudacionesReal = 0;

        }
        //Constructor con parametros
        public ClsContabilidad(DateTime fecha, double recaudacionDada, double recaudacionReal)
        {
            Fecha = fecha;
            RecaudacionesDada = recaudacionDada;
            RecaudacionesReal = recaudacionReal;
        }
        #endregion

        #region Propiedades
        //Fecha
        public DateTime Fecha { get; set; }
        //RecaudacionesDada
        public double RecaudacionesDada { get; set; }
        //RecaudacionesReal
        public double RecaudacionesReal { get; set; }
        #endregion

    }
}
