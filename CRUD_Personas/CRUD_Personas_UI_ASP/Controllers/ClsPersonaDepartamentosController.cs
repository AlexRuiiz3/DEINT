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
            List<ClsPersonaDepartamento> listaPersonaDepartamentos = new List<ClsPersonaDepartamento>();
            try
            {
                List<ClsPersona> listaPersonas = new List<ClsPersona>(ListadosBL.obtenerPersonas());
                ClsPersona persona;
                for (int i = 0; i < listaPersonas.Count; i++)
                {
                    persona = listaPersonas.ElementAt(i);
                    listaPersonaDepartamentos.Add(new ClsPersonaDepartamento(persona,
                                                  ListadosBL.obtenerNombreDepartamento(persona.IdDepartamento)));
                }
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(listaPersonaDepartamentos);
        }

        // GET: ClsPersonaDepartamentoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClsPersonaDepartamento clsPersonaDepartamento = null;
            try
            {
                var clsPersonas = (from persona in ListadosBL.obtenerPersonas()
                                   where persona.ID == id
                                   select persona);

                clsPersonaDepartamento = new ClsPersonaDepartamento(clsPersonas.ElementAt(0), 
                    ListadosBL.obtenerNombreDepartamento(clsPersonas.ElementAt(0).IdDepartamento));
            }
            catch (Exception)
            {
            }
            if (clsPersonaDepartamento == null)
            {
                return View("ViewNotFound");
            }

            return View(clsPersonaDepartamento);
        }

        // GET: ClsPersonaDepartamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClsPersonaDepartamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombreDepartamento,ID,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] ClsPersonaDepartamento clsPersonaDepartamento)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersonaDepartamento = await _context.ClsPersonaDepartamento.FindAsync(id);
            if (clsPersonaDepartamento == null)
            {
                return NotFound();
            }
            return View(clsPersonaDepartamento);
        }

        // POST: ClsPersonaDepartamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NombreDepartamento,ID,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNacimiento,IdDepartamento")] ClsPersonaDepartamento clsPersonaDepartamento)
        {
            if (id != clsPersonaDepartamento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsPersonaDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClsPersonaDepartamentoExists(clsPersonaDepartamento.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clsPersonaDepartamento);
        }

        // GET: ClsPersonaDepartamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersonaDepartamento = await _context.ClsPersonaDepartamento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clsPersonaDepartamento == null)
            {
                return NotFound();
            }

            return View(clsPersonaDepartamento);
        }

        // POST: ClsPersonaDepartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsPersonaDepartamento = await _context.ClsPersonaDepartamento.FindAsync(id);
            _context.ClsPersonaDepartamento.Remove(clsPersonaDepartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClsPersonaDepartamentoExists(int id)
        {
            return _context.ClsPersonaDepartamento.Any(e => e.ID == id);
        }
    }
}
