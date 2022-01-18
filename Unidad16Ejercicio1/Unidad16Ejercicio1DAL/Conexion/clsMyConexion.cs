using System;
using System.Collections.Generic;
using System.Text;

namespace Unidad16Ejercicio1DAL.Conexion
{
    public class clsMyConexion
    {
        private static string uriBase = "https://crudpersonasasp-alexruiz.azurewebsites.net/api/";
        public static string getUriBase()
        {
            return uriBase;
        }

    }
}
