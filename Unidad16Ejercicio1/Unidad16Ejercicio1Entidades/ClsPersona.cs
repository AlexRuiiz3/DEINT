/*
 * Nombre: ClsPersona
 * 
 * Comentario: Esta clase representa a una persona de la tabla Persona de una BBDD, siendo cada atributo una columna que esta definida en la tabla Persona
 * 
 * Atributos:   Basicos: Definido por propiedades autoimplementadas.
 *              Derivados: Ninguno.
 *              Compartidos: Ninguno.
 * 
 * Metodos Fundamentales:
 *                Propiedades: -public int ID
 *                             -public string Nombre
 *                             -public string Apellidos
 *                             -public string Telefono
 *                             -public string Direccion
 *                             -public byte[] Foto
 *                             -public DateTime FechaNacimiento
 *                             -public int IdDepartamento
 *                          
 * 
 * Metodos heredados: Ninguno.
 * Metodos añadidos: Ninguno.
 */
using System;

namespace Unidad16Ejercicio1Entidades
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
        
        public string Nombre { get; set; }
        //Apellidos
        
        public string Apellidos { get; set; }
        //Telefono
        public string Telefono { get; set; }
        //Direccion
        public string Direccion { get; set; }
        //Foto
        public byte[] Foto { get; set; }
        //FechaNacimiento
        public DateTime FechaNacimiento { get; set; }
        //IdDepartamento
        public int IdDepartamento { get; set; }
        #endregion
    }
}