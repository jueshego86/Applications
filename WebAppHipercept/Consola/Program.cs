using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using DataAccess.Contrats;
using DataAccess.SqlServer;
using System.Data.Entity;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //UnityContainer unityContainer = new UnityContainer();

            //unityContainer.RegisterType<DbContext, ContextSQLServer>();
            //unityContainer.RegisterType<IAccesoDatosAlumno, DAOAlumnoSqlServer>();

            //FachadaAlumno fachadaAlumnos = unityContainer.Resolve<FachadaAlumno>();

            //fachadaAlumnos.GuardarAlumno(new Alumno { Cedula = "1010101", NombreAlumno = "Juan E" });

        }
    }
}
