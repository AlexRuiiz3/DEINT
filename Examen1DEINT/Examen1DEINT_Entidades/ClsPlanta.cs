using System;
using System.Collections.Generic;
using System.Text;

namespace Examen1DEINT_Entidades
{
    public class ClsPlanta
    {
        #region Constructores
        //Constructor por defecto
        public ClsPlanta()
        {
            Id = 0;
            Nombre = "";
            Descripcion = "";
            IdCategoria = 0;
            Precio = 0;

        }
        //Constructor con parametros
        public ClsPlanta(int id, string nombre, string descripcion, int idCategoria, double precio)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            IdCategoria = idCategoria;
            Precio = precio;
        }
        #endregion

        #region Propiedades
        //ID
        public int Id { get; set; }
        //Nombre
        public string Nombre { get; set; }
        //Descripcion
        public string Descripcion { get; set; }
        //IDCategoria
        public int IdCategoria { get; set; }
        //Precio
        public double Precio { get; set; }
        #endregion
    }
}
