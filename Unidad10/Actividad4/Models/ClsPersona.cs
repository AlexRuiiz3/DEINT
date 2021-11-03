using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4.Models
{
    public class ClsPersona : INotifyPropertyChanged
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
            
            set { nombre = value;
                OnPropertyChanged("Nombre");
            } 
        }
        public String Apellidos
        {
            get { return apellidos; }

            set
            { 
                apellidos = value;
                OnPropertyChanged("Apellidos");

                if (apellidos.Length > 0 && Char.ToUpper(apellidos[apellidos.Length - 1]) == 'N') {
                    nombre = "";
                    OnPropertyChanged("Nombre");
                }
            }
        }
        public String FechaNacimiento
        {
            get { return fechaNacimiento; }

            set { fechaNacimiento = value;
                OnPropertyChanged("FechaNacimiento");
            }
        }
        public String Direccion
        {
            get { return direccion; }

            set
            { direccion = value;
                OnPropertyChanged("Direccion");
            }
        }
        public String Telefono
        {
            get { return telefono; }

            set { telefono = value;
                OnPropertyChanged("Telefono");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
