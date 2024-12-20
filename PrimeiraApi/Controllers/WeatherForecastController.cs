using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController] // Informando que se trata de uma controller de API
    // [Route("[controller]")] // Informando que a rota é o nome da controller
    [Route("api/minha-controller")] // Informando um nome personalizado para a rota
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
            
        }

        [HttpGet] // Informando o verbo do método
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id:int}/{id2:int}")] // Informando o verbo do método, os par�metros que o m�todo vai receber e o tipo do par�metro 
        public IActionResult Get2(int id, int id2)
        {
            return Ok();
        }

    }
}
