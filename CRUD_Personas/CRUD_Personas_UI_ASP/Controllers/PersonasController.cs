using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CRUD_Personas_UI_ASP.Models;
using CRUD_Personas_UI_ASP.Models.ViewModels;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;
using CRUD_Personas_BL.Gestora;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace CRUD_Personas_UI_ASP.Controllers
{
    public class PersonasController : Controller
    {

        #region Actions
        //Index

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IActionResult action;
            List<ClsPersonaSimplificadaNombreDepartamento> listaClsPersonaSimplificada = new List<ClsPersonaSimplificadaNombreDepartamento>();
            try
            {
                List<ClsPersona> listaPersonas = ListadosBL.obtenerPersonas();
                List<ClsDepartamento> listaDepartamentos = ListadosBL.obtenerDepartamentos();
                ClsPersona persona;
                for (int i = 0; i < listaPersonas.Count; i++)
                {
                    persona = listaPersonas.ElementAt(i);

                    listaClsPersonaSimplificada.Add(new ClsPersonaSimplificadaNombreDepartamento(persona,
                                                    obtenerNombreDepartamento(listaDepartamentos, persona.IdDepartamento)));
                }
                action = View(listaClsPersonaSimplificada);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        //Details

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            IActionResult action;
            try
            {
                ClsPersonaNombreDepartamento clsPersonaDepartamento;
                ClsPersona clsPersona = ListadosBL.obtenerPersona(id);

                clsPersonaDepartamento = new ClsPersonaNombreDepartamento(clsPersona, ListadosBL.obtenerNombreDepartamento(clsPersona.IdDepartamento));
                action = View(clsPersonaDepartamento);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }

            return action;
        }

        //Create//

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            IActionResult action;
           
            try
            {
                ClsPersonaListaDepartamentosVM clsPersonaDepartamentos = new ClsPersonaListaDepartamentosVM();
                clsPersonaDepartamentos.ListaDepartamentos = ListadosBL.obtenerDepartamentos();
                action = View(clsPersonaDepartamentos);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPersonaDepartamento"></param>
        /// <param name="imagen"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ClsPersonaListaDepartamentosVM clsPersonaDepartamento, IFormFile imagen)
        {
            IActionResult action = null;
            try
            {
                if (ModelState.IsValid) {
                    if (imagen != null)
                    {
                        clsPersonaDepartamento.Foto = rellenarArrayByte(imagen);
                    }
                    GestoraPersonasBL.anhadirPersona(clsPersonaDepartamento);
                    action = RedirectToAction("Index");
                }
                else {
                    ClsPersonaListaDepartamentosVM clsPersonaDepartamentos = new ClsPersonaListaDepartamentosVM();
                    clsPersonaDepartamentos.ListaDepartamentos = ListadosBL.obtenerDepartamentos();
                    action = View("Create", clsPersonaDepartamentos);
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        //Edit

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            IActionResult action;
            try
            {
               ClsPersonaListaDepartamentosVM clsPersonaDepartamentos = new ClsPersonaListaDepartamentosVM(ListadosBL.obtenerPersona(id),
                                                                                                           ListadosBL.obtenerDepartamentos());
                action = View(clsPersonaDepartamentos);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPersonaDepartamento"></param>
        /// <param name="imagen"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ClsPersona clsPersona, IFormFile imagen)
        {
            IActionResult action;
            int numActualizaciones;
            try
            {
                if (ModelState.IsValid)
                {
                    if (imagen != null) //Si el usuario a ingresado una imagen
                    {
                        clsPersona.Foto = rellenarArrayByte(imagen);
                    }
                    numActualizaciones = GestoraPersonasBL.editarPersona(clsPersona);
                    action = RedirectToAction("Index");
                }
                else {
                    //Hay que hacerlo con View y no con RedirectToAction("Edit"), por que con RedirectToAction no salen los mensajes de validacion(Ej: Campo obligatorio)
                    action = View("Edit",new ClsPersonaListaDepartamentosVM(clsPersona, ListadosBL.obtenerDepartamentos()));
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        //Delete

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            IActionResult action;
            try
            {
                ClsPersona clsPersona = ListadosBL.obtenerPersona(id);
                ClsPersonaNombreDepartamento clsPersonaConDepartamento;
                clsPersonaConDepartamento = new ClsPersonaNombreDepartamento(clsPersona, ListadosBL.obtenerNombreDepartamento(clsPersona.IdDepartamento));
                action = View(clsPersonaConDepartamento);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }

            return action;
        }

        // POST: ClsPersonaDepartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            IActionResult action;

            try {
                GestoraPersonasBL.eliminarPersona(id);
                action = RedirectToAction("Index");
            }
            catch (Exception) {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundPersonas");
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Metodos Privados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaDepartamentos"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string obtenerNombreDepartamento(List<ClsDepartamento> listaDepartamentos, int id)
        {
            string nombre = "";

            for (int i = 0; i < listaDepartamentos.Count && nombre == ""; i++)
            {
                if (listaDepartamentos.ElementAt(i).ID == id)
                {
                    nombre = listaDepartamentos.ElementAt(i).Nombre;
                }
            }

            return nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private byte[] rellenarArrayByte(IFormFile file)
        {
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
        #endregion
    }
}
