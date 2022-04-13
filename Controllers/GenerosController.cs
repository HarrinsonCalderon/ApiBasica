using back_end.Entidades;
using back_end.Entidades.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    //route es la ruta para este controller
    // [Route("api/[controller]")] es lo mismo pero tiene mas desventajas
    [Route("api/generos")]
    //:ControllerBase es para poder usar mas metodos auxiliares como los metodos de 404
    [ApiController] //Para usar los datanotation sin el modelstate.isvalid, es automatiza esa validacion
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio repositorio;
        public GenerosController(IRepositorio repositorio) {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public List<Genero> Get() {
            return this.repositorio.obtenerTodosLosGeneros();
        }
        //[HttpGet("ejemplo")] https://localhost:44395/api/generos/ejemplo?Id=2
        //[HttpGet("{Id}")] //https://localhost:44395/api/generos/2
        //[HttpGet("{Id}/{nombre}")] //https://localhost:44395/api/generos/2/felipe
        //[HttpGet("{Id}/{nombre=felipe}")] //https://localhost:44395/api/generos/2 y felipe se asigna por defecto a nombre
        //[HttpGet("{Id:int}/{nombre=felipe}")] //para obligar que el id sea int, sino cumple no entra en la ruta
        ////ActionResult<Genero> para retorinar un genero o un actionresult para el not found
        //public async Task<ActionResult<Genero>> Get(int Id,string nombre)
        //{
        //    var genero = await repositorio.obtenerPorId(Id);
        //    if (genero == null)
        //    {
        //         return NotFound();
        //    }
        //    return genero;

        //}

        //[BindRequired] para hacer el nombre obligatorio, el nombre se manda por url /api/generos/2?nombre=pepe
        //[FromBody] para los registros actualizacion y creacion, se reciben en json, osea angualr lo envia en json
        [HttpGet("{Id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //filtro de autorizacion
        [ServiceFilter(typeof(FIltros.filtroDeAccion))]
        public async Task<ActionResult<Genero>> Get(int Id,[FromHeader] string nombre)
        {
            //para verificar si se cumple lo del bind, sino se cumple, mirar que no se cumple
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var genero = await repositorio.obtenerPorId(Id);
            if (genero == null)
            {
                return NotFound();
            }
            return genero;

        }
        
        [HttpPost]
        public ActionResult Post([FromBody] Genero genero) {
            
            return NoContent();
        }
        [HttpPut]
        public void Put()
        {

        }
        [HttpDelete]
        public void Delete()
        {

        }

    }
}
