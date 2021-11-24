using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace CRUD_Personas_BL.Listados
{
    public class ListadosBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> obtenerPersonas()
        {
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            try {
                listadoPersonas = ListadosDAL.obtenerPersonas();
            }
            catch (SqlException)
            {
                throw;
            }
            return listadoPersonas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> obtenerDepartamentos()
        {
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            try
            {
                listadoDepartamentos = ListadosDAL.obtenerDepartamentos();

            }
            catch (SqlException) {
                throw;
            }
            return listadoDepartamentos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public static String obtenerNombreDepartamento(int idDepartamento)
        {
            string nombre = "";
            try
            {
                nombre = ListadosDAL.obtenerNombreDepartamento(idDepartamento);
            }
            catch (SqlException) {
                throw;
            }
            return nombre;
        }
    }
}
