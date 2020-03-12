using AccesoDatos.Contratos;
using AccesoDatos.SqlServer;
using LogicaNegocio.Loging;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace WebAppMvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<Contexto, ContextoSQLServer>();
            container.RegisterType<IAccesoDatosSillaReserva, DAOSqlServerSillaReserva>();
            container.RegisterType<IAccesoDatosAlumno, DAOAlumnoSqlServer>();
            container.RegisterType<IAccesoDatosCurso, DAOCursoSqlServer>();
            container.RegisterType<IAccesoDatosReservaAlumno, DAOReservaAlumnoSqlServer>();
            container.RegisterType<IAccesoDatosLog, DAOLogSqlServer>();
            container.RegisterType<IAccesoDatosNotas, DAONotasSqlServer>();
            container.RegisterType<ITecsoLoggerToDatabase, TecsoLoggerToDatabase>();
            container.RegisterType<ITecsoLoggerToFile, TecsoLoggerToFile>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}