﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;
using CRUD_Personas_UI_UWP.ViewModels.Utilidades;

namespace CRUD_Personas_UI_UWP.Models
{
    public class ClsPersonaConDepartamento : ClsPersona
    {
        public ClsPersonaConDepartamento() : base() {
            NombreDepartamento = "Sin Departamento";
        }
        public ClsPersonaConDepartamento(ClsPersona persona, string nombreDepartamento) : base(persona.ID,persona.
            Nombre,persona.Apellidos,persona.Telefono,persona.Direccion,persona.Foto,persona.FechaNacimiento,
            persona.IdDepartamento) {
            NombreDepartamento = nombreDepartamento;
        }

        public ClsPersonaConDepartamento(ClsPersonaConDepartamento persona) : base(persona.ID, persona.
            Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento,
            persona.IdDepartamento)
        {
            NombreDepartamento = persona.NombreDepartamento;
        }
        public string NombreDepartamento {get;
            set;}
    }
}
