using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Personas_Entidades
{
    public class ClsPersona
    {
        #region Constructores
        //Constructor sin parametros
        public ClsPersona()
        {
            ID = 0;
            Nombre = "";
            Apellidos = "";
            Telefono = "";
            Direccion = "";
            Foto = new byte[0];
            FechaNacimiento = DateTime.Now;
            IdDepartamento = 0;
        }
        //Constructor con parametros
        public ClsPersona(int id, string nombre, string apellidos, string telefono, string direccion, byte[] foto, DateTime fechaNacimiento, int idDepartamento)
        {
            ID = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            FechaNacimiento = fechaNacimiento;
            IdDepartamento = idDepartamento;
        }
        #endregion

        #region Propiedades
        //ID
        public int ID { get; set; } 
        //Nombre
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Nombre")]
        public string Nombre { get; set; }
        //Apellidos
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        //Telefono
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Telefono"),
        RegularExpression(@"(\+34|0034|34)?[ -]*(6|7)[ -]*([0-9][ -]*){8}", ErrorMessage = "Formato de telefono no español")]
        public string Telefono { get; set; }
        //Direccion
        [Required(ErrorMessage = "Campo obligatorio"), Display(Name = "Direccion")]
        public string Direccion { get; set; }
        //Foto
        [Display(Name = "Foto")]
        public byte[] Foto { get; set; }
        //FechaNacimiento
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        //IdDepartamento
        public int IdDepartamento { get; set; }
        #endregion
    }
}