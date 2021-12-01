using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Personas_UI_ASP.Models;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;
using CRUD_Personas_BL.Gestora;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CRUD_Personas_UI_ASP.Controllers
{
    public class ClsPersonaDepartamentosController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<ClsPersonaSimplificada> listaClsPersonaSimplificada = new List<ClsPersonaSimplificada>();
            try
            {
                List<ClsPersona> listaPersonas = ListadosBL.obtenerPersonas();
                List<ClsDepartamento> listaDepartamentos = ListadosBL.obtenerDepartamentos();
                ClsPersona persona;
                for (int i = 0; i < listaPersonas.Count; i++)
                {
                    persona = listaPersonas.ElementAt(i);

                    listaClsPersonaSimplificada.Add(new ClsPersonaSimplificada(persona,
                                                  obtenerNombreDepartamento(listaDepartamentos,persona.IdDepartamento)));
                }
            }
            catch (Exception)
            {
                return View("ViewNotFound");
            }

            return View(listaClsPersonaSimplificada);
        }

        private string obtenerNombreDepartamento(List<ClsDepartamento> listaDepartamentos,int id) {
            string nombre = "";

            for (int i = 0; i < listaDepartamentos.Count && nombre == ""; i++)
            {
                if (listaDepartamentos.ElementAt(i).ID == id) {
                    nombre = listaDepartamentos.ElementAt(i).Nombre;
                }
            }

            return nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            ClsPersonaNombreDepartamento clsPersonaDepartamento = null;
            try
            {
                var clsPersonas = from persona in ListadosBL.obtenerPersonas()
                                  where persona.ID == (int)id
                                  select persona;

                clsPersonaDepartamento = new ClsPersonaNombreDepartamento(clsPersonas.ElementAt(0), ListadosBL.obtenerNombreDepartamento(clsPersonas.ElementAt(0).IdDepartamento));
            }
            catch (Exception)
            {
                return View("ViewNotFound");
            }

            return View(clsPersonaDepartamento);
        }

        // GET: ClsPersonaDepartamentoes/Create
        public IActionResult Create()
        {
            ClsPersonaDepartamentos clsPersonaDepartamentos = new ClsPersonaDepartamentos();
            try
            {
                clsPersonaDepartamentos.ListaDepartamentos = ListadosBL.obtenerDepartamentos();
            }
            catch (Exception)
            {
                return View("ViewNotFound");
            }


            return View(clsPersonaDepartamentos);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPersonaDepartamento"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost(ClsPersonaDepartamentos personaDepartamentos)
        {
            IActionResult action = null;
            try {
                GestoraPersonasBL.anhadirPersona(personaDepartamentos);
                action = RedirectToAction("Index");
            }
            catch (Exception) {
                action = View("ViewNotFound");
            }
            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {

            ClsPersonaDepartamentos clsPersonaDepartamentos = null;
            try
            {

                clsPersonaDepartamentos = new ClsPersonaDepartamentos(ListadosBL.obtenerPersona(id),
                                                                      ListadosBL.obtenerDepartamentos());
            }
            catch (Exception)
            {
                return View("ViewNotFound");
            }
            return View(clsPersonaDepartamentos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPersonaDepartamento"></param>
        /// <param name="imagen"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ClsPersonaDepartamentos clsPersonaDepartamento,IFormFile imagen)
        {
            IActionResult action = null;
            int numActualizaciones;

            try
            {
                clsPersonaDepartamento.Foto = rellenarArrayByte(imagen);
                numActualizaciones = GestoraPersonasBL.editarPersona(clsPersonaDepartamento);
                if (numActualizaciones > 0)
                {
                    ViewBag.NumActualiazciones = numActualizaciones;
                    action = RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return action;
        }

        private byte[] rellenarArrayByte(IFormFile file) {
            byte[] arrayByte = new byte[0];

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    arrayByte = ms.ToArray();
                }
            }
            return arrayByte;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            IActionResult action = null;
            if (id == null)
            {
                action = View("ViewNotFound");
            }

            ClsPersonaNombreDepartamento clsPersonaDepartamento = null;
            try
            {
                var clsPersonas = from persona in ListadosBL.obtenerPersonas()
                                  where persona.ID == (int)id
                                  select persona;

                clsPersonaDepartamento = new ClsPersonaNombreDepartamento(clsPersonas.ElementAt(0), ListadosBL.obtenerNombreDepartamento(clsPersonas.ElementAt(0).IdDepartamento));
                action = View(clsPersonaDepartamento);
            }
            catch (Exception)
            {
                action = View("ViewNotFound");
            }

            return action;
        }

        // POST: ClsPersonaDepartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CambiosRealizados()
        {
            ClsPersonaDepartamentos clsPersonaDepartamentos = new ClsPersonaDepartamentos();
            try
            {
                clsPersonaDepartamentos.ListaDepartamentos = ListadosBL.obtenerDepartamentos();
                ClsDepartamento a = null;
                int b = a.ID;
            }
            catch (Exception)
            {
                return View("ViewNotFound");
            }


            return View(clsPersonaDepartamentos);
        }
    }
}
