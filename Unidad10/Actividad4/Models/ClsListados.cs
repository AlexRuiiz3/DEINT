using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad4.Models
{
    public class ClsListados
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<ClsPersona> personas</returns>
        public static ObservableCollection<ClsPersona> obtenerPersonas() {
            ObservableCollection<ClsPersona> personas = new ObservableCollection<ClsPersona>();

            personas.Add(new ClsPersona("Alejandro","Ruiz","29/12/2000","Direccion calle","999999999"));
            personas.Add(new ClsPersona("Nombre1", "Apellido1", "29/12/2000", "Direccion calle1", "111111111"));
            personas.Add(new ClsPersona("Nombre2", "Apellido2", "29/12/2000", "Direccion calle2", "222222222"));
            personas.Add(new ClsPersona("Nombre3", "Apellido3", "29/12/2000", "Direccion calle3", "333333333"));
            personas.Add(new ClsPersona("Nombre4", "Apellido4", "29/12/2000", "Direccion calle4", "444444444"));
            personas.Add(new ClsPersona("Nombre5", "Apellido5", "29/12/2000", "Direccion calle5", "555555555"));
            personas.Add(new ClsPersona("Nombre6", "Apellido6", "29/12/2000", "Direccion calle6", "666666666"));
            personas.Add(new ClsPersona("Nombre7", "Apellido7", "29/12/2000", "Direccion calle7", "777777777"));
            personas.Add(new ClsPersona("Nombre8", "Apellido8", "29/12/2000", "Direccion calle8", "888888888"));

            return personas;
        }
    }
}
