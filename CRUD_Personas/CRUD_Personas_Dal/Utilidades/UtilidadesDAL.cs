using CRUD_Personas_Dal.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_Dal.Utilidades
{
    public class UtilidadesDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool comprobarDepartamentoTienePersonas(int id)
        {
            bool contienePersonas = false;
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;


                sqlCommand = new SqlCommand("SELECT P.Nombre,P.Apellido FROM Departamentos AS INNER JOIN Personas AS P ON D.ID = P.iddepartamento WHERE D.ID = ", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                contienePersonas = sqlDataReader.HasRows;

                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return contienePersonas;
        }

    }
}
