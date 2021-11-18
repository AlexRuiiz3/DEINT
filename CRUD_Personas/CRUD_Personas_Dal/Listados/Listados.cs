using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace CRUD_Personas_Dal
{
    public class Listados
    {

        public static List<ClsPersona> obtenerPersonasDAL()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;
            List<ClsPersona> listaPersonas = new List<ClsPersona>();

            conexion.ConnectionString = "server=servidoralexbasedatos.database.windows.net;" +
                                        "database=SistemaGestion;uid=saboresdelatierra;pwd=#Mitesoro;";
            conexion.Open();

            sqlCommand = new SqlCommand("SELECT * FROM Personas", conexion);
            sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                listaPersonas.Add(new ClsPersona(sqlDataReader.GetInt16(0),
                                                    sqlDataReader[1].ToString(),
                                                    sqlDataReader[2].ToString(),
                                                    sqlDataReader[3].ToString(),
                                                    sqlDataReader[4].ToString(),
                                                    new byte[0],
                                                    sqlDataReader[6].ToString(),
                                                    sqlDataReader.GetInt16(7)));
            }
            sqlDataReader.Close();
            conexion.Close();

            return listaPersonas;
        }
    }
}