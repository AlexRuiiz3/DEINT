using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen1DEINT_Entidades;

namespace Examen1DEINT_UI.Models
{
    public class ClsPlantaConCantidad : ClsPlanta
    {
        public ClsPlantaConCantidad(ClsPlanta planta,int cantidad):base(planta.Id,planta.Nombre,planta.Descripcion,planta.IdCategoria,planta.Precio) {
            Cantidad = cantidad;
        }

        public int Cantidad;

    }
}
