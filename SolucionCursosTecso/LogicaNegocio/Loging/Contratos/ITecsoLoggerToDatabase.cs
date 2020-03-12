using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Loging
{
    public interface ITecsoLoggerToDatabase
    {
        void InsertarLogEnBd(Log log);
    }
}
