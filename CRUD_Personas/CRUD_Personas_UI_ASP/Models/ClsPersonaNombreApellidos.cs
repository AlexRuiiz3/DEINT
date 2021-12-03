/*
 * Nombre: ClsPersonaNombreApellidos
 * 
 * Comentario: Esta clase representa a una persona de ClsPersona(Capa entidades) pero simplificandola a solo nombre y apellidos
 * 
 * Atributos:   Basicos: Definido por propiedades autoimplementadas.
 *              Derivados: Ninguno.
 *              Compartidos: Ninguno.
 * 
 * Metodos Fundamentales:
 *                Propiedades: -public string Nombre
 *                             -public string Apellidos
 *                          
 * 
 * Metodos heredados: Ninguno.
 * Metodos añadidos: Ninguno.
 */

using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Models
{
    public class ClsPersonaNombreApellidos
    {
        #region Constructores
        //Constructor por defecto
        public ClsPersonaNombreApellidos()
        {
            Nombre = "";
            Apellidos = "";
        }

        //Constructor con parametros
        public ClsPersonaNombreApellidos(ClsPersona persona)
        {
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
        }
        #endregion

        #region Propiedades
        //Nombre
        public string Nombre { get; set; }
        //Apellidos
        public string Apellidos { get; set; }
        #endregion
    }
}
