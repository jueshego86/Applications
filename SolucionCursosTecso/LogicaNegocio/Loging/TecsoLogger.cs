using AccesoDatos.Contratos;
using LogicaNegocio.Loging;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class TecsoLogger
    {
        private ITecsoLoggerToDatabase tecsoLoggerToDatabase { get; set; }

        public ITecsoLoggerToFile tecsoLoggerToFile { get; set; }

        public TecsoLogger(ITecsoLoggerToDatabase tecsoLoggerToDatabase, ITecsoLoggerToFile tecsoLoggerToFile)
        {
            this.tecsoLoggerToDatabase = tecsoLoggerToDatabase;

            this.tecsoLoggerToFile = tecsoLoggerToFile;
        }

        /// <summary>
        /// Procesa el mensaje a registrar en log
        /// </summary>
        /// <param name="message">Mensaje para el registro de log</param>
        /// <param name="logToFile">indica si se escribe en archivo</param>
        /// <param name="logToDatabase">indica si se escribe en base de datos</param>
        /// <param name="tipo">tipo de mensaje(1:INFO, 2:ALERTA, 3:ERROR)</param>
        public void LogMessage(string message, bool logToFile, bool logToDatabase, EnumTipoMensaje tipo)
        {           
            message.Trim();

            if (String.IsNullOrEmpty(message))
            {
                return;
            }

            if (!logToFile && !logToDatabase)
            {
                throw new Exception("Código incorrecto");
            }

            if (tipo != EnumTipoMensaje.ALERTA && tipo != EnumTipoMensaje.ERROR && tipo != EnumTipoMensaje.INFO)
            {
                throw new Exception("Especificar tipo de mensaje");
            }

            Log log = new Log
            {
                Mensaje = message,
                Tipo = (int)tipo,
                Fecha = DateTime.Now
            };

            if (logToDatabase)
            {
                this.tecsoLoggerToDatabase.InsertarLogEnBd(log);
            }

            if (logToFile)
            {
                this.tecsoLoggerToFile.EscribirLogEnArchivo(log);
            }

            //if (logToConsole)
            //{
            //    LogConsole(message);
            //}
        }
    }
}
