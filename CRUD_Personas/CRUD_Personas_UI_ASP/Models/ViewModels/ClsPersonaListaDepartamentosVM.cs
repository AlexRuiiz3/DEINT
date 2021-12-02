using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models.ViewModels
{
    public class ClsPersonaListaDepartamentosVM : ClsPersona
    {
        #region Constructores
        //Constructor sin parametros
        public ClsPersonaListaDepartamentosVM() : base()
        {
            ListaDepartamentos = new List<ClsDepartamento>();
        }
        //Constructor con parametros
        public ClsPersonaListaDepartamentosVM(ClsPersona persona, List<ClsDepartamento> listaDepartamentos) : base(persona.ID, persona.Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDepartamento)
        {
            ListaDepartamentos = listaDepartamentos;
        }
        #endregion

        #region Propiedades
        //ListaDepartamentos
        [Display(Name = "Departamentos: ")]
        public List<ClsDepartamento> ListaDepartamentos { get; set; }
        #endregion
    }
}
