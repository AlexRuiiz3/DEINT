using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen1DEINT_Dal.Conexion
{
    public class clsMyConnection
    {
        /// <summary> 
        /// Cabecera: public static SqlConnection establecerConexion()
        /// Comentario: Este metodo se encarga de establecer y abrir una conexion con una base de datos SQL.
        /// Entradas: Ninguna
        /// Salidas: SqlConnection conexion
        /// Precondiciones:
        /// Postcondiciones: Se devolvera un objeto de tipo SQLConnection con la conexion abierta.
        /// </summary>
        /// <returns>SqlConnection conexion</returns>
        public static SqlConnection establecerConexion(){
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "server=107-19\\SQLEXPRESS;" +
                                        "database=FrayGuillermo;uid=prueba;pwd=123;";
            conexion.Open();
            return conexion;
        }
        /// <summary>
        /// Cabecera: public static void cerrarConexion(SqlConnection conexion)
        /// Comentario: Este metodo se encarga de cerrar la conexion de un objeto SQLConnection.
        /// Entradas: SqlConnection conexion
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// Postcondiciones: El objeto SqlConnection recibido cerrara su conexion, si esta a null no se cerrar el objeto SqlConnection.
        /// </summary>
        /// <param name="conexion"></param>
        public static void cerrarConexion(SqlConnection conexion) {
            if (conexion != null){
                conexion.Close();
            }
        }
    }
}
