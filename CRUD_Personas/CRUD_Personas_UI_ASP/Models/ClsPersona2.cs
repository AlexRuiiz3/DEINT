using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersona2 : ClsPersona
    {
        public string NombreDepartamento { get; set; }
        public ClsPersona2(ClsPersona persona, string nombreDepartamento):base()
        {
            ID = persona.ID;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            NombreDepartamento = nombreDepartamento;
        }

    }
}
