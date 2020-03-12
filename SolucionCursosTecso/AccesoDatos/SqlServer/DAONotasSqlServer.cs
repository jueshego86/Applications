using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.SqlServer
{
    public class DAONotasSqlServer : IAccesoDatosNotas
    {
        public Contexto contexto { get; set; }

        public DAONotasSqlServer(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public int InsertarNota(NotaCurso notasCurso)
        {
            try
            {
                contexto.NotasCursos.Add(notasCurso);
                return contexto.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public NotaCurso ObtenerNotaCursoPorReserva(int reservaId)
        {
            return contexto.NotasCursos.FirstOrDefault(n => n.ReservaAlumnoId == reservaId);
        }

        public int ActualizarNota(NotaCurso notasCurso)
        {
            try
            {
                NotaCurso notaBuscar = contexto.NotasCursos.Find(notasCurso.NotaCursoId);
                notaBuscar.Calificacion = notasCurso.Calificacion;

                return contexto.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<NotaCurso> RetornarNotas()
        {
            return this.contexto.NotasCursos.Include("Reserva").Include("Alumno").Include("Curso").ToList();
        }

        public string ObtenerCalificacionOEnCurso(int reservaId)
        {
            NotaCurso nota = contexto.NotasCursos.FirstOrDefault(n => n.ReservaAlumnoId == reservaId);

            if(nota != null)
            {
                return nota.Calificacion.ToString();
            }

            return "Matriculado";
        }
    }
}
