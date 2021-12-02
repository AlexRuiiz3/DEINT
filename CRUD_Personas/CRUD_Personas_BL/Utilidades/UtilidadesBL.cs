using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CRUD_Personas_Dal.Utilidades;

namespace CRUD_Personas_BL.Utilidades
{
    public class UtilidadesBL
    {
        /// <summary>
        /// Cabecera: public static bool comprobarDepartamentoTienePersonas(int id)
        /// Comentario: Este metodo se encarga de llamar al metodo comprobarDepartamentoTienePersonas de la clase UtilidadesDal de la capa DAL.
        /// Entradas: int id
        /// Salidas: bool contienePersonas
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera un boolenao que sera determinado por el metodo comprobarDepartamentoTienePersonas de la clase UtilidadesDal de la capa DAL.            
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool contienePersonas</returns>
        public static bool comprobarDepartamentoTienePersonas(int id)
        {
            bool contienePersonas = false;
            try
            {
                contienePersonas = UtilidadesDAL.comprobarDepartamentoTienePersonas(id);
            }
            catch (SqlException)
            {
                throw;
            }
            return contienePersonas;
        }
    }
}
