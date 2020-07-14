using _2_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4_DataAcces.Contrats
{
    public interface IAccesoDatosSillaReserva
    {
        int InsertarSillaReserva(SillaReserva sillaReserva);

        List<SillaReserva> RetornarSillasReserva();

        SillaReserva BuscarSillaReserva(int id);

        SillaReserva BuscarSillaReserva(int reservaId, int sillaId);

        List<SillaReserva> RetornarSillasPorReserva(int reservaId);

        //int ActualizarSillaReserva(SillaReserva sillaReserva);

        int EliminarSillaReserva(int id);

        int BuscarSilla(string codigo);
    }
}
