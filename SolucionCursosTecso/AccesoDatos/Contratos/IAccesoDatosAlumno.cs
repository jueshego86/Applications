using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosAlumno
    {
        int InsertarAlumno(Alumno alumno);

        List<Alumno> ListarAlumnos();

        Alumno BuscarAlumnoId(int id);

        Alumno BuscarAlumnoCc(string cc);

        int ActualizarAlumno(Alumno alumno);

        int EliminarAlumno(int id);
    }
}
