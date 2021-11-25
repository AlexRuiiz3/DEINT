using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CRUD_Personas_Dal.Conexion;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_Dal.Gestora
{
    public class GestoraPersonasDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public static void anhadirPersona(ClsPersona persona)
        {
            SqlConnection conexion;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>bool eliminada</returns>
        public static int eliminarPersona(int idPersona)
        {
            SqlConnection conexion;
            SqlCommand command;
            int eliminaciones = 0;
            try
            {
                conexion = clsMyConnection.establecerConexion();
                command = new SqlCommand("DELETE Personas WHERE ID = @id", conexion);
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = idPersona;
                eliminaciones = command.ExecuteNonQuery();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception)
            {
                throw;
            }
            return eliminaciones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>bool editada</returns>
        public static int editarPersona(ClsPersona persona)
        {
            SqlConnection conexion;
            SqlCommand command = new SqlCommand();
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
                command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                command.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
                command.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                actualizaciones = command.ExecuteNonQuery();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (Exception)
            {
                throw;
            }
            return actualizaciones;
        }
    }
}
