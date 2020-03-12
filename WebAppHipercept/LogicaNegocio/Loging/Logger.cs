namespace Facade
{
    using Facade.Loging;
    using Models;
    using System;

    public class Logger
    {
        public ILoggerToFile LoggerToFile { get; set; }

        public Logger(ILoggerToFile loggerToFile)
        {
            this.LoggerToFile = loggerToFile;
        }

        /// <summary>
        /// Procesa el mensaje a registrar en log
        /// </summary>
        /// <param name="message">Mensaje para el registro de log</param>
        /// <param name="logToFile">indica si se escribe en archivo</param>
        /// <param name="type">tipo de mensaje(1:INFO, 2:ALERT, 3:ERROR)</param>
        public void LogMessage(string message, bool logToFile, EnumMessageType type)
        {           
            message.Trim();

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (!logToFile)
            {
                throw new Exception("Invalid Code");
            }

            if (type != EnumMessageType.ALERT && type != EnumMessageType.ERROR && type != EnumMessageType.INFO)
            {
                throw new Exception("Must Especify a MessageType");
            }

            Log log = new Log
            {
                Message = message,
                TYpe = (int)type,
                Date = DateTime.Now
            };

            if (logToFile)
            {
                this.LoggerToFile.LogToFile(log);
            }
        }
    }
}
