using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using LogicaNegocio.Loging;
using Modelos;
using Modelos.DTO;
using WebAppMvc.ViewModels;

namespace WebAppMvc.Controllers
{
    public class AlumnosController : Controller
    { 
        private FachadaAlumno fachadaAlumnos { get; set; }

        private TecsoLogger tecsoLogger { get; set; }

        public AlumnosController(FachadaAlumno fachadaAlumnos, TecsoLogger tecsoLogger)
        {
            this.fachadaAlumnos = fachadaAlumnos;
            this.tecsoLogger = tecsoLogger;
        }

        // GET: Alumnos
        public ActionResult Index()
        {
            List<Alumno> alumnos = this.fachadaAlumnos.ListarAlumnos();

            List<AlumnoViewModel> alumnosView = new List<AlumnoViewModel>();

            foreach (Alumno item in alumnos)
            {
                alumnosView.Add(new AlumnoViewModel { AlumnoId = item.AlumnoId, Cedula = item.Cedula, NombreAlumno = item.NombreAlumno });
            }

            return View(alumnosView);
        }

        public ActionResult Eliminar(int alumnoId)
        {
            try
            {
                if (alumnoId == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                this.fachadaAlumnos.EliminarAlumno(alumnoId);

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
        public ActionResult NuevoEditar(AlumnoViewModel alumno)
        {
            try
            {
                if (alumno.AlumnoId > 0)
                {
                    ViewBag.Title = "Edit Student";
                    return View(alumno);
                }

                ViewBag.Title = "New Student";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                string mensaje = ConfigurarExcepcion(ex);

                this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

                ViewBag.Error = mensaje;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoEditar([Bind(Include = "AlumnoId,Cedula,NombreAlumno")] Alumno alumno)
        {
            try
            {
                bool datosValidos;

                ModelState.Remove("AlumnoId");

                if (!ModelState.IsValid)
                {
                    return View(new AlumnoViewModel { AlumnoId = alumno.AlumnoId, Cedula = alumno.Cedula, NombreAlumno = alumno.NombreAlumno });
                }

                Alumno alumnoBuscar = this.fachadaAlumnos.BuscarAlumnoCedula(alumno.Cedula);

                if (alumno.AlumnoId > 0)
                {
                    if (alumnoBuscar == null || alumnoBuscar.AlumnoId == alumno.AlumnoId)
                    {
                        this.fachadaAlumnos.ActualizarAlumno(alumno);

                        datosValidos = true;
                    }
                    else
                    {
                        ViewBag.Mensaje = $"Student {alumno.Cedula} already exists";

                        datosValidos = false;
                    }
                }
                else
                {
                    if (alumnoBuscar != null)
                    {
                        ViewBag.Mensaje = $"Student {alumno.Cedula} already exists";

                        datosValidos = false;
                    }
                    else
                    {
                        this.fachadaAlumnos.GuardarAlumno(alumno);

                        datosValidos = true;
                    }
                }

                if (datosValidos)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(new AlumnoViewModel { AlumnoId = alumno.AlumnoId, Cedula = alumno.Cedula, NombreAlumno = alumno.NombreAlumno });
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

        //public ActionResult Buscar(string cc)
        //{
        //    try
        //    {
        //        bool reserva = Convert.ToBoolean(Session["reserva"]);

        //        Alumno alumno;

        //        try
        //        {
        //            alumno = this.fachadaAlumnos.BuscarAlumnoCedula(cc);
        //        }
        //        catch (NullReferenceException)
        //        {
        //            ViewBag.Mensaje = $"El alumno {cc} no existe";
        //            ViewBag.AgregarHidden = true;

        //            return View("NuevoEditar");
        //        }

        //        ViewBag.AgregarHidden = !reserva;
        //        ViewBag.Curso = Session["curso"];

        //        return View("NuevaReserva", new AlumnoViewModel { AlumnoId = alumno.AlumnoId, Cedula = alumno.Cedula, NombreAlumno = alumno.NombreAlumno });
        //    }
        //    catch (Exception ex)
        //    {
        //        string mensaje = ConfigurarExcepcion(ex);

        //        this.tecsoLogger.LogMessage(mensaje, true, true, EnumTipoMensaje.ERROR);

        //        ViewBag.Error = mensaje;

        //        return View("NuevoEditar");
        //    }
        //}

        private static string ConfigurarExcepcion(Exception ex)
        {
            return ex.Message + " \n " + ex.StackTrace;
        }
    }
}