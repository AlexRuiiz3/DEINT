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

        private readonly string mensajeError = "Algo ocurrio al acceder a la base de datos o algun error extraño ocurrio.";
        #region Actions
        //Index

        /// <summary>
        ///  Action Index que prepara una lista de personas simplificadas(Nombre, Apellidos) con nombre de departamento. Si se produce cualquier tipo de error se prepara una view de error
        /// </summary>
        /// <returns>IActionResult action</returns>
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
                ViewBag.Mensaje = mensajeError;
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        //Details

        /// <summary>
        ///  Action Details que prepara una persona con nombre de departamento. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult action</returns>
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
                ViewBag.Mensaje = mensajeError;
                action = View("ViewNotFoundPersonas");
            }

            return action;
        }

        //Create//

        /// <summary>
        /// Action Create que prepara una persona con lista de departamentos. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <returns>IActionResult action</returns>
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
                ViewBag.Mensaje = mensajeError;
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        /// <summary>
        /// Action HttpPost Create que prepara las cosas necesarias para una funcion que añadira una persona a la BBDD. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="clsPersonaDepartamento"></param>
        /// <param name="imagen"></param>
        /// <returns>IActionResult action</returns>
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
                ViewBag.Mensaje = "Algo ocurrio al intentar guardar la persona nueva en la base de datos.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        //Edit

        /// <summary>
        /// Action Edit que prepara una persona con lista de departamentos. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult action</returns>
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
                ViewBag.Mensaje = mensajeError;
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        /// <summary>
        /// Action HttpPost Edit que prepara las cosas necesarias para una funcion que actualizara una persona a la BBDD. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="clsPersonaDepartamento"></param>
        /// <param name="imagen"></param>
        /// <returns>IActionResult action</returns>
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
                    ViewBag.NumCambios = numActualizaciones;
                    action = View("ViewExitoPersonas");
                }
                else {
                    //Hay que hacerlo con View y no con RedirectToAction("Edit"), por que con RedirectToAction no salen los mensajes de validacion(Ej: Campo obligatorio)
                    action = View("Edit",new ClsPersonaListaDepartamentosVM(clsPersona, ListadosBL.obtenerDepartamentos()));
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Algo ocurrio al intentar actualizar la persona en la base de datos.";
                action = View("ViewNotFoundPersonas");
            }
            return action;
        }

        //Delete

        /// <summary>
        /// Action Delete que prepara una persona con nombre de departamento. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult action</returns>
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
                ViewBag.Mensaje = mensajeError;
                action = View("ViewNotFoundPersonas");
            }

            return action;
        }

        /// <summary>
        /// Action HttpPost DeletePost que prepara las cosas necesarias para una funcion que eliminara una persona a la BBDD. Si se produce cualquier tipo de error se prepara una view de error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult action</returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            IActionResult action;
            try {
                int numEliminaciones = GestoraPersonasBL.eliminarPersona(id);
                ViewBag.NumCambios = numEliminaciones;
                action = View("ViewExitoPersonas");
            }
            catch (Exception) {
                ViewBag.Mensaje = "Algo ocurrio al intentar eliminar la persona en la base de datos.";
                action = View("ViewNotFoundPersonas");
            }

            return action;
        }
        #endregion


        #region Metodos Privados
        /// <summary>
        /// Cabecera: private string obtenerNombreDepartamento(List<ClsDepartamento> listaDepartamentos, int id)
        /// Comentario: Este metodo se obtener el nombre de un departamento de una lista de departamentos a partir del id recibido
        /// Entradas: List<ClsDepartamento> listaDepartamentos, int id
        /// Salidas: string nombre
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se el nombre de un departamento si coincide su id con el id recibido, si no se encuentra un departamento 
        ///                  que conincida con el id recibido, el valor de la cadena devuelta sera "" vacio.
        /// </summary>
        /// <param name="listaDepartamentos"></param>
        /// <param name="id"></param>
        /// <returns>string nombre</returns>
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
        /// Cabecera: private byte[] rellenarArrayByte(IFormFile file)
        /// Comentario: Este metodo se encarga rellenar un array de byte a partir de un IFormFile
        /// Entradas: IFormFile file
        /// Salidas: byte[] arrayByte
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra un array de byte a partir del IFormFile recibido, si el objeto IFormFile tiene una longitud menor o igual que 0, 
        ///                  el valor devuelto del array de byte tendra una longitud de 0, estara vacio.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>byte[] arrayByte</returns>
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
