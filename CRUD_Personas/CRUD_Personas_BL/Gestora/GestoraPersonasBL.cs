using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal.Gestora;
using System.Data.SqlClient;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraPersonasBL
    {
        /// <summary>
        /// Cabecera: public static void anhadirPersona(ClsPersona persona)
        /// Comentario: Este metodo se encarga de llamar al metodo anhadirPersona de la clase GestoraPersonasDAL de la capa DAL.
        /// Entradas: ClsPersona persona
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se realizara la tarea del metodo anhadirPersona de la clase GestoraPersonasDAL de la capa DAL.
        /// </summary>
        /// <param name="persona"></param>
        public static void anhadirPersona(ClsPersona persona)
        {
            try
            {
                GestoraPersonasDAL.anhadirPersona(persona);
            }
            catch (SqlException)
            {
                throw;
            }
        }
        /// <summary>
        /// Cabecera: public static int eliminarPersona(int id)
        /// Comentario: Este metodo se encarga de llamar al metodo eliminarPersona de la clase GestoraPersonasDAL de la capa DAL.
        /// Entradas: int id
        /// Salidas: int eliminaciones
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se realizara la tarea del metodo eliminarPersona de la clase GestoraPersonasDAL de la capa DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int eliminaciones</returns>
        public static int eliminarPersona(int id)
        {
            int eliminaciones = 0;
            try
            {
                eliminaciones = GestoraPersonasDAL.eliminarPersona(id);
            }
            catch (SqlException)
            {
                throw;
            }
            return eliminaciones;
        }
        /// <summary>
        /// Cabecera: public static int editarPersona(ClsPersona persona)
        /// Comentario: Este metodo se encarga de llamar al metodo editarPersona de la clase GestoraPersonasDAL de la capa DAL.
        /// Entradas: ClsPersona persona
        /// Salidas: int actualizaciones
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se realizara la tarea del metodo editarPersona de la clase GestoraPersonasDAL de la capa DAL.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>int actualizaciones</returns>
        public static int editarPersona(ClsPersona persona)
        {
            int actualizaciones = 0;
            try
            {
                actualizaciones = GestoraPersonasDAL.editarPersona(persona);
            }
            catch (SqlException)
            {
                throw;
            }
            return actualizaciones;
        }
    }
}
