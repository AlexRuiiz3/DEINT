using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Personas_UI_ASP.Data;
using CRUD_Personas_UI_ASP.Models;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_UI_ASP.Controllers
{
    public class ClsPersonaDepartamentosController : Controller
    {
        private readonly CRUD_Personas_UI_ASPContext _context;

        public ClsPersonaDepartamentosController(CRUD_Personas_UI_ASPContext context)
        {
            _context = context;
        }

        // GET: ClsPersonaDepartamentoes--ClsPersonaDepartamentos/Index
        public IActionResult Index()
        {
            List<ClsPersonaSimplificada> listaClsPersonaSimplificada = new List<ClsPersonaSimplificada>();
            try
            {
                List<ClsPersona> listaPersonas = new List<ClsPersona>(ListadosBL.obtenerPersonas());
                ClsPersona persona;
                for (int i = 0; i < listaPersonas.Count; i++)
                {
                    persona = listaPersonas.ElementAt(i);
                    listaClsPersonaSimplificada.Add(new ClsPersonaSimplificada(persona,
                                                  ListadosBL.obtenerNombreDepartamento(persona.IdDepartamento)));
                }
            }
            catch (Exception)
            {
                return View("ViewNotFound");
            }

            return View(listaClsPersonaSimplificada);
        }

        // GET: ClsPersonaDepartamentoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }

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

        // POST: ClsPersonaDepartamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombreDepartamento,ID,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] ClsPersonaDepartamentos clsPersonaDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsPersonaDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsPersonaDepartamento);
        }

        // GET: ClsPersonaDepartamentoes/Edit/5
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

        // POST: ClsPersonaDepartamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,ClsPersonaDepartamentos clsPersonaDepartamento)
        {
            clsPersonaDepartamento.ListaDepartamentos = ListadosBL.obtenerDepartamentos();
            if (id != clsPersonaDepartamento.ID)
            {
                return NotFound();
            }

            return View(clsPersonaDepartamento);
        }

        // GET: ClsPersonaDepartamentoes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }

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

        // POST: ClsPersonaDepartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        private bool ClsPersonaDepartamentoExists(int id)
        {
            return _context.ClsPersonaDepartamento.Any(e => e.ID == id);
        }
    }
}
