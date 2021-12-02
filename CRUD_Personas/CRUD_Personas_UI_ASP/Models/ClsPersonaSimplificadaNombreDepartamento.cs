using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersonaSimplificadaNombreDepartamento
    {
        public ClsPersonaSimplificadaNombreDepartamento(ClsPersona persona, string nombreDepartamento)
        {
            ID = persona.ID;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            NombreDepartamento = nombreDepartamento;
        }
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Display(Name = "Nombre Departamento")]
        public string NombreDepartamento { get; set; }
    }
}
