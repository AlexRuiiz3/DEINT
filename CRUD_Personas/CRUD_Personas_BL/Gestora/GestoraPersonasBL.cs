using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal.Gestora;
using System.Data.SqlClient;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraPersonasBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public static void guardarPersona(ClsPersona persona) {
            try
            {
                GestoraPersonasDAL.guardarPersona(persona);
            }
            catch (SqlException)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public static int eliminarPersona(int idPersona)
        {
            int resultado = 0;
            try
            {
                resultado = GestoraPersonasDAL.eliminarPersona(idPersona);
            }
            catch (SqlException)
            {
                throw;
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int editarPersona(ClsPersona persona)
        {
            int resultado = 0;
            try
            {
                resultado = GestoraPersonasDAL.editarPersona(persona);
            }
            catch (SqlException) {
                throw;
            }
            return resultado;
        }
    }
}
