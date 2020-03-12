using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using Modelos;
using Modelos.DTO;

namespace LogicaNegocio
{
    public class FachadaSillaReserva
    {
        private IAccesoDatosSillaReserva accesoDatosSillaReserva;

        public FachadaSillaReserva(IAccesoDatosSillaReserva accesoDatosSillaReserva)
        {
            this.accesoDatosSillaReserva = accesoDatosSillaReserva;
        }

        public bool InsertarSillaReserva(DTOSillaReserva dtoSillaReserva)
        {
            try
            {
                SillaReserva sillaReserva = new SillaReserva
                {
                    ReservaAlumnoId = Convert.ToInt32(dtoSillaReserva.dtoReserva.ReservaId),
                    SillaId = dtoSillaReserva.dtoSilla.SillaId
                };

                this.accesoDatosSillaReserva.InsertarSillaReserva(sillaReserva);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DTOSillaReserva ObtenerSillaReserva(int id)
        {
            SillaReserva sillaReserva = this.accesoDatosSillaReserva.ObtenerSillaReservaId(id);

            DTOSillaReserva dtoSillaReserva = new DTOSillaReserva
            {
                SillaReservaId = id,
                dtoReserva = new DTOReservaAlumno {
                                                      ReservaId = sillaReserva.ReservaAlumnoId,
                                                      dtoAlumno = new DTOAlumno { AlumnoId = sillaReserva.ReservaAlumno.AlumnoId },
                                                      dtoCurso = new DTOCurso { CursoId = sillaReserva.ReservaAlumno.CursoId
                                                  }
                },
                dtoSilla = new DTOSilla {
                                            SillaId = sillaReserva.SillaId,
                                            Codigo = sillaReserva.Silla.Codigo
                                        }
            };

            return dtoSillaReserva;
        }

        public List<DTOSillaReserva> ListarSillaReservas()
        {
            List<SillaReserva> SillaReservas = this.accesoDatosSillaReserva.RetornarSillasReserva();
            List<DTOSillaReserva> dtoSillaReservas = new List<DTOSillaReserva>();

            foreach (var item in SillaReservas)
            {
                dtoSillaReservas.Add(new DTOSillaReserva
                {
                    SillaReservaId = item.SillaReservaId,
                    dtoReserva = new DTOReservaAlumno
                    {
                        ReservaId = item.ReservaAlumnoId,
                        dtoAlumno = new DTOAlumno
                        {
                            AlumnoId = item.ReservaAlumno.AlumnoId
                        },
                        dtoCurso = new DTOCurso
                        {
                            CursoId = item.ReservaAlumno.CursoId
                        }
                    },
                    dtoSilla = new DTOSilla
                    {
                        SillaId = item.SillaId,
                        Codigo = item.Silla.Codigo
                    }
                });
            }

            return dtoSillaReservas;
        }

        public SillaReserva BuscarSillaReserva(int reservaId, int sillaId)
        {
            return this.accesoDatosSillaReserva.BuscarSillaReservaPorId(reservaId, sillaId);
        }

        public bool EliminarSillaReserva(int id)
        {
            return this.accesoDatosSillaReserva.EliminarSillaReserva(id) == 1;
        }

        public int BuscarSilla(string codigo)
        {
            return this.accesoDatosSillaReserva.ObtenerIdSillaPorCodigo(codigo);
        }

        public SillaReserva RetornarSillaPorReserva(int reservaId)
        {
            return this.accesoDatosSillaReserva.BuscarSillaDeUnaReserva(reservaId);
        }

        public List<Silla> ListarSillas()
        {
            return this.accesoDatosSillaReserva.ListarSillas();
        }
    }
}
