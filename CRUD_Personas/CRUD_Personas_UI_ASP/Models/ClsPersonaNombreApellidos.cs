using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersonaNombreApellidos
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        #region Constructores
        //Constructor por defecto
        public ClsPersonaNombreApellidos() {
            Nombre = "";
            Apellidos = "";
        }

        //Constructor con parametros
        public ClsPersonaNombreApellidos(ClsPersona persona){
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
        }
        #endregion
    }
}
