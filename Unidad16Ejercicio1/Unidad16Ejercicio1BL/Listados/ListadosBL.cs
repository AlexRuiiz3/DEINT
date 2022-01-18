using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unidad16Ejercicio1Entidades;
using Unidad16Ejercicio1DAL.Listados;

namespace Unidad16Ejercicio1BL.Listados
{
    public class ListadosBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersona>> obtenerPersonas() {
           List<ClsPersona> listaPersonas = new List<ClsPersona>();
            try {
                listaPersonas = await ListadosDAL.obtenerPersonas();
            }
            catch (Exception) {
                throw;
            }
            return listaPersonas;
        }
    }
}
