using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [Required, Display(Name = "Nombre")]
        public string Nombre { get; set; }
        #endregion
    }
}
