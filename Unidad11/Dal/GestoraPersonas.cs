using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Entidades;

namespace Dal
{
    public class GestoraPersonas
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ClsPersona> obtenerPersonas() {
            ObservableCollection<ClsPersona> listaPersonas = new ObservableCollection<ClsPersona>();

            listaPersonas.Add(new ClsPersona("Persona1","Apellido1",20));
            listaPersonas.Add(new ClsPersona("Persona2", "Apellido21", 20));
            listaPersonas.Add(new ClsPersona("Persona3", "Apellido3", 20));
            listaPersonas.Add(new ClsPersona("Persona4", "Apellido4", 20));
            listaPersonas.Add(new ClsPersona("Persona5", "Apellido5", 20));
            listaPersonas.Add(new ClsPersona("Persona6", "Apellido6", 20));

            return listaPersonas;


        }
    }
}
