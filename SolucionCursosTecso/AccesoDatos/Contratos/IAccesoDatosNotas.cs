using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosNotas
    {
        int InsertarNota(NotaCurso notasCurso);

        NotaCurso ObtenerNotaCursoPorReserva(int reservaId);

        string ObtenerCalificacionOEnCurso(int reservaId);

        int ActualizarNota(NotaCurso notasCurso);

        List<NotaCurso> RetornarNotas();
    }
}
