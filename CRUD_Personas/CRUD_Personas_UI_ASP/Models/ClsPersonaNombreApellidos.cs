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
