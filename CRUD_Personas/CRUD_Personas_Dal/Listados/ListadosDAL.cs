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
        /// Cabecera: public static List<ClsPersona> obtenerPersonas()
        /// Comentario: Este metodo se encarga de obtener todas las personas que hay en la tabla Persona de una base de datos.
        /// Entradas: Ninguna
        /// Salidas: List<ClsPersona> listaPersonas 
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con las personas que hay en una base de datos, si no hay ninguna persona o se produce 
        ///                  alguna excepcion, se devolvera una lista con 0 elementos.
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

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    while (sqlDataReader.Read())
                    {
                        persona = new ClsPersona();
                        persona.ID = sqlDataReader.GetInt16(0);
                        persona.Nombre = sqlDataReader[1].ToString();
                        persona.Apellidos = sqlDataReader[2].ToString();
                        persona.Telefono = sqlDataReader[3].ToString();
                        persona.Direccion = sqlDataReader[4].ToString();
                        if (sqlDataReader.GetValue(5) != DBNull.Value)
                        {
                            persona.Foto = (byte[])sqlDataReader.GetValue(5);
                        }
                        if (sqlDataReader.GetValue(6) != DBNull.Value)//En el caso de que la persona tenga una Fecha de Nacimiento a null se le asignara la que tenga en el constructor por defecto.
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
            catch (SqlException)
            {
                throw;
            }
            return listaPersonas;
        }
        /// <summary>
        /// Cabecera: public static List<ClsDepartamento> obtenerDepartamentos()
        /// Comentario: Este metodo se encarga de obtener todas los departamentos que hay en la tabla Departamentos de una base de datos.
        /// Entradas: Ninguna
        /// Salidas: List<ClsDepartamento> listaDepartamentos 
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con los departamentos que hay en una base de datos, si no hay ningun departamento o se produce 
        ///                  alguna excepcion, se devolvera una lista con 0 elemenetos.
        /// </summary>
        /// <returns>List<ClsDepartamento> listaDepartamentos </returns>
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

                if (sqlDataReader.HasRows) //Si hay filas 
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
        /// Cabecera: public static String obtenerNombreDepartamento(int idDepartamento)
        /// Comentario: Este metodo se encarga de obtener el nombre que tiene asociado un departamento apartir de su id, que se encuentra en la tabla Departamento en una base de datos.
        /// Entradas: int id
        /// Salidas: string nombre
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una cadena que contendra el nombre que tiene un departamento, si el id que se recibe no corresponde con ningun departamento o se produce alguna 
        ///                  excepcion, el valor de la cadena devuelta sera vacio.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string nombre</returns>
        public static String obtenerNombreDepartamento(int id)
        {
            SqlConnection conexion;
            SqlCommand command;
            SqlDataReader dataReader;
            string nombre = "";

            try
            {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("SELECT Nombre FROM DEPARTAMENTOS WHERE ID = @Id", conexion);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
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

        /// <summary>
        /// Cabecera: public static ClsPersona obtenerPersona(int id)
        /// Comentario: Este metodo se encarga de obtener de la tabla Persona de una base de datos, una persona determinada apartir del id.
        /// Entradas: int id
        /// Salidas: ClsPersona persona
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra objeto ClsPersona que sera una persona en especifico, si el id que se recibe no corresponde con ninguna persona o se produce alguna
        ///                  excepcion, el valor del objeto ClsPersona sera null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClsPersona persona</returns>
        public static ClsPersona obtenerPersona(int id)
        {
            ClsPersona persona = null;
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlDataReader dataReader;
                SqlCommand command;

                command = new SqlCommand("SELECT * FROM Personas WHERE ID = @Id", conexion);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    persona = new ClsPersona();
                    persona.ID = dataReader.GetInt16(0);
                    persona.Nombre = dataReader[1].ToString();
                    persona.Apellidos = dataReader[2].ToString();
                    persona.Telefono = dataReader[3].ToString();
                    persona.Direccion = dataReader[4].ToString();
                    if (dataReader.GetValue(5) != System.DBNull.Value)
                    {
                        persona.Foto = (byte[])dataReader.GetValue(5);
                    }
                    if (dataReader.GetValue(6) != System.DBNull.Value)
                    {
                        persona.FechaNacimiento = dataReader.GetDateTime(6);
                    }

                    persona.IdDepartamento = dataReader.GetInt16(7);

                }
                dataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return persona;
        }
    }
}