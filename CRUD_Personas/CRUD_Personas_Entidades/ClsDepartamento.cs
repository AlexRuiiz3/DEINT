/*
 * Nombre: ClsPersona
 * 
 * Comentario: Esta clase representa a un departamento de la tabla Departamento de una BBDD, siendo cada atributo una columna que esta definida en la tabla Departamento
 * 
 * Atributos:   Basicos: Definido por propiedades autoimplementadas.
 *              Derivados: Ninguno.
 *              Compartidos: Ninguno.
 * 
 * Metodos Fundamentales:
 *                Propiedades: -public int ID
 *                             -public string Nombre
 *                          
 * 
 * Metodos heredados: Ninguno.
 * Metodos añadidos: Ninguno.
 */
using System.ComponentModel.DataAnnotations;

namespace CRUD_Personas_Entidades
{
    public class ClsDepartamento
    {
        #region Constructores
        //Constructor sin parametros
        public ClsDepartamento()
        {
            ID = 0;
            Nombre = "";
        }
        //Constructor con parametros
        public ClsDepartamento(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }
        #endregion

        #region Propiedades
        //ID
        public int ID { get; set; }
        //Nombre
        [Required, MaxLength(30, ErrorMessage = "Longitud maxima 30 caracteres"), Display(Name = "Nombre:")]
        public string Nombre { get; set; }
        #endregion
    }
}
