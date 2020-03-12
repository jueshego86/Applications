using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using AccesoDatos.Contratos;
using AccesoDatos.SqlServer;
using LogicaNegocio;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<Contexto, ContextoSQLServer>();
            unityContainer.RegisterType<IAccesoDatosAlumno, DAOAlumnoSqlServer>();

            FachadaAlumno fachadaAlumnos = unityContainer.Resolve<FachadaAlumno>();

            fachadaAlumnos.GuardarAlumno(new Alumno { Cedula = "1010101", NombreAlumno = "Juan E" });

        }
    }
}
