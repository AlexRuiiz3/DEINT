using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Examen1DEINT_Dal.Listados;
using Examen1DEINT_Entidades;

namespace Examen1DEINT_BL.Listados
{
    public class ListadosBL
    {
        /// <summary>
        /// Cabecera: public static List<ClsPlanta> obtenerPlantas()
        /// Comentario: Este metodo se encarga de obtener todas las plantas hay en la tabla Planta de una base de datos.
        /// Entradas: Ninguna
        /// Salidas: List<ClsPlanta> listaPlantas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con las plantas que hay en una base de datos, si se produce alguna expection se devolvera una lista vacia
        /// 
        /// </summary>
        /// <returns>List<ClsPlanta> listaPlantas</returns>
        public static List<ClsPlanta> obtenerPlantas() { 
        
            List<ClsPlanta> listadoPlantas = new List<ClsPlanta>();
            try
            {
                listadoPlantas = ListadosDAL.obtenerPlantas();
            }
            catch (SqlException)
            {
                throw;
            }
            return listadoPlantas;
        }
    }
}
