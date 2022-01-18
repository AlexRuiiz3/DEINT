using System;
using System.Collections.Generic;
using System.Text;
using Unidad16Ejercicio1Entidades;
using Unidad16Ejercicio1DAL.Conexion;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace Unidad16Ejercicio1DAL.Gestora
{
    public class GestoraPersonasDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> eliminarPersona(int id)
        {
            Uri uri = new Uri($"{clsMyConexion.getUriBase()}Personas/{id}");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpClient.DeleteAsync(uri);
            return httpResponse.StatusCode;
        }

    }
}
