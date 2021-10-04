using System;

namespace Entidades
{
    public class ClsPersona
    {

        #region Atributos privados
        private String nombre;
        #endregion


        #region Constructores
        //Constructro por defecto
        public ClsPersona() {
            nombre = "";
        }

        //Constructor con parametros
        public ClsPersona(String nombre) {

            this.nombre = nombre;
        }
        #endregion


        #region Propiedades publicas 
        //Nombre
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        /* Otras formas
         * 
         * 1.
         *
         *   private String nombre;
         *   public String GetNombre() => nombre;
         *   public void SetNombre(String nombre) { this.nombre = nombre; }* private String nombre;
         * 
         *
         * 
         * 2.Propiedades auto implementadas //Son las que luego en el get y en el set no se va a introducir mas codigo
         * public String nombre{get,set} //por defecto se crea un private String nombre
         * 
         * 
         * 3.public String nombre {get => nombre; set => nombre = value;}
         */



    }
}
