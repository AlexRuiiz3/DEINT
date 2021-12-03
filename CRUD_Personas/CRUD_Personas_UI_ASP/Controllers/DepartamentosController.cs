using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_BL.Utilidades;
using CRUD_Personas_UI_ASP.Models.ViewModels;
using CRUD_Personas_Entidades;
using CRUD_Personas_UI_ASP.Models;

namespace CRUD_Personas_UI_ASP.Controllers
{
    public class DepartamentosController : Controller
    {
        #region Actions
        //Index

        /// <summary>
        ///  Action Index que prepara una lista de departamentos. Si se produce cualquier tipo de error se prepara una view de error
        /// </summary>
        /// <returns>ActionResult action</returns>
        public ActionResult Index()
        {
            ActionResult action;
            
            try {
                action = View(ListadosBL.obtenerDepartamentos());
            }
            catch (Exception) {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return action;
        }

        //Details

        /// <summary>
        ///  Action Details que prepara un departamento con una lista de personas con nombre y apellidos. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult action</returns>
        public ActionResult Details(int id)
        {
            ActionResult action;
            try
            {
                List<ClsPersonaNombreApellidos> personasConNombreApellidos = new List<ClsPersonaNombreApellidos>();
                List<ClsPersona> personasDeDepartamento =  ListadosBL.obtenerPersonasDeDepartamento(id);

                foreach (ClsPersona persona in personasDeDepartamento) {
                    personasConNombreApellidos.Add(new ClsPersonaNombreApellidos(persona));
                }

                ClsDepartamentoConPersonasSimplificadasVM departamentoVM = new ClsDepartamentoConPersonasSimplificadasVM
                                                                          (ListadosBL.obtenerDepartamento(id), personasConNombreApellidos);
                action = View(departamentoVM);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return action;
        }

        //Create//

        /// <summary>
        /// Action Create que devuelve un ActionResult a una view Create. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Action HttpPost Create que prepara las cosas necesarias para una funcion que añadira una departamento a la BBDD. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="clsDepartamento"></param>
        /// <returns>ActionResult action</returns>
        [HttpPost]
        public ActionResult Create(ClsDepartamento clsDepartamento)
        {
            ActionResult action = View();
            try
            {
                if (ModelState.IsValid) {
                    GestoraDepartamentoBL.anhadirDepartamento(clsDepartamento);
                    action = RedirectToAction("Index");
                }
            }
            catch(Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");

            }
            return action;
        }

        /// <summary>
        /// Action Edit que prepara un departamento concreto. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult action</returns>
        public ActionResult Edit(int id)
        {
            ActionResult action;
            try
            {
                ClsDepartamento departamento = ListadosBL.obtenerDepartamento(id);
                action = View(departamento);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return action;
        }

        /// <summary>
        ///  Action HttpPost Edit que prepara las cosas necesarias para una funcion que actualizara un departamento a la BBDD. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="clsDepartamento"></param>
        /// <returns>ActionResult action</returns>
        [HttpPost]
        public ActionResult Edit(ClsDepartamento clsDepartamento)
        {
            ActionResult action;
            try
            {
                if (ModelState.IsValid)
                {
                    int numActualizaciones = GestoraDepartamentoBL.editarDepartamento(clsDepartamento);
                    ViewBag.NumCambios = numActualizaciones;
                    action = View("ViewExitoDepartamentos");
                }
                else {
                    ClsDepartamento departamento = ListadosBL.obtenerDepartamento(clsDepartamento.ID);
                    action = View(departamento);
                }
            }
            catch(Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return action;
        }

        /// <summary>
        /// Action Delete que prepara un departamento en concreto. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult action</returns>
        public ActionResult Delete(int id)
        {
            ActionResult action;
            try {
                ClsDepartamento departamento = ListadosBL.obtenerDepartamento(id);
                action = View(departamento); 
            }
            catch (Exception) {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return View();
        }

        /// <summary>
        /// Action HttpPost DeletePost que prepara las cosas necesarias para una funcion que eliminara un departamento a la BBDD. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult action</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            ActionResult action;
            try
            {
                if (UtilidadesBL.comprobarDepartamentoTienePersonas(id)) //Si el departamento tiene asociadas personas
                {
                    ViewBag.Mensaje = "El departamento contiene personas, no se pudo eliminar.";
                    action = View("ViewNotFoundDepartamentos");
                }
                else {
                    int numEliminaciones = GestoraDepartamentoBL.eliminarDeparmaento(id);
                    ViewBag.NumCambios = numEliminaciones;
                    action = View("ViewExitoDepartamentos");
                }
            }
            catch(Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return action;
        }
        #endregion
    }
}
