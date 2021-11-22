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
        /// <returns>ObservableCollection<ClsPersona> listaPersonas</returns>
        public static ObservableCollection<ClsPersona> obtenerPersonas()
        {
            ObservableCollection<ClsPersona> listaPersonas = new ObservableCollection<ClsPersona>();
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                ClsPersona persona;

                sqlCommand = new SqlCommand("SELECT * FROM Personas", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    persona = new ClsPersona();
                    persona.ID = sqlDataReader.GetInt16(0);
                    persona.Nombre = sqlDataReader[1].ToString();
                    persona.Apellidos = sqlDataReader[2].ToString();
                    persona.Telefono = sqlDataReader[3].ToString();
                    persona.Direccion = sqlDataReader[4].ToString();
                    if (sqlDataReader.GetValue(5) != System.DBNull.Value) { 
                        persona.Foto = (byte[])sqlDataReader.GetValue(5); 
                    }
                    persona.FechaNacimiento = sqlDataReader[6].ToString();

                    persona.IdDepartamento = sqlDataReader.GetInt16(7);
                    
                    listaPersonas.Add(persona);
                }
                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException) {
                throw;
            }
            return listaPersonas;
        }
    }
}