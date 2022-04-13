using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades.Repositorio
{
    public interface IRepositorio
    {
        Guid obtenerGuid();
        Task<Genero> obtenerPorId(int Id);
        List<Genero> obtenerTodosLosGeneros();
    }
}
