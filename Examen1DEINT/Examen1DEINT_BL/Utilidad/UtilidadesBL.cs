using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Examen1DEINT_Dal.Utilidades;

namespace Examen1DEINT_BL.Utilidad
{
    public class UtilidadesBL
    {
        /// <summary>
        /// Cabecera: public static bool comprobarExistenciaContabilidad(DateTime fecha )
        /// Comentario: Este metodo se encarga de comprobar si en la base de datos existe una contabilidad concreta.
        /// Entradas: DateTime fecha
        /// Salidas: bool existe
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se devolvera un dato booleano cuyo valor se determina por:
        ///                  -true: Cuando en la base de datos en la tabla contabilidad, la fecha recibida conincida con el de una contabilidad 
        ///                         especificado por la fecha existe
        ///                  -false: Cuando en la base de datos en la tabla contabilidad, la fecha recibida no conincida con el de ninguna contabilidad 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns> bool existe </returns>
        public static bool comprobarExistenciaContabilidad(DateTime fecha)
        {
            bool existe = false;
            try
            {
                existe = UtilidadesDAL.comprobarExistenciaContabilidad(fecha);
            }
            catch (SqlException)
            {
                throw;
            }
            return existe;
        }

    }
}
