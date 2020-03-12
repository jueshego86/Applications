using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FachadaCurso
    {
        private IAccesoDatosCurso accesoDatosCurso;

        public FachadaCurso(IAccesoDatosCurso accesoDatosCurso)
        {
            this.accesoDatosCurso = accesoDatosCurso;
        }

        public int EliminarCurso(int id)
        {
            return this.accesoDatosCurso.EliminarCurso(id);
        }

        public int GuardarCurso(Curso curso)
        {
            try
            {
                return this.accesoDatosCurso.InsertarCurso(curso);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Curso> ListarCursosTodos()
        { 
            return this.accesoDatosCurso.ListarCursosTodos();  
        }

        public List<Curso> ListarCursosActivos()
        {
            return this.accesoDatosCurso.ListarCursosActivos();
        }

        public Curso BuscarCursoCodigo(string codigo)
        {
            return this.accesoDatosCurso.BuscarCursoCodigo(codigo);
        }

        public int ActualizarCurso(Curso curso)
        {
            try
            {
                return this.accesoDatosCurso.ActualizarCurso(curso);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
