using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Entidades;
using Microsoft.Extensions.Logging;

namespace Back_end.Repositorios
{

    public class RepositorioEnMemoria:IRepositorio
    {

       
        private List<Genero> _generos;
        public RepositorioEnMemoria(ILogger<RepositorioEnMemoria> logger)
        {

            _generos = new List<Genero>()
            {
                new Genero(){Id=1, Nombre="Comedia"},
                new Genero(){Id=2, Nombre="Accion"},

            };
            _guid=Guid.NewGuid(); 
        }

        public Guid _guid;
        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        
         public async Task<Genero> ObtenerPorId(int Id)
         {
             await Task.Delay(1);
            
         return _generos.FirstOrDefault(x => x.Id == Id);
        }

         public Guid ObtenerGUID()
         {
             return _guid;
         }

         public void CrearGenero(Genero genero)
         {
             genero.Id = _generos.Count() + 1;
             _generos.Add(genero);
         }
    }
}