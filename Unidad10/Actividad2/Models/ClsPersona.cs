using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2.Models
{
    public class ClsPersona : INotifyPropertyChanged
    {
        private String nombre;
        private String apellidos;

        public ClsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        #region Metodos Fundamentales
        public String Nombre { 
            get { return nombre; }
            
            set {
              
                nombre = value;
                if (nombre.Length > 0 && Char.ToUpper(nombre[nombre.Length - 1]) == 'N')
                {
                    apellidos = ""; //Ahora hay que notificar al xaml, las propiedades normales y corrientes como esta hay que notificarlas
                    this.OnPropertyChanged("Apellidos");
                }

                } 
        }
        public String Apellidos
        {
            get { return apellidos; }

            set
            {
                apellidos = value;
                
                if (apellidos.Length > 0 && Char.ToUpper(apellidos[apellidos.Length - 1]) == 'N')
                {
                    nombre = ""; //Ahora hay que notificar al xaml, las propiedades normales y corrientes como esta hay que notificarlas
                    
                    //Cuando una propiedad de fuera a cambiado hay que notificarlo a la vista 
                    this.OnPropertyChanged("Nombre");//hay que poner el nombre de la propiedad que esta bindeada binding
                                         //Se notifica que las proiedad a cambiado
                }

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
