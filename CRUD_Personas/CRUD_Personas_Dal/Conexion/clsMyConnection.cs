using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CRUD_Personas_Dal.Conexion
{
    public class clsMyConnection
    {
        /// <summary> 
        /// Cabecera: public static SqlConnection establecerConexion()
        /// Comentario:
        /// Entradas: Ninguna
        /// Salidas: SqlConnection conexion
        /// Precondiciones:
        /// Postcondiciones:
        /// </summary>
        /// <returns>SqlConnection conexion</returns>
        public static SqlConnection establecerConexion(){
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "server=servidoralexbasedatos.database.windows.net;" +
                                        "database=SistemaGestion;uid=saboresdelatierra;pwd=#Mitesoro;";
            conexion.Open();
            return conexion;
        }
        /// <summary>
        /// Cabecera: public static void cerrarConexion(SqlConnection conexion)
        /// Comentario:
        /// Entradas: SqlConnection conexion
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: Ninguna
        /// </summary>
        /// <param name="conexion"></param>
        public static void cerrarConexion(SqlConnection conexion) {
            if (conexion != null){
                conexion.Close();
            }
        }
    }

}
