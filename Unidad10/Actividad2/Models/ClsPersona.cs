using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2.Models
{
    public class ClsPersona
    {
        private String nombre;
        private String apellidos;


        public ClsPersona()
        {
            nombre = "Alejandro";
            apellidos = "Ruiz Campos";
        }

        #region Metodos Fundamentales
        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellidos { get => apellidos; set => apellidos = value; }
        #endregion


    }
}
