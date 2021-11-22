﻿using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_Entidades;
using CRUD_Personas_Dal;
using System.Collections.ObjectModel;

namespace CRUD_Personas_BL.Listados
{
    public class ListadosBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ClsPersona> obtenerPersonas()
        {
            return ListadosDAL.obtenerPersonas();
        }
    }
}
