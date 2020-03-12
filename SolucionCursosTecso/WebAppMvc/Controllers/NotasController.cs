using LogicaNegocio;
using LogicaNegocio.Fachadas;
using LogicaNegocio.Loging;
using Modelos;
using Modelos.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMvc.ViewModels;

namespace WebAppMvc.Controllers
{
    public class NotasController : Controller
    {
        public FachadaNotas fachadaNotas { get; set; }
        private FachadaReservaAlumno fachadaReservaAlumno { get; set; }
        private FachadaAlumno fachadaAlumno { get; set; }
        private FachadaCurso fachadaCurso { get; set; }
        private TecsoLogger tecsoLogger { get; set; }

        public NotasController(FachadaNotas fachadaNotas, FachadaReservaAlumno fachadaReservaAlumno,FachadaAlumno fachadaAlumno, 
            FachadaCurso fachadaCurso, TecsoLogger tecsoLogger)
        {
            this.fachadaNotas = fachadaNotas;
            this.fachadaReservaAlumno = fachadaReservaAlumno;
            this.fachadaAlumno = fachadaAlumno;
            this.fachadaCurso = fachadaCurso;
            this.tecsoLogger = tecsoLogger;
        }

        [HttpGet]
        public ActionResult NuevaNota(NotaViewModel notaViewModel)
        {
            try
            {
                LlenarListaCalificaciones();

                ViewBag.CursoId = new SelectList(this.fachadaCurso.ListarCursosActivos(), "CursoId", "NombreCurso");
                ViewBag.AlumnoId = new SelectList(this.fachadaAlumno.ListarAlumnos(), "AlumnoId", "NombreAlumno");
                ViewBag.BtnGuardarHidden = true;
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;
            }

            return View(notaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevaNota([Bind(Include = "NotaCursoId,ReservaAlumnoId,Calificacion")] NotaCurso nota)
        {
            NotaViewModel notaViewModel = new NotaViewModel();

            try
            {
                ViewBag.BtnGuardarHidden = false;

                LlenarListaCalificaciones();

                DTOReservaAlumno reserva = this.fachadaReservaAlumno.ObtenerReserva(nota.ReservaAlumnoId);

                ViewBag.CursoId = new SelectList(this.fachadaCurso.ListarCursosActivos(), "CursoId", "NombreCurso", reserva.dtoCurso.CursoId);
                ViewBag.AlumnoId = new SelectList(this.fachadaAlumno.ListarAlumnos(), "AlumnoId", "NombreAlumno", reserva.dtoAlumno.AlumnoId);

                ModelState.Remove("NotaCursoId");

                if (ModelState.IsValid)
                {
                    if (nota.NotaCursoId > 0)
                    {
                        this.fachadaNotas.ActualizarNota(nota);
                    }
                    else
                    {
                        this.fachadaNotas.InsertarNota(nota);
                    }
                    
                    ViewBag.BtnGuardarHidden = true;

                    ViewBag.Exito = "Nota Guardada.";

                    return View();
                }

                notaViewModel.ReservaAlumnoId = Convert.ToInt32(reserva.ReservaId);
                notaViewModel.AlumnoId = reserva.dtoAlumno.AlumnoId;
                notaViewModel.CursoId = reserva.dtoCurso.CursoId;
                notaViewModel.Calificacion = nota.Calificacion;
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;
            }

            return View(notaViewModel);
        }

        [HttpGet]
        public ActionResult ValidarReserva(int cursoId, int alumnoId, int nota)
        {
            NotaViewModel notaViewModel = new NotaViewModel();

            try
            {
                LlenarListaCalificaciones();

                ViewBag.CursoId = new SelectList(this.fachadaCurso.ListarCursosActivos(), "CursoId", "NombreCurso");
                ViewBag.AlumnoId = new SelectList(this.fachadaAlumno.ListarAlumnos(), "AlumnoId", "NombreAlumno");

                notaViewModel.CursoId = cursoId;
                notaViewModel.AlumnoId = alumnoId;
                notaViewModel.Calificacion = nota;

                ReservaAlumno reserva = this.fachadaReservaAlumno.BuscarReservaCursoAlumno(cursoId, alumnoId);

                if (reserva != null)
                {
                    notaViewModel.ReservaAlumnoId = reserva.ReservaAlumnoId;

                    NotaCurso notaCurso = this.fachadaNotas.ObtenerNotaCursoPorReserva(reserva.ReservaAlumnoId);

                    if(notaCurso != null)
                    {
                        notaViewModel.NotaCursoId = notaCurso.NotaCursoId;
                        notaViewModel.Calificacion = notaCurso.Calificacion;

                        ViewBag.Info = "Ya existe una Nota registrada para este Alumno en este Curso";
                    }

                    ViewBag.BtnGuardarHidden = false;
                }
                else
                {
                    ViewBag.BtnGuardarHidden = true;

                    ViewBag.Error = "El alumno no esta matriculado en este curso.";
                }
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;
            }

            return View("NuevaNota", notaViewModel);
        }

        // GET: Notas
        public ActionResult Index(string ordenamiento, string filtroActual, string filtro, int? pagina)
        {
            ViewBag.OrdenamientoActual = ordenamiento;

            ViewBag.NombreOrdenamiento = String.IsNullOrEmpty(ordenamiento) ? "nombrealumno_desc" : "";

            if (filtro != null)
            {
                pagina = 1;
            }
            else
            {
                filtro = filtroActual;
            }

            ViewBag.FiltroActual = filtro;

            List<DTONotas> dTONotas = this.fachadaNotas.ListarNotas();

            if (!String.IsNullOrEmpty(filtro))
            {
                dTONotas = dTONotas.Where(r => r.dtoAlumno.NombreAlumno.ToLowerInvariant().Contains(filtro.ToLowerInvariant())).ToList();
            }

            switch (ordenamiento)
            {
                case "nombrealumno_desc":
                    dTONotas = dTONotas.OrderByDescending(r => r.dtoAlumno.NombreAlumno).ToList();
                    break;

                default:
                    dTONotas = dTONotas.OrderBy(r => r.dtoAlumno.NombreAlumno).ToList();
                    break;
            }

            int tamanoPagina = 4;
            int numeroPagina = (pagina ?? 1);

            return View(dTONotas.ToPagedList(numeroPagina, tamanoPagina));
        }

        private void LlenarListaCalificaciones()
        {
            ViewBag.Calificacion = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "1", Value = "1" },
                new SelectListItem { Text = "2", Value = "2" },
                new SelectListItem { Text = "3", Value = "3" },
                new SelectListItem { Text = "4", Value = "4" },
                new SelectListItem { Text = "5", Value = "5" },
            }, "Value", "Text");
        }

        private static string ConfigurarExcepcion(Exception ex)
        {
            return ex.Message + " \n " + ex.StackTrace;
        }
    }
}