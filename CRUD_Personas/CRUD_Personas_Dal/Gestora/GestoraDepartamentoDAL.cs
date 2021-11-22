using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal.Conexion;

namespace CRUD_Personas_Dal.Gestora
{
    public class GestoraDepartamentoDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departamento"></param>
        public void guardarDepartamento(ClsDepartamento departamento) {
            SqlConnection conexion;
            SqlCommand command;
           
            try {
                conexion = clsMyConnection.establecerConexion();

                command = new SqlCommand("INSERT INTO DEPARTAMENTOS VALUES(@Id,@Nombre)");
                command.Parameters.Add("@Id",System.Data.SqlDbType.Int).Value = departamento.ID;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;

                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception) {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int editarDepartamento(ClsDepartamento departamento) {
            SqlConnection conexion;
            SqlCommand command;
            int actualizaciones = 0;

            try {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("UPDATE DEPARTAMENTOS SET Nombre = @Nombre WHERE ID = @Id");
                command.Parameters.Add("@Id",System.Data.SqlDbType.Int).Value = departamento.ID;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception) 
            {
                throw;
            }

            return actualizaciones;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int eliminarDepartamento(int idDepartamento) {
            SqlConnection conexion;
            SqlCommand command;
            int eliminaciones = 0;

            try {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("DELETE DEPARTAMENTOS WHERE ID = @Id");
                command.Parameters.Add("@Id",System.Data.SqlDbType.Int).Value = idDepartamento;
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException) {
                throw;
            }
            return eliminaciones;
        }
    }
}
