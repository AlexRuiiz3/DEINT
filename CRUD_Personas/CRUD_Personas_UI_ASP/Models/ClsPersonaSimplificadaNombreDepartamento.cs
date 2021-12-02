using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersonaSimplificadaNombreDepartamento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreDepartamento { get; set; }
        public ClsPersonaSimplificadaNombreDepartamento(ClsPersona persona, string nombreDepartamento)
        {
            ID = persona.ID;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            NombreDepartamento = nombreDepartamento;
        }

    }
}
