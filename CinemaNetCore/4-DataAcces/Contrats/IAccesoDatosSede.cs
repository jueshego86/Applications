using _2_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4_DataAcces.Contrats
{
    public interface IAccesoDatosSede
    {
        int InsertarSede(Sede sede);

        List<Sede> RetornarSedes();
    }
}
