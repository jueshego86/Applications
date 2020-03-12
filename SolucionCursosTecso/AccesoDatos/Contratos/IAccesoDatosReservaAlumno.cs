using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Modelos.DTO;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosReservaAlumno
    {
        int InsertarReserva(ReservaAlumno reserva);

        List<ReservaAlumno> RetornarReservas();

        ReservaAlumno BuscarReserva(int? id);

        ReservaAlumno BuscarReservaCursoAlumno(int cursoId, int alumnoId);

        IQueryable<DTOSillaReserva> BuscarSillasReservadasCurso(int cursoId);

        IQueryable<ReservaAlumno> BuscarReservaCursoAlumnoSilla(int cursoId, int alumnoId, int sillaId);

        int EliminarReserva(int id);
    }
}
