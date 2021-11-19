using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_BL.Listados
{
    public class Listados
    {
        public static List<ClsPersona> obtenerPersonasBL()
        {
            return CRUD_Personas_Dal.Listados.obtenerPersonasDAL();
        }
    }
}
