namespace DataAccess.SqlServer
{
    using DataAccess.Contrats;
    using DataAccess.Migrations;
    using System.Data.Entity;

    public class ContextSQLServer : Context
    {
        public ContextSQLServer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextSQLServer, Configuration>());
        }
    }
}
