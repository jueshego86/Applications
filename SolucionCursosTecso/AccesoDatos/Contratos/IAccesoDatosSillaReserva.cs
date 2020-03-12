using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosSillaReserva
    {
        int InsertarSillaReserva(SillaReserva sillaReserva);

        List<SillaReserva> RetornarSillasReserva();

        SillaReserva ObtenerSillaReservaId(int sillaId);

        SillaReserva BuscarSillaDeUnaReserva(int reservaId);

        SillaReserva BuscarSillaReservaPorId(int reservaId, int sillaId);

        int EliminarSillaReserva(int id);

        int ObtenerIdSillaPorCodigo(string codigo);

        List<Silla> ListarSillas();
    }
}
