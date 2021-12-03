/*
 * Nombre: ClsPersonaNombreDepartamento
 * 
 * Comentario: Esta clase representa a una persona que hereda de CLSPersona y se le añade el nombre del departamento que tiene asignado.
 * 
 * Atributos:   Basicos: Definido por propiedades autoimplementadas.
 *              Derivados: Ninguno.
 *              Compartidos: Ninguno.
 * 
 * Metodos Fundamentales:
 *                Propiedades: -public string NombreDepartamento
 *                          
 * 
 * Metodos heredados: Ninguno.
 * Metodos añadidos: Ninguno.
 */
using System.ComponentModel.DataAnnotations;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersonaNombreDepartamento : ClsPersona
    {
        #region Constructores
        //Constructor sin parametros
        public ClsPersonaNombreDepartamento() : base()
        {
            NombreDepartamento = "";
        }
        //Constructor con parametros
        public ClsPersonaNombreDepartamento(ClsPersona persona, string nombreDepartamento) : base(persona.ID, persona.Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDepartamento)
        {
            NombreDepartamento = nombreDepartamento;
        }
        #endregion

        #region Propiedades
        //NombreDepartamento
        [Display(Name = "Nombre Departamento:")]
        public string NombreDepartamento { get; set; }
        #endregion
    }
}
