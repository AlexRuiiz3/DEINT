using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal;
using System.Collections.ObjectModel;

namespace CRUD_Personas_BL.Listados
{
    public class ListadosBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> obtenerPersonas()
        {
            return ListadosDAL.obtenerPersonas();
        }

        public static List<ClsDepartamento> obtenerDepartamentos()
        {
            return ListadosDAL.obtenerDepartamentos();
        }

        public static String obtenerNombreDepartamento(int idDepartamento)
        {
            return ListadosDAL.obtenerNombreDepartamento(idDepartamento);
        }
    }
}
