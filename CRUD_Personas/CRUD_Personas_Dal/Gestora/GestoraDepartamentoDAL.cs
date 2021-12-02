using System;
using System.Data.SqlClient;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal.Conexion;

namespace CRUD_Personas_Dal.Gestora
{
    public class GestoraDepartamentoDAL
    {
        /// <summary>
        /// Cabecera: public static void anhadirDepartamento(ClsDepartamento departamento)
        /// Comentario: Este metodo se encarga de insertar en la tabla Departamento de una base de datos, un objeto de tipo ClsDepartamento.
        /// Entradas: ClsDepartamento departamento
        /// Salidas: Ninguna
        /// Precondiciones: El departamento recibido no debera de estar a null, sino se producira una excepcion.
        /// Postcondiciones: Se insertara en la tabla Departamento de una base de datos un departamento, si el departamento recibido esta a
        ///                  null o se produce alguna excepcion no se insertara la persona en la base de datos.
        /// </summary>
        /// <param name="departamento"></param>
        public static void anhadirDepartamento(ClsDepartamento departamento)
        {
            SqlConnection conexion;
            SqlCommand command;

            try
            {
                conexion = clsMyConnection.establecerConexion();

                command = new SqlCommand("INSERT INTO Departamentos VALUES(@Nombre)", conexion);
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;
                command.ExecuteNonQuery();

                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cabecera: public static int editarDepartamento(ClsDepartamento departamento)
        /// Comentario: Este metodo se encarga de modificar los campos(valor de las columnas) de un departamento en concreto,
        ///             que se encuentra en la tabla Departamento de una base de datos y devolver el numero de actualizaciones 
        ///             producidas.
        /// Entradas: ClsDepartamento departamento
        /// Salidas: int actualizaciones
        /// Precondiciones: El departamento recibida no debera de estar a null, sino se producira una excepcion.
        /// Postcondiciones: Se modificara el valor de las columnas de un departamento en especifico de la tabla Departamento y se devolvera el numero de modificaciones realizadas,
        ///                  si el departamento recibido esta a null o se produce alguna excepcion no se modificara ningun valor del departamento y el valor del numero entero devuelto sera 0.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns>int actualizaciones</returns>
        public static int editarDepartamento(ClsDepartamento departamento)
        {
            SqlConnection conexion;
            SqlCommand command;
            int actualizaciones = 0;

            try
            {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @Id", conexion);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = departamento.ID;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;
                actualizaciones = command.ExecuteNonQuery();

                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception)
            {
                throw;
            }
            return actualizaciones;
        }
        /// <summary>
        /// Cabecera: public static int eliminarDepartamento(int id)
        /// Comentario: Este metodo se encarga de elimniar de la tabla Departamento de una base de datos un departamento 
        ///             a partir de su id y el numero de eliminaciones que sean producido.
        /// Entradas: int id
        /// Salidas: int eliminaciones
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se eliminara de la tabla Departamento de una base de datos un departamento y devolvera el numero 
        ///                  de eliminaciones, si el id recibido no corresponde con ningun departamento, no se eliminara el 
        ///                  departamento y el valor del numero entero devuelto sera 0.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int eliminaciones</returns>
        public static int eliminarDepartamento(int id)
        {
            SqlConnection conexion;
            SqlCommand command;
            int eliminaciones = 0;

            try
            {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("DELETE Departamentos WHERE ID = @Id", conexion);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                eliminaciones = command.ExecuteNonQuery();

                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return eliminaciones;
        }
    }
}
