using Back_end.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Repositorios
{
    public interface IRepositorio
    {


        void CrearGenero(Genero genero);

        Guid ObtenerGUID();
       Task<Genero>  ObtenerPorId(int Id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
