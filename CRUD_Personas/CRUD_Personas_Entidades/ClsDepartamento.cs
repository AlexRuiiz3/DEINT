using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class ClsDepartamento
    {
        public ClsDepartamento() {
            ID = 0;
            Nombre = "";
        }
        public ClsDepartamento(int id, string nombre) {
            ID = id;
            Nombre = nombre;
        }

        public int ID { get; set; }
        [Required, Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
