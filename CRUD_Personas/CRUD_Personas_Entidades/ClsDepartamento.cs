using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class ClsDepartamento
    {
        //Las propiedades autoimplementadas crean un atributo privado
        public int ID { get; set; }
        public string Nombre { get; set; }

        public ClsDepartamento() {
            ID = 0;
            Nombre = "";
        }
        public ClsDepartamento(int id, string nombre) {
            ID = id;
            Nombre = nombre;
        }
    }
}
