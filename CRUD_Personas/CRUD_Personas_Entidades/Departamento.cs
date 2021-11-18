using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class Departamento
    {
        //Las propiedades autoimplementadas crean un atributo privado
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Departamento(int id, string nombre) {
            ID = id;
            Nombre = nombre;
        }
    }
}
