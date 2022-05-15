using Back_end.Entidades;
using Back_end.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.flitros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace Back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
        
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

            public GenerosController(IRepositorio repositorio, 
            WeatherForecastController weatherForecastController,
            ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
        }

        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listadosgeneros")]
        //[ResponseCache(Duration = 60)]
       [ServiceFilter(typeof(MiFiltroDeAccion))]
        public ActionResult<List<Genero>> Get() 
        {  
            logger.LogInformation("Vamos a mostrar los generos");
        return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("guid")]
        public ActionResult<Guid> GetGUID()
        {
            return Ok(new
            {
                GUID_GenerosController = repositorio.ObtenerGUID(),
                GUID_WeatherForecastController = weatherForecastController.ObtenerGUIDWatherForecastController()
            });
        }
        
        
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader]  string nombre)
        {
            
            logger.LogDebug($"Obteniendo el género por el id {Id}");
            
            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                throw new ApplicationException($"El género de Id {Id} no fue enontrado");
                //logger.LogWarning($"No se pudo encontrar el género de id {Id}");
                //return NotFound();
            }

            //IActionResult no asegura que se retorne un genero
            
            //return "Felipe"
            //return Ok("Felipe");
            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }


    }
}
