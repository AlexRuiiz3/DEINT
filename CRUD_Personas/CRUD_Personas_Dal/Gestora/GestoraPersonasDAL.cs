using System;
using System.Data.SqlClient;
using CRUD_Personas_Dal.Conexion;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_Dal.Gestora
{
    public class GestoraPersonasDAL
    {
        /// <summary>
        /// Cabecera: public static void anhadirPersona(ClsPersona persona)
        /// Comentario: Este metodo se encarga de insertar en la tabla Persona de una base de datos, un objeto de tipo ClsPersona.
        /// Entradas: ClsPersona persona
        /// Salidas: Ninguna
        /// Precondiciones: La persona recibida no debera de estar a null, sino se producira una excepcion.
        /// Postcondiciones: Se insertara en la tabla Persona de una base de datos una persona, si la persona recibida esta a
        ///                  null o se produce alguna excepcion no se insertara la persona en la base de datos.
        /// </summary>
        /// <param name="persona"></param>
        public static void anhadirPersona(ClsPersona persona)
        {
            SqlConnection conexion = null;
            SqlCommand command;

            try
            {
                conexion = clsMyConnection.establecerConexion();

                command = new SqlCommand("INSERT INTO Personas VALUES (@Nombre,@Apellidos,@Telefono,@Direccion,@Foto,@FechaNacimiento,@IdDepartamento)", conexion);
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                command.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                command.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                command.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
                command.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                command.ExecuteNonQuery();

                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                clsMyConnection.cerrarConexion(conexion);
            }
        }

        /// <summary>
        /// Cabecera: public static int editarPersona(ClsPersona persona)
        /// Comentario: Este metodo se encarga de modificar los campos(valor de las columnas) de una persona concreta, que se encuentra en la tabla Persona de una base de datos y devolver el numero de actualizaciones producidas.
        /// Entradas: ClsPersona persona
        /// Salidas: int actualizaciones
        /// Precondiciones: La persona recibida no debera de estar a null, sino se producira una excepcion
        /// Postcondiciones: Se modificara el valor de las columnas de una persona en especifico de la tabla Persona y se devolvera el numero de modificaciones realizadas,
        ///                  si la persona recibida esta a null o se produce alguna excepcion no se modificara ningun valor de la persona y el valor del numero entero devuelto sera 0.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>bool editada</returns>
        public static int editarPersona(ClsPersona persona)
        {
            SqlConnection conexion = null;
            SqlCommand command;

            int actualizaciones = 0;
            try
            {
                conexion = clsMyConnection.establecerConexion();

                command = new SqlCommand("UPDATE PERSONAS SET Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, " +
                    "Direccion = @Direccion,Foto = @Foto, FechaNacimiento = @FechaNacimiento, IdDepartamento = @IdDepartamento WHERE ID = @Id", conexion);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = persona.ID;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                command.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                command.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                if (persona.Foto.Length > 0)
                {
                    command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                }
                else
                {
                    command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                }
                command.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
                command.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                actualizaciones = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                clsMyConnection.cerrarConexion(conexion);
            }
            return actualizaciones;
        }

        /// <summary>
        /// Cabecera: public static int eliminarPersona(int id)
        /// Comentario: Este metodo se encarga de elimniar de la tabla Persona de una base de datos una persona apartir de su id y el numero de eliminaciones que sean producido.
        /// Entradas: int id
        /// Salidas: int eliminaciones
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se eliminara de la tabla Persona de una base de datos una persona y devolvera el numero de eliminaciones, si el id recibido no corresponde con ninguna 
        ///                  persona, no se eliminara la persona y el valor del numero entero devuelto sera 0.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int eliminaciones</returns>
        public static int eliminarPersona(int id)
        {
            SqlConnection conexion = null;
            SqlCommand command;

            int eliminaciones = 0;
            try
            {
                conexion = clsMyConnection.establecerConexion();

                command = new SqlCommand("DELETE Personas WHERE ID = @id", conexion);
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                eliminaciones = command.ExecuteNonQuery();

                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                clsMyConnection.cerrarConexion(conexion);
            }
            return eliminaciones;
        }
    }
}
