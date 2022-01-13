using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_UI_ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController> ruta para acceder a la api con localHost/...
        [HttpGet]
        public IEnumerable<ClsPersona> Get()
        {
            List<ClsPersona> listaPersonas = new List<ClsPersona>();
            try
            {
                listaPersonas = ListadosBL.obtenerPersonas();  
            }
            catch (Exception)
            {

            }
            return listaPersonas;
        }
        // GET api/<PersonasController>/5
        //Documentar la ruta que tiene cada parte 
        [HttpGet("{id}")]
        public ClsPersona Get(int id) //
        {
            ClsPersona persona = new ClsPersona();
            try
            {
                persona = ListadosBL.obtenerPersona(id);
            }
            catch (Exception)
            {

            }
            return persona;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] ClsPersona persona) //Para crear recuros
        {
            try
            {
                GestoraPersonasBL.anhadirPersona(persona);
            }
            catch (Exception)
            {

            }
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClsPersona persona) //Para editar recursos
        {
            try
            {
                GestoraPersonasBL.editarPersona(persona);
            }
            catch (Exception)
            {

            }
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) //Eliminar Recursos
        {
            try
            {
                GestoraPersonasBL.eliminarPersona(id);
            }
            catch (Exception)
            {

            }
        }
    }
}
