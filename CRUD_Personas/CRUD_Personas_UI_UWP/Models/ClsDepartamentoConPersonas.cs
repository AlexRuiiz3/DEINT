using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_UWP.Models
{
    public class ClsDepartamentoConPersonas : ClsDepartamento
    {

        public ClsDepartamentoConPersonas() : base()
        {
            ListaPersonas = new List<ClsPersona>();
        }

        public ClsDepartamentoConPersonas(ClsDepartamento departamento, List<ClsPersona> listaPersonas) : base(departamento.ID, departamento.Nombre)
        {
            ListaPersonas = listaPersonas;
        }
        public List<ClsPersona> ListaPersonas { get; set; }


    }
}
