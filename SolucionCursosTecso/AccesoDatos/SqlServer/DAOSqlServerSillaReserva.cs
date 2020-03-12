using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;

namespace AccesoDatos.SqlServer
{
    public class DAOSqlServerSillaReserva : IAccesoDatosSillaReserva
    {
        private Contexto contexto;

        public DAOSqlServerSillaReserva(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public SillaReserva ObtenerSillaReservaId(int id)
        {
            SillaReserva sillaReserva = this.contexto.SillasReserva.Find(id);

            return sillaReserva;
        }

        public SillaReserva BuscarSillaReservaPorId(int reservaId, int sillaId)
        {
            SillaReserva sillaReserva = this.contexto.SillasReserva.FirstOrDefault(r => r.ReservaAlumnoId == reservaId && r.SillaId == sillaId);

            return sillaReserva;
        }

        public int ObtenerIdSillaPorCodigo(string codigo)
        {
            Silla silla = this.contexto.Sillas.FirstOrDefault(s => s.Codigo == codigo);

            return silla.SillaId;
        }

        public int EliminarSillaReserva(int id)
        {
            this.contexto.SillasReserva.Remove(this.ObtenerSillaReservaId(id));
            return this.contexto.SaveChanges();
        }

        public int InsertarSillaReserva(SillaReserva sillaReserva)
        {
            this.contexto.SillasReserva.Add(sillaReserva);
            return this.contexto.SaveChanges();
        }

        public List<SillaReserva> RetornarSillasReserva()
        {
            return this.contexto.SillasReserva.Include("Reserva").Include("Silla").ToList();
        }

        public SillaReserva BuscarSillaDeUnaReserva(int reservaId)
        {
            return this.contexto.SillasReserva.FirstOrDefault(s => s.ReservaAlumnoId == reservaId);
        }

        public List<Silla> ListarSillas()
        {
            return this.contexto.Sillas.ToList();
        }
    }
}
