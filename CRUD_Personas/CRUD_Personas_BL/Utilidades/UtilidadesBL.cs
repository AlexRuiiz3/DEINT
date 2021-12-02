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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool comprobarDepartamentoTienePersonas(int id)
        {
            try {
                return UtilidadesDAL.comprobarDepartamentoTienePersonas(id);
            }
            catch (SqlException) {
                throw;
            }
        }
    }
}
