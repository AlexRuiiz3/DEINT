using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUD_Personas_Dal.Conexion;
using System.Collections.ObjectModel;

namespace CRUD_Personas_Dal
{
    public class ListadosDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<ClsPersona> listaPersonas</returns>
        public static List<ClsPersona> obtenerPersonas()
        {
            List<ClsPersona> listaPersonas = new List<ClsPersona>();
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                ClsPersona persona;

                sqlCommand = new SqlCommand("SELECT * FROM Personas", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        persona = new ClsPersona();
                        persona.ID = sqlDataReader.GetInt16(0);
                        persona.Nombre = sqlDataReader[1].ToString();
                        persona.Apellidos = sqlDataReader[2].ToString();
                        persona.Telefono = sqlDataReader[3].ToString();
                        persona.Direccion = sqlDataReader[4].ToString();
                        if (sqlDataReader.GetValue(5) != System.DBNull.Value)
                        {
                            persona.Foto = (byte[])sqlDataReader.GetValue(5);
                        }
                        if (sqlDataReader.GetValue(6) != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = sqlDataReader.GetDateTime(6);
                        }

                        persona.IdDepartamento = sqlDataReader.GetInt16(7);

                        listaPersonas.Add(persona);
                    }
                }
                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException) {
                throw;
            }
            return listaPersonas;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> obtenerDepartamentos()
        {
            List<ClsDepartamento> listaDepartamentos = new List<ClsDepartamento>();
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                ClsDepartamento departamento;

                sqlCommand = new SqlCommand("SELECT * FROM Departamentos", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        departamento = new ClsDepartamento();
                        departamento.ID = sqlDataReader.GetInt16(0);
                        departamento.Nombre = sqlDataReader[1].ToString();
                        listaDepartamentos.Add(departamento);
                    }
                }
                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return listaDepartamentos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public static String obtenerNombreDepartamento(int idDepartamento)
        {
            SqlConnection conexion;
            SqlCommand command;
            SqlDataReader dataReader;
            string nombre = "";

            try
            {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("SELECT Nombre FROM DEPARTAMENTOS WHERE ID = @Id",conexion);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = idDepartamento;
                dataReader = command.ExecuteReader();
                dataReader.Read();
                nombre = dataReader.GetString(0);

                dataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return nombre;
        }
    }
}