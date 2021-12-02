using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models.ViewModels
{
    public class ClsDepartamentoListaPersonasVM : ClsDepartamento
    {
        public List<ClsPersonaNombreApellidos> ListaPersonas { get; set; }

        public ClsDepartamentoListaPersonasVM():base() {
            ListaPersonas = new List<ClsPersonaNombreApellidos>();
        }
        public ClsDepartamentoListaPersonasVM(ClsDepartamento departamento, List<ClsPersonaNombreApellidos> listaPersonas) : base(departamento.ID,departamento.Nombre)
        {
            ListaPersonas = listaPersonas;
        }
    }
}
