using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CRUD_Personas_Dal.Gestora;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraDepartamentoBL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public static void anhadirDepartamento(ClsDepartamento departamento)
        {
            try
            {
                GestoraDepartamentoDAL.anhadirDepartamento(departamento);
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
        public static int eliminarDeparmaento(int id)
        {
            int resultado = 0;
            try
            {
                resultado = GestoraDepartamentoDAL.eliminarDepartamento(id);
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
        public static int editarDepartamento(ClsDepartamento departamento)
        {
            int resultado = 0;
            try
            {
                resultado = GestoraDepartamentoDAL.editarDepartamento(departamento);
            }
            catch (SqlException)
            {
                throw;
            }
            return resultado;
        }
    }
}
