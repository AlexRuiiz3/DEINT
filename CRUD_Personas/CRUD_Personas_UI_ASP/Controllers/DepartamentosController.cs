using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_Entidades;

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
                action = View("ViewNotFound");
            }

            return action;
        }

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            ActionResult action;
            try
            {
                GestoraDepartamentoBL.anhadirDepartamento(clsDepartamento);
                action = RedirectToAction("Index");
            }
            catch
            {
                action = View("ViewNotFound");
            }
            return action;
        }

        // GET: DepartamentosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        public ActionResult Edit(ClsDepartamento clsDepartamento)
        {
            ActionResult action;
            try
            {
                GestoraDepartamentoBL.editarDepartamento(clsDepartamento);
                action = RedirectToAction("Index");
            }
            catch
            {
                action = View("ViewNotFound");
            }
            return action;
        }

        // GET: DepartamentosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            ActionResult action;
            try
            {
                if ()
                {



                }
                GestoraDepartamentoBL.eliminarDeparmaento(id);
                action = RedirectToAction("Index");
            }
            catch
            {
                action = View("ViewNotFound");
            }
            return action;
        }
    }
}
