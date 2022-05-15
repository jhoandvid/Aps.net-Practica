using System.Linq;
using Back_end.DTOs;

namespace Back_end.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T>Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
        {
            return queryable.Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina).Take(paginacionDTO.RecordsPorPagina);
        }
    }
}