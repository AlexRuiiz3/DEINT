using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersonaNombreDepartamento : ClsPersona
    {
        [Display(Name = "Nombre Departamento")]
        public string NombreDepartamento { get; set; }
        public ClsPersonaNombreDepartamento() : base()
        {
            NombreDepartamento = "";
        }

        public ClsPersonaNombreDepartamento(ClsPersona persona, string nombreDepartamento) : base(persona.ID, persona.Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDepartamento)
        {
            NombreDepartamento = nombreDepartamento;
        }

    }
}
