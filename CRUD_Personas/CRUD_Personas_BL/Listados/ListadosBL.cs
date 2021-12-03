using System;
using System.Collections.Generic;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal;
using System.Data.SqlClient;

namespace CRUD_Personas_BL.Listados
{
    public class ListadosBL
    {

        /// <summary>
        /// Cabecera: public static List<ClsPersona> obtenerPersonas()
        /// Comentario: Este metodo se encarga de llamar al metodo obtenerPersonas de la clase ListadosDAL de la capa DAL.
        /// Entradas: Ninguna
        /// Salidas: List<ClsPersona> listadoPersonas
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera una lista con personas cuyo valor sera determinado por el metodo obtenerPersonas de la clase ListadosDAL de la capa DAL.
        /// </summary>
        /// <returns>List<ClsPersona> listadoPersonas</returns>
        public static List<ClsPersona> obtenerPersonas()
        {
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            try
            {
                listadoPersonas = ListadosDAL.obtenerPersonas();
            }
            catch (SqlException)
            {
                throw;
            }
            return listadoPersonas;
        }
        /// <summary>
        /// Cabecera: public static List<ClsDepartamento> obtenerDepartamentos()
        /// Comentario: Este metodo se encarga de llamar al metodo obtenerDepartamentos de la clase ListadosDAL de la capa DAL.
        /// Entradas: Ninguna
        /// Salidas: List<ClsDepartamento> listadoDepartamentos
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera una lista con departamentos cuyo valor sera determinado por el metodo obtenerDepartamentos de la clase ListadosDAL de la capa DAL.
        /// </summary>
        /// <returns>List<ClsDepartamento> listadoDepartamentos</returns>
        public static List<ClsDepartamento> obtenerDepartamentos()
        {
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            try
            {
                listadoDepartamentos = ListadosDAL.obtenerDepartamentos();

            }
            catch (SqlException)
            {
                throw;
            }
            return listadoDepartamentos;
        }
        /// <summary>
        /// Cabecera: public static List<ClsPersona> obtenerPersonas()
        /// Comentario: Este metodo se encarga de llamar al metodo obtenerNombreDepartamento de la clase ListadosDAL de la capa DAL.
        /// Entradas: int id
        /// Salidas: string nombre
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera una cadena cuyo valor sera determinado por el metodo obtenerNombreDepartamento de la clase ListadosDAL de la capa DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string nombre</returns>
        public static String obtenerNombreDepartamento(int id)
        {
            string nombre = "";
            try
            {
                nombre = ListadosDAL.obtenerNombreDepartamento(id);
            }
            catch (SqlException)
            {
                throw;
            }
            return nombre;
        }
        /// <summary>
        /// Cabecera: public static ClsPersona obtenerPersona(int id)
        /// Comentario: Este metodo se encarga de llamar al metodo obtenerPersonas de la clase ListadosDAL de la capa DAL.
        /// Entradas: int id
        /// Salidas: ClsPersona persona
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera un objeto ClsPersona cuyo valor sera determinado por el metodo obtenerPersona de la clase ListadosDAL de la capa DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClsPersona persona</returns>
        public static ClsPersona obtenerPersona(int id)
        {
            ClsPersona persona;
            try
            {
                persona = ListadosDAL.obtenerPersona(id);
            }
            catch (SqlException)
            {
                throw;
            }
            return persona;
        }
        /// <summary>
        /// Cabecera: public static ClsDepartamento obtenerDepartamento(int id)
        /// Comentario: Este metodo se encarga de llamar al metodo obtenerDepartamento de la clase ListadosDAL de la capa DAL.
        /// Entradas: int id
        /// Salidas: ClsDepartamento departamento
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera un objeto ClsDepartamento cuyo valor sera determinado por el metodo obtenerDepartamento de la clase ListadosDAL de la capa DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClsDepartamento departamento</returns>
        public static ClsDepartamento obtenerDepartamento(int id)
        {
            ClsDepartamento departamento;

            try
            {
                departamento = ListadosDAL.obtenerDepartamento(id);
            }
            catch (SqlException)
            {
                throw;
            }
            return departamento;
        }
        /// <summary>
        /// Cabecera: public static List<ClsPersona> obtenerPersonasDeDepartamento(int idDepartamento)
        /// Comentario: Este metodo se encarga de llamar al metodo obtenerPersonasDeDepartamento de la clase ListadosDAL de la capa DAL.
        /// Entradas: int idDepartamento
        /// Salidas: List<ClsPersona> listadoPersonas
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se devolvera una lista con personas cuyo valor sera determinado por el metodo obtenerPersonasDeDepartamento de la clase ListadosDAL de la capa DAL.
        /// </summary>
        /// <returns>List<ClsPersona> listadoPersonas</returns>
        public static List<ClsPersona> obtenerPersonasDeDepartamento(int idDepartamento) {
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            try
            {
                listadoPersonas = ListadosDAL.obtenerPersonasDeDepartamento(idDepartamento);
            }
            catch (SqlException)
            {
                throw;
            }
            return listadoPersonas;
        }
    }
}
