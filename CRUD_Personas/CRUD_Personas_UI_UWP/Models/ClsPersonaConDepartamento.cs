using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_UWP.Models
{
    public class ClsPersonaConDepartamento : ClsPersona
    {
        public ClsPersonaConDepartamento(ClsPersona persona, string nombreDepartamento) : base(persona.ID,persona.
            Nombre,persona.Apellidos,persona.Telefono,persona.Direccion,persona.Foto,persona.FechaNacimiento,
            persona.IdDepartamento) {
            NombreDepartamento = nombreDepartamento;
        }
        public string NombreDepartamento {get;
            set;}
    }
}
