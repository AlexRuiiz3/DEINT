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
        // GET: DepartamentosController
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

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            ActionResult action;
            try
            {
                List<ClsPersonaNombreApellidos> personasDepartamentoSimplificada = new List<ClsPersonaNombreApellidos>();
                List<ClsPersona> personasDeDepartamento =  ListadosBL.obtenerPersonasDeDepartamento(id);
                foreach (ClsPersona persona in personasDeDepartamento) {
                    personasDepartamentoSimplificada.Add(new ClsPersonaNombreApellidos(persona));
                }

                ClsDepartamentoConPersonasSimplificadasVM departamentoVM = new ClsDepartamentoConPersonasSimplificadasVM
                                                                          (ListadosBL.obtenerDepartamento(id), personasDepartamentoSimplificada);
                action = View(departamentoVM);
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
                action = View("ViewNotFoundDepartamentos");
            }
            return action;
        }

        // GET: DepartamentosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentosController/Create
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

        // GET: DepartamentosController/Edit/5
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

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        public ActionResult Edit(ClsDepartamento clsDepartamento)
        {
            ActionResult action;
            try
            {
                if (ModelState.IsValid)
                {
                    GestoraDepartamentoBL.editarDepartamento(clsDepartamento);
                    action = RedirectToAction("Index");
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

        // GET: DepartamentosController/Delete/5
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
                    GestoraDepartamentoBL.eliminarDeparmaento(id);
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
    }
}
