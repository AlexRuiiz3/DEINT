using System;
using System.Collections.Generic;
using System.Text;
using Unidad16Ejercicio1Entidades;
using Unidad16Ejercicio1DAL.Conexion;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Unidad16Ejercicio1DAL.Listados
{
    public class ListadosDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersona>> obtenerPersonas() {
            List<ClsPersona> listaPersonas = new List<ClsPersona>();

            Uri uri = new Uri($"{clsMyConexion.getUriBase()}Personas");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse;
            string respuestaPeticion;

            try
            {
                httpResponse = await httpClient.GetAsync(uri);
                if (httpResponse.IsSuccessStatusCode) { //Si se obtuvo una respuesta correcta(Se pudo conectar a la api)
                    respuestaPeticion = await httpClient.GetStringAsync(uri);
                    httpClient.Dispose(); //Para liberar recursos

                    listaPersonas = JsonConvert.DeserializeObject<List<ClsPersona>>(respuestaPeticion);
                }
            }
            catch (Exception) {
                throw;
            }

            return listaPersonas;
        }
    }
}
