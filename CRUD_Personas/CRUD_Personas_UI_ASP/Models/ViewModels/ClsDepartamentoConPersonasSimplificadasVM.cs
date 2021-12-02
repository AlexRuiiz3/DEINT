using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models.ViewModels
{
    public class ClsDepartamentoConPersonasSimplificadasVM : ClsDepartamento
    {
        #region Constructores
        //Constructor sin parametros
        public ClsDepartamentoConPersonasSimplificadasVM() : base()
        {
            ListaPersonas = new List<ClsPersonaNombreApellidos>();
        }
        //Constructor con parametros
        public ClsDepartamentoConPersonasSimplificadasVM(ClsDepartamento departamento, List<ClsPersonaNombreApellidos> listaPersonas) : base(departamento.ID, departamento.Nombre)
        {
            ListaPersonas = listaPersonas;
        }
        #endregion

        #region Propiedades
        [Display(Name = "Lista personas:")]
        public List<ClsPersonaNombreApellidos> ListaPersonas { get; set; }
        #endregion
    }
}
