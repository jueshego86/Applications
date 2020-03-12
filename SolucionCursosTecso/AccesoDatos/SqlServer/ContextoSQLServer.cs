using AccesoDatos.Contratos;
using AccesoDatos.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.SqlServer
{
    public class ContextoSQLServer : Contexto
    {
        public ContextoSQLServer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextoSQLServer, Configuration>());
        }
    }
}
