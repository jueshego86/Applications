using _2_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4_DataAcces.Contrats
{
    public interface IAccesoDatosSala
    {
        int InsertarSala(Sala sala);

        List<Sala> RetornarSalas();

        Sala BuscarSala(int id);
    }
}
