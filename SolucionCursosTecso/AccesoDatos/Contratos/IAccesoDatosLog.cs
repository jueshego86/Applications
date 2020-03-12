using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosLog
    {
        int InsertarMensaje(Log log);
    }
}
