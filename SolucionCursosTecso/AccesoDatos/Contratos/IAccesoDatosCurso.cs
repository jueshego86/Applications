using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosCurso
    {
        int InsertarCurso(Curso curso);

        List<Curso> ListarCursosTodos();

        List<Curso> ListarCursosActivos();

        Curso BuscarCursoId(int id);

        Curso BuscarCursoCodigo(string codigo);

        int ActualizarCurso(Curso curso);

        int EliminarCurso(int id);
    }
}
