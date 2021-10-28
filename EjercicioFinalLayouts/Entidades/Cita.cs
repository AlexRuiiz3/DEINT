using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cita
    {

        #region Attibutos
        private String diaSemana;
        private int dia;
        private String mes;
        private String horario;
        private String direccion;
        private String codigoPostal;
        #endregion

        #region Constructor con parametros
        public Cita(String diaSemana, int dia, String mes, String horario, String direccion, String codigoPostal) {
            this.diaSemana = diaSemana;
            this.dia = dia;
            this.mes = mes;
            this.horario = horario;
            this.direccion = direccion;
            this.codigoPostal = codigoPostal;
        }
        #endregion

        #region Metodos fundamentales
        //diaSemana
        public String DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }
        //dia
        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }
        //mes
        public String Mes
        {
            get { return mes; }
            set { mes = value; }
        }
        //horario
        public String Horario
        {
            get { return horario; }
            set { horario = value; }
        }
        //direccion
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        //codigoPostal
        public String CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        #endregion

    }
}
