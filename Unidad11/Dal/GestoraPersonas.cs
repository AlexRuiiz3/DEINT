using System;
using System.Collections.Generic;
using Entidades;

namespace Dal
{
    public class GestoraPersonas
    {
        public static List<ClsPersona> obtenerPersonas() {
            List<ClsPersona> listaPersonas = new List<ClsPersona>();

            listaPersonas.Add(new ClsPersona("Persona1","Apellido1",20));
            listaPersonas.Add(new ClsPersona("Persona2", "Apellido2", 20));
            listaPersonas.Add(new ClsPersona("Persona3", "Apellido3", 20));
            listaPersonas.Add(new ClsPersona("Persona4", "Apellido4", 20));
            listaPersonas.Add(new ClsPersona("Persona5", "Apellido5", 20));
            listaPersonas.Add(new ClsPersona("Persona6", "Apellido6", 20));

            return listaPersonas;


        }
    }
}
