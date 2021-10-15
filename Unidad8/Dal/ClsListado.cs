using System;
using System.Collections.Generic;
using System.Text;
using MisClases;

namespace Dal

{
    public class ClsListados
    {


        public List<ClsPersona> getListadoCompletoPersonas()
        {
            List<ClsPersona> listaPersonas = new List<ClsPersona>();

            listaPersonas.Add(new ClsPersona { Nombre = "Fernando1" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando2" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando3" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando4" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando5" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando6" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando7" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando8" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando9" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando10" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando11" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando12" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando13" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando14" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando15" });
            listaPersonas.Add(new ClsPersona { Nombre = "Fernando16" });

            return listaPersonas;
        }
    }
}
