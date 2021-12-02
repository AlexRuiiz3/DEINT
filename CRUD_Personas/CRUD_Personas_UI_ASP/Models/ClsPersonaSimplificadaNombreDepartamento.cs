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
        #region Constructores
        //Constructor sin parametros
        public ClsPersonaSimplificadaNombreDepartamento()
        {
            ID = 0;
            Nombre = "";
            Apellidos = "";
            NombreDepartamento = "";
        }
        //Constructor con parametros
        public ClsPersonaSimplificadaNombreDepartamento(ClsPersona persona, string nombreDepartamento)
        {
            ID = persona.ID;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            NombreDepartamento = nombreDepartamento;
        }
        #endregion

        #region Propiedades
        //ID
        public int ID { get; set; }
        //Nombre
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        //Apellidos
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        //NombreDepartamento
        [Display(Name = "Nombre Departamento")]
        public string NombreDepartamento { get; set; }
        #endregion
    }
}
