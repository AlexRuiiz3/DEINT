﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EjercicioFinalLayouts.ViewModels
{
    public class DetallesCitaViewVM
    {

        private Cita cita;
        private String nombreCliente;
        private String telefono;

        public DetallesCitaViewVM(Cita cita, String nombreCliente, String telefono) {
            this.cita = cita;
            this.nombreCliente = nombreCliente;
            this.telefono = telefono;
        
        }

        public Cita Cita
        {
            get { return cita; }
            set { cita = value; }
        }

        public String NombreCliente {
            get { return nombreCliente;}
            set { nombreCliente = value;}
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

    }
}
