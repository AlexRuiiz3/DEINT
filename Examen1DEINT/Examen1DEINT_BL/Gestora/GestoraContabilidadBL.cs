using System;
using System.Collections.Generic;
using System.Text;
using Examen1DEINT_Entidades;
using Examen1DEINT_Dal.Gestora;
using System.Data.SqlClient;

namespace Examen1DEINT_BL.Gestora
{
    public class GestoraContabilidadBL
    {

        /// <summary>
        /// Cabecera: public static int anhadirContabilidad(ClsContabilidad contabilidad)
        /// Comentario: Este metodo se encarga de insertar en la tabla Contabilidad de una base de datos, un objeto de tipo Contabilidad.
        /// Entradas: ClsContabilidad contabilidad
        /// Salidas: Ninguna
        /// Precondiciones: La contabilidad recibida no debera de estar a null, sino se producira una excepcion.
        /// Postcondiciones: Se insertara en la tabla Contabilidad de una base de datos una contabilidad, si la contabilidad recibida esta a
        ///                  null o se produce alguna excepcion no se insertara la contabilidad en la base de datos.
        /// </summary>
        /// <param name="contabilidad"></param>
        /// <returns>int filasAfectadas</returns>
        public static int  anhadirContabilidad(ClsContabilidad contabilidad)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = GestoraContabilidadDAL.anhadirContabilidad(contabilidad);
            }
            catch (SqlException)
            {
                throw;
            }
            return filasAfectadas;
        }

        /// <summary>
        /// Cabecera: public static int actualizarContabilidad(ClsContabilidad contabilidad)
        /// Comentario: Este metodo se encarga de modificar los campos(valor de las columnas) de una contabilidad concreta, que se encuentra en la tabla contabilidad de una base de datos y devolver el numero de actualizaciones producidas.
        /// Entradas: ClsContabilidad contabilidad
        /// Salidas: int filasAfectadas
        /// Precondiciones: La contabilidad recibida no debera de estar a null, sino se producira una excepcion
        /// Postcondiciones: Se modificara el valor de las columnas de una contabilidad en especifico de la tabla contabilidad y se devolvera el numero de modificaciones realizadas,
        ///                  si la contabilidad recibida esta a null o se produce alguna excepcion no se modificara ningun valor de la contabilidad y el valor del numero entero devuelto sera 0.
        /// </summary>
        /// <param name="contabilidad"></param>
        /// <returns>int filasAfectadas</returns>
        public static int actualizarContabilidad(ClsContabilidad contabilidad)
        {
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = GestoraContabilidadDAL.actualizarContabilidad(contabilidad);
            }
            catch (SqlException)
            {
                throw;
            }
            return filasAfectadas;
        }
    }
}
