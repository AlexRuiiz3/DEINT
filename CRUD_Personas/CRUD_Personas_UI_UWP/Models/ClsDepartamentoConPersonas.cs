/*
 * Nombre: ClsDepartamentoConPersonas
 * 
 * Comentario: Esta clase representa a un departamento que hereda de ClsDepartamento y se le añade una lista de personas que estan asociadas a ese departamento.
 * 
 * Atributos:   Basicos: Definido por propiedades autoimplementadas.
 *              Derivados: Ninguno.
 *              Compartidos: Ninguno.
 * 
 * Metodos Fundamentales:
 *                Propiedades: - public List<ClsPersona> ListaPersonas
 *                          
 * 
 * Metodos heredados: Ninguno.
 * Metodos añadidos: Ninguno.
 */

using System.Collections.Generic;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_UWP.Models
{
    public class ClsDepartamentoConPersonas : ClsDepartamento
    {
        #region Constructores
        //Constructor por defecto
        public ClsDepartamentoConPersonas() : base()
        {
            ListaPersonas = new List<ClsPersona>();
        }
        //Constructor con parametros
        public ClsDepartamentoConPersonas(ClsDepartamento departamento, List<ClsPersona> listaPersonas) : base(departamento.ID, departamento.Nombre)
        {
            ListaPersonas = listaPersonas;
        }        
        //Constructor de copia
        public ClsDepartamentoConPersonas(ClsDepartamentoConPersonas otro)
        {
            ID = otro.ID;
            Nombre = otro.Nombre;
            ListaPersonas = otro.ListaPersonas;
        }
        #endregion

        #region Propiedades
        //ListaPersonas
        public List<ClsPersona> ListaPersonas { get; set; }
        #endregion
    }
}
