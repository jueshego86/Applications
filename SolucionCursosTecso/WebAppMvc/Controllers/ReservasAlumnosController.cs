using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using LogicaNegocio.Loging;
using Modelos;
using Modelos.DTO;
using PagedList;
using WebAppMvc.ViewModels;

namespace WebAppMvc.Controllers
{
    public class ReservasAlumnosController : Controller
    {
        private FachadaReservaAlumno fachadaReservaAlumno { get; set; }
        private FachadaSillaReserva fachadaSillaReserva { get; set; }
        private FachadaAlumno fachadaAlumno { get; set; }
        private FachadaCurso fachadaCurso { get; set; }
        private TecsoLogger tecsoLogger { get; set; }

        public ReservasAlumnosController(FachadaReservaAlumno fachadaReservaAlumno, FachadaSillaReserva fachadaSillaReserva,
            FachadaAlumno fachadaAlumno, FachadaCurso fachadaCurso, TecsoLogger tecsoLogger)
        {
            this.fachadaReservaAlumno = fachadaReservaAlumno;
            this.fachadaSillaReserva = fachadaSillaReserva;
            this.fachadaAlumno = fachadaAlumno;
            this.fachadaCurso = fachadaCurso;
            this.tecsoLogger = tecsoLogger;
        }

        [HttpGet]
        public ActionResult NuevaReserva(ReservaAlumnoViewModel reservaAlumnoViewModel)
        {
            try
            {
                ViewBag.CursoId = new SelectList(this.fachadaCurso.ListarCursosActivos(), "CursoId", "NombreCurso");

                ViewBag.AlumnosDisplay = "none";

                if (reservaAlumnoViewModel.CursoId > 0)
                {
                    Alumno alumno = this.fachadaAlumno.BuscarAlumnoId(reservaAlumnoViewModel.AlumnoId);

                    reservaAlumnoViewModel.AlumnoNombre = alumno.NombreAlumno;

                    int reservaId = this.fachadaReservaAlumno.BuscarReservaCursoAlumno(reservaAlumnoViewModel.CursoId,
                        reservaAlumnoViewModel.AlumnoId).ReservaAlumnoId;

                    Session["ReservaId"] = reservaId;

                    reservaAlumnoViewModel.Sillas = this.RetornarSillas();

                    reservaAlumnoViewModel.Sillas = this.RetornarDisponibilidad(reservaAlumnoViewModel.CursoId, reservaId,
                        reservaAlumnoViewModel.Sillas);

                    ViewBag.SillasDisplay = "normal";

                    ViewBag.BtnAgregarAlumnoHidden = true;
                }
                else
                {
                    Session["ReservaId"] = null;

                    reservaAlumnoViewModel = new ReservaAlumnoViewModel();

                    reservaAlumnoViewModel.Sillas = this.RetornarSillas();

                    ViewBag.SillasDisplay = "none";

                    ViewBag.BtnAgregarAlumnoHidden = false;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;
            }

            return View(reservaAlumnoViewModel);
        }

        [HttpGet]
        public JsonResult BuscarAlumno(string cedula)
        {
            Alumno alumno = this.fachadaAlumno.BuscarAlumnoCedula(cedula);

            if (alumno == null)
            {
                string mensaje = $"El alumno con cedula {cedula} no existe.";

                throw new Exception(mensaje);
            }

            return Json(alumno, JsonRequestBehavior.AllowGet);
        }

        private List<SillaViewModel> RetornarDisponibilidad(int cursoId, int? reservaId, List<SillaViewModel> listSillas)
        {
            IQueryable<DTOSillaReserva> sillasReservadas = this.fachadaReservaAlumno.BuscarSillasReservadasCurso(cursoId);

            List<SillaViewModel> sillasViewModel = new List<SillaViewModel>();

            foreach (DTOSillaReserva sillaRes in sillasReservadas)
            {
                sillasViewModel.Add(new SillaViewModel { Codigo = sillaRes.dtoSilla.Codigo });

                SillaViewModel silla = listSillas.FirstOrDefault(s => s.Codigo == sillaRes.dtoSilla.Codigo);

                if (silla != null)
                {
                    silla.Estado = "sillaOcupada";

                    if (reservaId != null && sillaRes.dtoReserva.ReservaId == reservaId)
                    {
                        silla.Estado = "sillaSeleccionada";
                    }
                }
            }
      
            return listSillas;
        }

        private List<SillaViewModel> RetornarSillas()
        {
            List<Silla> sillas = this.fachadaSillaReserva.ListarSillas();

            List<SillaViewModel> sillasViewModel = new List<SillaViewModel>();

            foreach(Silla item in sillas)
            {
                sillasViewModel.Add(new SillaViewModel
                {
                    Codigo = item.Codigo,
                    Estado = "sillaDisponible"
                });
            }

            return sillasViewModel;
        }

        public ActionResult VerDisponibilidad(ReservaAlumnoViewModel reservaAlumnoViewModel)
        {
            try
            {
                ReservaAlumno reservaAlumno = this.fachadaReservaAlumno.BuscarReservaCursoAlumno(reservaAlumnoViewModel.CursoId,
                reservaAlumnoViewModel.AlumnoId);

                int? reservaId = null;

                if (reservaAlumno != null)
                {
                    reservaId = reservaAlumno.ReservaAlumnoId;
                    Session["ReservaId"] = reservaId;
                }

                reservaAlumnoViewModel.Sillas = RetornarSillas();

                reservaAlumnoViewModel.Sillas = RetornarDisponibilidad(reservaAlumnoViewModel.CursoId, reservaId, reservaAlumnoViewModel.Sillas);

                ViewBag.CursoId = new SelectList(fachadaCurso.ListarCursosTodos(), "CursoId", "NombreCurso", reservaAlumnoViewModel.CursoId);

                if (reservaAlumnoViewModel.AlumnoId > 0)
                {
                    reservaAlumnoViewModel.AlumnoNombre = this.fachadaAlumno.BuscarAlumnoId(reservaAlumnoViewModel.AlumnoId).NombreAlumno;
                }

                ViewBag.SillasDisplay = "normal";
                ViewBag.AlumnosDisplay = "none";
                ViewBag.BtnAgregarAlumnoHidden = false;

                return View("NuevaReserva", reservaAlumnoViewModel);
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;

                return View("NuevaReserva", reservaAlumnoViewModel);
            } 
        }

        [HttpGet]
        public ActionResult GuardarReserva(int cursoId, int alumnoId, string silla, string seleccion)
        {
            ReservaAlumnoViewModel reservaViewModel = new ReservaAlumnoViewModel();

            try
            {
                reservaViewModel.CursoId = cursoId;
                reservaViewModel.AlumnoId = alumnoId;

                int sillaId = this.fachadaSillaReserva.BuscarSilla(silla);

                if (ModelState.IsValid && cursoId > 0 && alumnoId > 0)
                {
                    if (seleccion == "sillaDisponible")
                    {
                        this.Guardar(reservaViewModel, sillaId);

                        ViewBag.DivSillasDisplay = "normal";

                        ViewBag.Mensaje = "Silla Reservada";

                        ViewBag.BtnAgregarAlumnoHidden = true;
                    }
                    else if (seleccion == "sillaSeleccionada")
                    {
                        this.Borrar(reservaViewModel, sillaId);

                        ViewBag.BtnAgregarAlumnoHidden = false;
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Debe ingresar un cliente y seleccionar una pelicula.";
                }

                int reservaId = Convert.ToInt32(Session["ReservaId"]);

                reservaViewModel.Sillas = RetornarSillas();

                reservaViewModel.AlumnoNombre = this.fachadaAlumno.BuscarAlumnoId(reservaViewModel.AlumnoId).NombreAlumno;

                reservaViewModel.Sillas = this.RetornarDisponibilidad(reservaViewModel.CursoId, reservaId, reservaViewModel.Sillas);

                ViewBag.CursoId = new SelectList(fachadaCurso.ListarCursosTodos(), "CursoId", "NombreCurso", reservaViewModel.CursoId);

                ViewBag.DivSillasDisplay = "normal";
                ViewBag.AlumnosDisplay = "none";
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;
            }

            return View("NuevaReserva", reservaViewModel);
        }

        private void Guardar(ReservaAlumnoViewModel reservaAlumnoViewModel, int sillaId)
        {
            try
            {
                int reservaId = Convert.ToInt32(Session["ReservaId"]);

                if (reservaId > 0)
                {
                    SillaReserva sillaReservaAnt = this.fachadaSillaReserva.RetornarSillaPorReserva(reservaId);

                    if (sillaReservaAnt != null)
                    {
                        this.fachadaSillaReserva.EliminarSillaReserva(sillaReservaAnt.SillaReservaId);
                    }
                }
                else
                {
                    reservaId = this.fachadaReservaAlumno.InsertarReserva(new DTOReservaAlumno
                    {
                        dtoAlumno = new DTOAlumno { AlumnoId = reservaAlumnoViewModel.AlumnoId },
                        dtoCurso = new DTOCurso { CursoId = reservaAlumnoViewModel.CursoId }
                    });

                    Session["ReservaId"] = reservaId;
                }

                this.fachadaSillaReserva.InsertarSillaReserva(new DTOSillaReserva
                {
                    dtoReserva = new DTOReservaAlumno { ReservaId = reservaId },
                    dtoSilla = new DTOSilla { SillaId = sillaId }
                });
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void Borrar(ReservaAlumnoViewModel reservaViewModel, int sillaId)
        {
            try
            {
                int reservaId = Convert.ToInt32(Session["ReservaId"]);

                SillaReserva sillareserva = this.fachadaSillaReserva.BuscarSillaReserva(reservaId, sillaId);

                this.fachadaSillaReserva.EliminarSillaReserva(sillareserva.SillaReservaId);

                this.fachadaReservaAlumno.EliminarReserva(reservaId);

                Session["ReservaId"] = null;

                ViewBag.Mensaje = "Silla Liberada";
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        // GET: ReservasAlumnos
        public ActionResult Index(string ordenamiento, string filtroActual, string filtro, int? pagina)
        {
            ViewBag.OrdenamientoActual = ordenamiento;

            ViewBag.NombreOrdenamiento = String.IsNullOrEmpty(ordenamiento) ? "nombrecurso_desc" : "";

            if (filtro != null)
            {
                pagina = 1;
            }
            else
            {
                filtro = filtroActual;
            }

            ViewBag.FiltroActual = filtro;

            List<DTOReservaAlumno> dTOReservas = this.fachadaReservaAlumno.ListarReservas();

            if (!String.IsNullOrEmpty(filtro))
            {
                dTOReservas = dTOReservas.Where(r => r.dtoCurso.NombreCurso.ToLowerInvariant().Contains(filtro.ToLowerInvariant())).ToList();
            }

            switch (ordenamiento)
            {
                case "nombrecurso_desc":
                    dTOReservas = dTOReservas.OrderByDescending(r => r.dtoCurso.NombreCurso).ToList();
                    break;

                default:
                    dTOReservas = dTOReservas.OrderBy(r => r.dtoCurso.NombreCurso).ToList();
                    break;
            }

            int tamanoPagina = 4;
            int numeroPagina = (pagina ?? 1);

            return View(dTOReservas.ToPagedList(numeroPagina, tamanoPagina));
        }

        private static string ConfigurarExcepcion(Exception ex)
        {
            return ex.Message + " \n " + ex.StackTrace;
        }
    }
}