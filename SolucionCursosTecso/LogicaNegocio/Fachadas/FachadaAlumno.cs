using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;

namespace LogicaNegocio
{
    public class FachadaAlumno
    {
        private IAccesoDatosAlumno accesoDatosAlumno;

        public FachadaAlumno(IAccesoDatosAlumno accesoDatosAlumno)
        {
            this.accesoDatosAlumno = accesoDatosAlumno;
        }

        public int EliminarAlumno(int id)
        {
            return this.accesoDatosAlumno.EliminarAlumno(id);
        }

        public int GuardarAlumno(Alumno alumno)
        {
            try
            {
                return this.accesoDatosAlumno.InsertarAlumno(alumno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Alumno> ListarAlumnos()
        {
            try
            {
                return this.accesoDatosAlumno.ListarAlumnos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ActualizarAlumno(Alumno alumno)
        {
            try
            {
                return this.accesoDatosAlumno.ActualizarAlumno(alumno);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Alumno BuscarAlumnoCedula(string cedula)
        {
            return this.accesoDatosAlumno.BuscarAlumnoCc(cedula);
        }

        public Alumno BuscarAlumnoId(int alumnoId)
        {
            return this.accesoDatosAlumno.BuscarAlumnoId(alumnoId);
        }
    }
}
