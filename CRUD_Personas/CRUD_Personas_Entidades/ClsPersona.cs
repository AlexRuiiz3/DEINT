using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Personas_Entidades
{
    //[Table("Personas")]
    public class ClsPersona
    {
        public ClsPersona() {
            ID = 0;
            Nombre = "";
            Apellidos = "";
            Telefono = "";
            Direccion = "";
            Foto = 0;
            FechaNacimiento = "";
            IdDepartamento = 0;
        }

        public ClsPersona(int id, string nombre, string apellidos, string telefono, string direccion, int foto, string fechaNacimiento, int idDepartamento) {
            this.ID = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Foto = foto;
            this.FechaNacimiento = fechaNacimiento;
            this.IdDepartamento = idDepartamento;
        }
        
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Foto { get; set; }
        public string FechaNacimiento { get; set; }
        public int IdDepartamento { get; set; }
    }
}