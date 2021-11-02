using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4.Models
{
    public class ClsPersona
    {
        private String nombre;
        private String apellidos;
        private String fechaNacimiento;
        private String direccion;
        private String telefono;

        public ClsPersona()
        {
            nombre = "";
            apellidos = "";
            fechaNacimiento = "";
            direccion = "";
            telefono = "";
        }

        public ClsPersona(String nombre, String apellidos, String fechaNacimiento, String direccion, String telefono) {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
        
        }
 

        #region Metodos Fundamentales
        public String Nombre { 
            get { return nombre; }
            
            set { nombre = value; } 
        }
        public String Apellidos
        {
            get { return apellidos; }

            set
            { apellidos = value; }
        }
        public String FechaNacimiento
        {
            get { return fechaNacimiento; }

            set { fechaNacimiento = value; }
        }
        public String Direccion
        {
            get { return direccion; }

            set
            { direccion = value; }
        }
        public String Telefono
        {
            get { return telefono; }

            set { telefono = value; }
        }
        #endregion
    }
}
