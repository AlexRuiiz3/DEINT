using CRUD_Personas_BL.Listados;
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
            List<ClsPersona> listaPersonas = ListadosBL.obtenerPersonas();

            return listaPersonas;
        }
        // GET api/<PersonasController>/5
        //Documentar la ruta que tiene cada parte 
        [HttpGet("{id}")]
        public string Get(int id) //
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value) //Para crear recuros
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) //Para editar recursos
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) //Eliminar Recursos
        {
        }
    }
}
