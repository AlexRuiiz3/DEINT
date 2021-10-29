using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dal
{
    public class GestoraCitas
    {

        /// <summary>
        /// Cabecera: public static List<Cita> obtenerCitas()
        /// Comentario: Este metodo se encarga de generar una lista de objetos de tipo Cita.
        /// Entradas: Ninguna.
        /// Salidas: List<Cita> citas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Este metodo se trata de una funcion por lo tanto devolvuelve un valor, en este cado una 
        ///                  lista de objetos de tipo Cita.
        /// </summary>
        /// <returns>citas</returns>
        public static List<Cita> obtenerCitas() {
            List<Cita> citas = new List<Cita>();

            citas.Add(new Cita("Lunes",25,"Octubre","13:45","Calle Ramon y Cajal","41975"));
            citas.Add(new Cita("Martes", 26, "Octubre","13:45", "Calle Ramon y Cajal", "47589"));
            citas.Add(new Cita("Miercoles", 27, "Octubre","13:45", "Calle calle calle", "42369"));
            citas.Add(new Cita("Jueves", 1, "Noviembre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Viernes", 4, "Noviembre","13:45", "Calle Sin Salida", "47589"));
            citas.Add(new Cita("Sabado", 6, "Noviembre","13:45", "Calle Ramon y Cajal", "47589"));
            citas.Add(new Cita("Domingo", 20, "Noviembre","13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Lunes", 1, "Enero", "13:45", "Calle Ramon y Cajal", "47589"));
            citas.Add(new Cita("Martes", 5, "Enero", "13:45", "Calle Ramon y Cajal", "41975"));
            citas.Add(new Cita("Miercoles", 10, "Enero", "13:45", "Calle Ramon y Cajal", "47589"));
            citas.Add(new Cita("Jueves", 22, "Enero", "13:45", "Calle Ramon y Cajal", "41975"));

            return citas;
        }
    }
}
