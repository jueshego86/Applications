using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;

namespace AccesoDatos.SqlServer
{
    public class DAOAlumnoSqlServer : IAccesoDatosAlumno
    {
        private Contexto contexto;

        public DAOAlumnoSqlServer(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public int ActualizarAlumno(Alumno alumno)
        {
            try
            {
                Alumno alumnoEditar = BuscarAlumnoId(alumno.AlumnoId);
                alumnoEditar.Cedula = alumno.Cedula;
                alumnoEditar.NombreAlumno = alumno.NombreAlumno;

                return this.contexto.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            
        }

        public Alumno BuscarAlumnoCc(string cedula)
        {
            return this.contexto.Alumnos.FirstOrDefault(a => a.Cedula == cedula);
        }

        public Alumno BuscarAlumnoId(int alumnoId)
        {
            return this.contexto.Alumnos.Find(alumnoId);
        }

        public int EliminarAlumno(int alumnoId)
        {
            try
            {
                this.contexto.Alumnos.Remove(this.BuscarAlumnoId(alumnoId));
                return this.contexto.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            } 
        }

        public int InsertarAlumno(Alumno alumno)
        {
            try
            {
                this.contexto.Alumnos.Add(alumno);
                this.contexto.SaveChanges();
                return alumno.AlumnoId;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<Alumno> ListarAlumnos()
        {
            try
            {
                List<Alumno> listAlumnos = this.contexto.Alumnos.ToList();

                return listAlumnos;
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
