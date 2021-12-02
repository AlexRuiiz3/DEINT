using System.Data.SqlClient;
using CRUD_Personas_Dal.Gestora;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraDepartamentoBL
    {

        /// <summary>
        /// Cabecera: public static void anhadirDepartamento(ClsDepartamento departamento)
        /// Comentario: Este metodo se encarga de llamar al metodo anhadirDepartamento de la clase GestoraDepartamentoDAL de la capa DAL.
        /// Entradas: ClsDepartamento departamento
        /// Salidas: Ninguna
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se realizara la tarea del metodo anhadirDepartamento de la clase GestoraDepartamentoDAL de la capa DAL.
        /// </summary>
        /// <param name="persona"></param>
        public static void anhadirDepartamento(ClsDepartamento departamento)
        {
            try
            {
                GestoraDepartamentoDAL.anhadirDepartamento(departamento);
            }
            catch (SqlException)
            {
                throw;
            }
        }
        /// <summary>
        /// Cabecera: public static int eliminarDeparmaento(int id)
        /// Comentario: Este metodo se encarga de llamar al metodo anhadirDepartamento de la clase GestoraDepartamentoDAL de la capa DAL.
        /// Entradas: int id
        /// Salidas: int eliminaciones
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se realizara la tarea del metodo eliminarDepartamento de la clase GestoraDepartamentoDAL de la capa DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int eliminaciones</returns>
        public static int eliminarDeparmaento(int id)
        {
            int eliminaciones = 0;
            try
            {
                eliminaciones = GestoraDepartamentoDAL.eliminarDepartamento(id);
            }
            catch (SqlException)
            {
                throw;
            }
            return eliminaciones;
        }
        /// <summary>
        /// Cabecera: public static int eliminarDeparmaento(int id)
        /// Comentario: Este metodo se encarga de llamar al metodo editarDepartamento de la clase GestoraDepartamentoDAL de la capa DAL.
        /// Entradas: ClsDepartamento departamento
        /// Salidas: int actualizaciones
        /// Precondiciones: Ninguna
        /// PostCondiciones: Se realizara la tarea del metodo editarDepartamento de la clase GestoraDepartamentoDAL de la capa DAL.
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns>int actualizaciones</returns>
        public static int editarDepartamento(ClsDepartamento departamento)
        {
            int actualizaciones = 0;
            try
            {
                actualizaciones = GestoraDepartamentoDAL.editarDepartamento(departamento);
            }
            catch (SqlException)
            {
                throw;
            }
            return actualizaciones;
        }
    }
}
