namespace Facade.Loging
{
    using Facade.Loging;
    using Models;
    using System;
    using System.Configuration;
    using System.IO;

    public class LoggerToFile : ILoggerToFile
    {
        public void LogToFile(Log log)
        {
            string path = ConfigurationManager.AppSettings["FilePathLog"];

            string file = String.Format("{0}File_Log_{1}.txt", path, DateTime.Now.ToString("yyyy-MM-dd"));

            string fileMessage = $"\n { DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") }  { log.Message}";

            try
            {
                File.AppendAllLines(file, new String[] { fileMessage });
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
