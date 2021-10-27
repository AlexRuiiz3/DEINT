using Actividad2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2.ViewModels
{
    public class MainPageVM
    {

        private ClsPersona oPersona = new ClsPersona();

        public ClsPersona OPersona { get => oPersona; set => oPersona = value; }

        
    }
}
