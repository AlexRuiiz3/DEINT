using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            FechaNacimiento = DateTime.Now;
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
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Telefono"),
        RegularExpression(@"(\+34|0034|34)?[ -]*(6|7)[ -]*([0-9][ -]*){8}", ErrorMessage = "Formato de telefono no español")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Display(Name = "Foto")]
        public byte[] Foto { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public int IdDepartamento { get; set; }
    }
}