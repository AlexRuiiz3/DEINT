using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unidad16Ejercicio1DAL.Gestora;

namespace Unidad16Ejercicio1BL.Gestora
{
    public class GestoraPersonasBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> eliminarPersona(int id) {
            HttpStatusCode statusCode = new HttpStatusCode();
            try {
                statusCode = await GestoraPersonasDAL.eliminarPersona(id);
            }
            catch (Exception) {
                throw;
            }
            return statusCode;
        }
    }
}
