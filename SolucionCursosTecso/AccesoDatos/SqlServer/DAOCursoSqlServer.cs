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
    public class DAOCursoSqlServer : IAccesoDatosCurso
    {
        private Contexto contexto;

        public DAOCursoSqlServer(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public int ActualizarCurso(Curso curso)
        {
            try
            {
                Curso cursoEditar = BuscarCursoId(curso.CursoId);
                cursoEditar.Codigo = curso.Codigo;
                cursoEditar.NombreCurso = curso.NombreCurso;
                cursoEditar.Activo = curso.Activo;

                return this.contexto.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Curso BuscarCursoCodigo(string codigo)
        {
            return this.contexto.Cursos.FirstOrDefault(c => c.Codigo == codigo);
        }

        public Curso BuscarCursoId(int id)
        {
            return this.contexto.Cursos.Find(id);
        }

        public int EliminarCurso(int id)
        {
            try
            {
                this.contexto.Cursos.Remove(this.BuscarCursoId(id));
                return this.contexto.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            
        }

        public int InsertarCurso(Curso curso)
        {
            try
            {
                this.contexto.Cursos.Add(curso);
                this.contexto.SaveChanges();
                return curso.CursoId;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<Curso> ListarCursosTodos()
        {
            List<Curso> listCursos = this.contexto.Cursos.ToList();

            return listCursos;
        }

        public List<Curso> ListarCursosActivos()
        {
            List<Curso> listCursos = this.contexto.Cursos.Where(c => c.Activo == 1).ToList();

            return listCursos;
        }
    }
}
