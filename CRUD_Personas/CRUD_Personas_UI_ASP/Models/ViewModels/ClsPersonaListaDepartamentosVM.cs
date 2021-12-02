﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models.ViewModels
{
    public class ClsPersonaListaDepartamentosVM : ClsPersona
    {
        public ClsPersonaListaDepartamentosVM() : base()
        {
            ListaDepartamentos = new List<ClsDepartamento>();
        }

        public ClsPersonaListaDepartamentosVM(ClsPersona persona, List<ClsDepartamento> listaDepartamentos) : base(persona.ID, persona.Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDepartamento)
        {
            ListaDepartamentos = listaDepartamentos;
        }

        public List<ClsDepartamento> ListaDepartamentos { get; set; }

    }
}
