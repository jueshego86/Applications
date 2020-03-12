using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;
using Modelos.DTO;

namespace AccesoDatos.SqlServer
{
    public class DAOReservaAlumnoSqlServer : IAccesoDatosReservaAlumno
    {
        private Contexto contexto;

        public DAOReservaAlumnoSqlServer(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public ReservaAlumno BuscarReserva(int? id)
        {
            return this.contexto.ReservasAlumnos.Find(id);
        }

        public ReservaAlumno BuscarReservaCursoAlumno(int cursoId, int alumnoId)
        {
            return this.contexto.ReservasAlumnos.FirstOrDefault(r => r.CursoId == cursoId && r.AlumnoId == alumnoId);
        }

        public IQueryable<ReservaAlumno> BuscarReservaCursoAlumnoSilla(int cursoId, int alumnoId, int sillaId)
        {
            var reservas = (from res in this.contexto.ReservasAlumnos
                            join sr in this.contexto.SillasReserva on res.ReservaAlumnoId equals sr.ReservaAlumnoId
                            join sillas in this.contexto.Sillas on sr.SillaId equals sillas.SillaId
                            where res.CursoId == cursoId && res.AlumnoId == alumnoId && sr.SillaId == sillaId
                            select new ReservaAlumno
                            {
                                ReservaAlumnoId = res.ReservaAlumnoId
                            });

            return reservas;
        }

        public IQueryable<DTOSillaReserva> BuscarSillasReservadasCurso(int cursoId)
        {

            var sillaReserva = (from res in this.contexto.ReservasAlumnos
                                join sr in this.contexto.SillasReserva on res.ReservaAlumnoId equals sr.ReservaAlumnoId
                                join sillas in this.contexto.Sillas on sr.SillaId equals sillas.SillaId
                                where res.CursoId == cursoId
                                select new DTOSillaReserva
                                {
                                    dtoReserva = new DTOReservaAlumno { ReservaId = res.ReservaAlumnoId },
                                    dtoSilla = new DTOSilla { Codigo = sillas.Codigo }
                                });

            return sillaReserva;
        }

        public int EliminarReserva(int id)
        {
            this.contexto.ReservasAlumnos.Remove(this.BuscarReserva(id));
            return this.contexto.SaveChanges();
        }

        public int InsertarReserva(ReservaAlumno reserva)
        {
            try
            {
                this.contexto.ReservasAlumnos.Add(reserva);
                this.contexto.SaveChanges();
                return reserva.ReservaAlumnoId;
            }
            catch (SqlException)
            {
                throw;
            } 
        }

        public List<ReservaAlumno> RetornarReservas()
        {
            return this.contexto.ReservasAlumnos.Include("Alumno").Include("Curso").ToList();
        }
    }
}
