using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace LogicaNegocio.Loging
{
    public class TecsoLoggerToFile : ITecsoLoggerToFile
    {
        public void EscribirLogEnArchivo(Log log)
        {
            string path = ConfigurationManager.AppSettings["FilePathLog"];

            string file = String.Format("{0}Archivo_Log_{1}.txt", path, DateTime.Now.ToString("yyyy-MM-dd"));

            string fileMessage = $"\n { DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") }  { log.Mensaje}";

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
