using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.SqlServer
{
    public class DAOLogSqlServer : IAccesoDatosLog
    {
        private Contexto contexto;

        public DAOLogSqlServer(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public int InsertarMensaje(Log log)
        {
            this.contexto.Logs.Add(log);
            return this.contexto.SaveChanges();
        }
    }
}
