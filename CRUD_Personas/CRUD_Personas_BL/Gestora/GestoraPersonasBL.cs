using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal.Gestora;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraPersonasBL
    {
        public static void guardarPersona(ClsPersona persona) {
            GestoraPersonasDAL.guardarPersona(persona);
        }

        public static int eliminarPersona(int idPersona)
        {
            return GestoraPersonasDAL.eliminarPersona(idPersona);
        }

        public static int editarPersona(ClsPersona persona)
        {
            return GestoraPersonasDAL.editarPersona(persona);
        }
    }
}
