using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController] // Informando que esta controller � uma controller de API
    // [Route("[controller]")] // Informando que a rota � o nome da controller
    [Route("api/minha-controller")] // Informando um nome personalizado para a rota
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
            
        }

        [HttpGet] // Informando o verbo do m�todo
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id:int}/{id2:int}")] // Informando o verbo do m�todo, os par�metros que o m�todo vai receber e o tipo do par�metro 
        public IActionResult Get2(int id, int id2)
        {
            return Ok();
        }

    }
}
