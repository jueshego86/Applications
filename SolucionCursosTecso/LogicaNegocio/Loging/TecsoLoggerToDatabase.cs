using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;

namespace LogicaNegocio.Loging
{
    public class TecsoLoggerToDatabase : ITecsoLoggerToDatabase
    {
        private IAccesoDatosLog accesoDatosLog { get; set; }

        public TecsoLoggerToDatabase(IAccesoDatosLog accesoDatosLog)
        {
            this.accesoDatosLog = accesoDatosLog;
        }

        public void InsertarLogEnBd(Log log)
        {
            this.accesoDatosLog.InsertarMensaje(log);
        }
    }
}
