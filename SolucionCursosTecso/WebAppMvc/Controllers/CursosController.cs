using LogicaNegocio;
using LogicaNegocio.Loging;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMvc.ViewModels;

namespace WebAppMvc.Controllers
{
    public class CursosController : Controller
    {
        private FachadaCurso fachadaCursos { get; set; }

        private TecsoLogger tecsoLogger { get; set; }

        public CursosController(FachadaCurso fachadaCursos, TecsoLogger tecsoLogger)
        {
            this.fachadaCursos = fachadaCursos;
            this.tecsoLogger = tecsoLogger;
        }

        // GET: Cursos
        public ActionResult Index()
        {
            List<Curso> cursos = this.fachadaCursos.ListarCursosTodos();

            List<CursoViewModel> CursosView = new List<CursoViewModel>();

            foreach (Curso item in cursos)
            {
                CursosView.Add(new CursoViewModel { CursoId = item.CursoId, Codigo = item.Codigo, NombreCurso = item.NombreCurso, Activo = item.Activo });
            }

            return View(CursosView);
        }

        public ActionResult Eliminar(int cursoId)
        {
            try
            {
                if (cursoId == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                this.fachadaCursos.EliminarCurso(cursoId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;

                return View("NuevoEditar");
            } 
        }

        [HttpGet]
        public ActionResult NuevoEditar(CursoViewModel curso)
        {
            LlenarListaActivo();

            if (curso.CursoId > 0)
            {
                ViewBag.Title = "Edit Course";
                return View(curso);
            }

            ViewBag.Title = "New Course";
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoEditar([Bind(Include = "CursoId,Codigo,NombreCurso,Activo")] Curso curso)
        {
            try
            {
                bool datosValidos;

                ModelState.Remove("CursoId");

                if (!ModelState.IsValid)
                {
                    LlenarListaActivo();

                    return View(new CursoViewModel { CursoId = curso.CursoId, Codigo = curso.Codigo, NombreCurso = curso.NombreCurso, Activo = curso.Activo });
                }

                Curso cursoBuscar = this.fachadaCursos.BuscarCursoCodigo(curso.Codigo);

                if (curso.CursoId > 0)
                {
                    if (cursoBuscar == null || cursoBuscar.CursoId == curso.CursoId)
                    {
                        this.fachadaCursos.ActualizarCurso(curso);

                        datosValidos = true;
                    }
                    else
                    {
                        ViewBag.Mensaje = $"Course {curso.Codigo} already exists";

                        datosValidos = false;
                    }
                }
                else
                {
                    if (cursoBuscar != null)
                    {
                        ViewBag.Mensaje = $"Course {curso.Codigo} already exists";

                        datosValidos = false;
                    }
                    else
                    {
                        this.fachadaCursos.GuardarCurso(curso);

                        datosValidos = true;
                    }
                }

                if (datosValidos)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    LlenarListaActivo();

                    return View(new CursoViewModel { CursoId = curso.CursoId, Codigo = curso.Codigo, NombreCurso = curso.NombreCurso, Activo = curso.Activo });
                }
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;

                return View("NuevoEditar");
            }
        }

        private void LlenarListaActivo()
        {
            ViewBag.Activo = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "YES", Value = "1" },
                new SelectListItem { Text = "NO", Value = "0" }
            }, "Value", "Text", "1");
        }

        private static string ConfigurarExcepcion(Exception ex)
        {
            return ex.Message + " \n " + ex.StackTrace;
        }
    }
}