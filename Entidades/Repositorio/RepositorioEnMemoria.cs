using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades.Repositorio
{
    public class RepositorioEnMemoria:IRepositorio
    {
        List<Genero> generos = new List<Genero>();

        public Guid _guid;
        public RepositorioEnMemoria(){
             generos.Add(new Genero() { Id = 1, Nombre = "Comedia" });
            generos.Add(new Genero() { Id = 2, Nombre = "Accion" });
            _guid = Guid.NewGuid(); //para los ciclos de vida
        }

        public List<Genero> obtenerTodosLosGeneros() {
           
            return generos;
        }
        //metodo asincrono
        public async Task<Genero> obtenerPorId(int Id) {

            //esperar 3 segundos en cada peticion
            await Task.Delay(TimeSpan.FromSeconds(1));
            return generos.FirstOrDefault(x=>x.Id==Id);
        }
        public Guid obtenerGuid() {
            return _guid;

        }
    }
}
