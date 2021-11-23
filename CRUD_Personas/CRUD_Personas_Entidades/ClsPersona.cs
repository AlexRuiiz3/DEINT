using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Personas_Entidades
{
    public class ClsPersona
    {
        public ClsPersona() {
            ID = 0;
            Nombre = "";
            Apellidos = "";
            Telefono = "";
            Direccion = "";
            Foto = new byte[0];
            FechaNacimiento = new DateTime();
            IdDepartamento = 0;
        }

        public ClsPersona(int id, string nombre, string apellidos, string telefono, string direccion, byte[] foto, DateTime fechaNacimiento, int idDepartamento) {
            ID = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            FechaNacimiento = fechaNacimiento;
            IdDepartamento = idDepartamento;
        }
        
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdDepartamento { get; set; }
    }
}