using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;
using Modelos.DTO;

namespace LogicaNegocio
{
    public class FachadaReservaAlumno
    {
        private IAccesoDatosReservaAlumno accesoDatosReserva;

        public FachadaReservaAlumno(IAccesoDatosReservaAlumno accesoDatosReserva)
        {
            this.accesoDatosReserva = accesoDatosReserva;
        }

        public int InsertarReserva(DTOReservaAlumno reserva)
        {
            try
            {
                return this.accesoDatosReserva.InsertarReserva(new ReservaAlumno { CursoId = reserva.dtoCurso.CursoId, AlumnoId = reserva.dtoAlumno.AlumnoId });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DTOReservaAlumno ObtenerReserva(int? id)
        {
            ReservaAlumno reserva = this.accesoDatosReserva.BuscarReserva(id);

            DTOReservaAlumno dtoReserva = new DTOReservaAlumno
            {
                ReservaId = id,
                dtoAlumno = new DTOAlumno { AlumnoId = reserva.AlumnoId },
                dtoCurso = new DTOCurso { CursoId = reserva.CursoId }
            };

            return dtoReserva;
        }

        public List<DTOReservaAlumno> ListarReservas()
        {
            List<ReservaAlumno> Reservas = this.accesoDatosReserva.RetornarReservas();
            List<DTOReservaAlumno> dtoReservas = new List<DTOReservaAlumno>();

            foreach (var item in Reservas)
            {
                dtoReservas.Add(new DTOReservaAlumno
                {
                    ReservaId = item.ReservaAlumnoId,
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

            return dtoReservas;
        }

        public bool EliminarReserva(int id)
        {
            return this.accesoDatosReserva.EliminarReserva(id) == 1;
        }

        public ReservaAlumno BuscarReservaCursoAlumno(int cursoId, int alumnoId)
        {
            return this.accesoDatosReserva.BuscarReservaCursoAlumno(cursoId, alumnoId);
        }

        public IQueryable<DTOSillaReserva> BuscarSillasReservadasCurso(int cursoId)
        {
            return this.accesoDatosReserva.BuscarSillasReservadasCurso(cursoId);
        }

        public IQueryable<ReservaAlumno> BuscarReservaCursoAlumnoSilla(int cursoId, int alumnoId, int sillaId)
        {
            return this.accesoDatosReserva.BuscarReservaCursoAlumnoSilla(cursoId, alumnoId, sillaId);
        }
    }
}
