using _2_Models;
using _2_Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_DataAcces.Contrats
{
    public interface IAccesoDatosReserva
    {
        int InsertarReserva(Reserva reserva);

        List<Reserva> RetornarReservas();

        Reserva BuscarReserva(int? id);

        //int ActualizarReserva(Reserva reserva);

        Reserva BuscarReservaPeliculaCliente(int peliculaId, int clienteId);

        IQueryable<DTOSillaReserva> BuscarSillasReservadas(int peliculaId);

        IQueryable<Reserva> BuscarReservaPeliculaClienteSilla(int peliculaId, int clienteId, int sillaId);

        int EliminarReserva(int id);
    }
}
