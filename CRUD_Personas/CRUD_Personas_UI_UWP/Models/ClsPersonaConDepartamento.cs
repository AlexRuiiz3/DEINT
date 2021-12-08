/*
 * Nombre: ClsPersonaConNombreDepartamento
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
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_UWP.Models
{
    public class ClsPersonaConDepartamento : ClsPersona
    {
        #region Constructores
        //Constructor por defecto
        public ClsPersonaConDepartamento() : base() {
            NombreDepartamento = "Sin Departamento";
        }
        //Constructor con parametros
        public ClsPersonaConDepartamento(ClsPersona persona, string nombreDepartamento) : base(persona.ID,persona.
            Nombre,persona.Apellidos,persona.Telefono,persona.Direccion,persona.Foto,persona.FechaNacimiento,
            persona.IdDepartamento) {
            NombreDepartamento = nombreDepartamento;
        }
        //Constructor de copia
        public ClsPersonaConDepartamento(ClsPersonaConDepartamento otra)
        {
            ID = otra.ID;
            Nombre = otra.Nombre;
            Apellidos = otra.Apellidos;
            Telefono = otra.Telefono;
            Direccion = otra.Direccion;
            Foto = otra.Foto;
            FechaNacimiento = otra.FechaNacimiento;
            IdDepartamento = otra.IdDepartamento;
            NombreDepartamento = otra.NombreDepartamento;
        }
        #endregion

        #region Propiedades
        //NombreDepartamento
        public string NombreDepartamento {get;set;}
        #endregion
    }
}
