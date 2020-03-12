using AccesoDatos.Contratos;
using Modelos;
using Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Fachadas
{
    public class FachadaNotas
    {
        private IAccesoDatosNotas accesoDatosNotas { get; set; }

        private IAccesoDatosReservaAlumno accesoDatosReservaAlumno { get; set; }

        public FachadaNotas(IAccesoDatosNotas accesoDatosNotas, IAccesoDatosReservaAlumno accesoDatosReservaAlumno)
        {
            this.accesoDatosNotas = accesoDatosNotas;
            this.accesoDatosReservaAlumno = accesoDatosReservaAlumno;
        }

        public int InsertarNota(NotaCurso notaCurso)
        {
            try
            {
                return accesoDatosNotas.InsertarNota(notaCurso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NotaCurso ObtenerNotaCursoPorReserva(int reservaId)
        {
            return accesoDatosNotas.ObtenerNotaCursoPorReserva(reservaId);
        }

        public int ActualizarNota(NotaCurso notasCurso)
        {
            try
            {
                return accesoDatosNotas.ActualizarNota(notasCurso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DTONotas> ListarNotas()
        {
            List<ReservaAlumno> reservas = this.accesoDatosReservaAlumno.RetornarReservas();
            List<DTONotas> dtoNotas = new List<DTONotas>();

            foreach (var item in reservas)
            {
                dtoNotas.Add(new DTONotas
                {
                    ReservaAlumnoId = item.ReservaAlumnoId,
                    Calificacion = this.accesoDatosNotas.ObtenerCalificacionOEnCurso(item.ReservaAlumnoId),
                    dtoAlumno = new DTOAlumno
                    {
                        AlumnoId = item.AlumnoId,
                        Cedula = item.Alumno.Cedula,
                        NombreAlumno = item.Alumno.NombreAlumno
                    },
                    dtoCurso = new DTOCurso
                    {
                        CursoId = item.CursoId,
                        Codigo = item.Curso.Codigo,
                        NombreCurso = item.Curso.NombreCurso,
                        Activo = item.Curso.Activo
                    }
                });
            }

            return dtoNotas;
        }
    }
}
