using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Examen1DEINT_Dal.Conexion;
using Examen1DEINT_Entidades;

namespace Examen1DEINT_Dal.Listados
{
    public class ListadosDAL
    {

        /// <summary>
        /// Cabecera: public static List<ClsPlanta> obtenerPlantas()
        /// Comentario: Este metodo se encarga de obtener todas las plantas hay en la tabla Planta de una base de datos.
        /// Entradas: Ninguna
        /// Salidas: List<ClsPlanta> listaPlantas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con las plantas que hay en una base de datos, si se produce alguna expection se devolvera una lista vacia
        /// 
        /// </summary>
        /// <returns>List<ClsPlanta> listaPlantas</returns>
        public static List<ClsPlanta> obtenerPlantas()
        {
            List<ClsPlanta> listaPlantas = new List<ClsPlanta>();
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                ClsPlanta planta;

                sqlCommand = new SqlCommand("SELECT * FROM Plantas", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    while (sqlDataReader.Read())
                    {
                        planta = new ClsPlanta();
                        planta.Id = sqlDataReader.GetInt32(0);
                        planta.Nombre = sqlDataReader[1].ToString();
                        planta.Descripcion = sqlDataReader[2].ToString();
                        planta.IdCategoria = sqlDataReader.GetInt32(3);
                        planta.Precio = sqlDataReader.GetDouble(4) ; 

                        listaPlantas.Add(planta);
                    }
                }
                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return listaPlantas;
        }
    }
}
