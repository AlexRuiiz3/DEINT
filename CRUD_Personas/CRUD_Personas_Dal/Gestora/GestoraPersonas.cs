﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CRUD_Personas_Dal.Conexion;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_Dal.Gestora
{
    public class GestoraPersonas
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public static void guardarPersona(ClsPersona persona) {
            SqlConnection conexion = clsMyConnection.establecerConexion();
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Personas VALUES (@Nombre,@Apellidos,@Telefono,@Direccion,@Foto,@FechaNacimiento,@IdDepartamento)");
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                command.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                command.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                command.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
                command.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
            }
            catch (Exception) { 
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>bool eliminada</returns>
        public static bool eliminarPersona(int idPersona)
        {
            bool eliminada = false;
            SqlConnection conexion = clsMyConnection.establecerConexion();
            try
            {
                SqlCommand command = new SqlCommand("DELETE Personas WHERE ID = @id");
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = idPersona;
                eliminada = command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return eliminada;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>bool editada</returns>
        public static bool editarPersona(ClsPersona persona)
        {
            bool editada = false;
            SqlConnection conexion = clsMyConnection.establecerConexion();
            try
            {
                SqlCommand command = new SqlCommand("UPDATE PERSONAS SET Nombre = @Nombre, Apellidos = @Apellidos, Telefono = @Telefono, " +
                    "Direccion = @Direccion,Foto = @Foto, FechaNacimiento = @FechaNacimiento, IdDepartamento = @IdDepartamento WHERE ID = @Id");
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = persona.ID;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                command.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                command.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                command.Parameters.Add("@Foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                command.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
                command.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
                editada = command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return editada;
        }
    }
}
