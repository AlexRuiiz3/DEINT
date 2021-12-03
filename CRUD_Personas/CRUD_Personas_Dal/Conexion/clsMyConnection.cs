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
        /// Comentario: Este metodo se encarga de establecer y abrir una conexion con una base de datos SQL.
        /// Entradas: Ninguna
        /// Salidas: SqlConnection conexion
        /// Precondiciones:
        /// Postcondiciones: Se devolvera un objeto de tipo SQLConnection con la conexion abierta.
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
