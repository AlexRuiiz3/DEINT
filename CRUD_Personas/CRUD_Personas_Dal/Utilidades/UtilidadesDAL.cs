using CRUD_Personas_Dal.Conexion;
using System.Data.SqlClient;

namespace CRUD_Personas_Dal.Utilidades
{
    public class UtilidadesDAL
    {
        /// <summary>
        /// Cabecera: public static bool comprobarDepartamentoTienePersonas(int id)
        /// Comentario: Este metodo se encarga de comprobar si en la base de datos un departamento en espeficico tiene asociado alguna persona.
        /// Entradas: int id
        /// Salidas: bool contienePersonas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se devolvera un dato booleano cuyo valor se determina por:
        ///                  -true: Cuando en la base de datos en la tabla Departamentos, el departamento 
        ///                         especificado por el id recibo, tiene asociado una o mas personas.
        ///                  -false: Cuando el departamento especificado por el id recibido, no tiene asociado ninguna 
        ///                          persona o si el id no coincide con el de ningun departamento.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> bool contienePersonas </returns>
        public static bool comprobarDepartamentoTienePersonas(int id)
        {
            bool contienePersonas = false;
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;

                sqlCommand = new SqlCommand("SELECT P.Nombre,P.Apellidos FROM Departamentos AS D INNER JOIN Personas AS P" +
                    " ON D.ID = P.iddepartamento WHERE D.ID = @Id", conexion);
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
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
