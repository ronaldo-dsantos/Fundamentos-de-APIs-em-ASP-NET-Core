using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController] // Informando que se trata de uma controller de API
    //[Route("[controller]")] // Informando que a rota é o nome da controller
    [Route("api/minha-controller")] // Informando um nome personalizado para a rota (nome do recurso)
    public class WeatherForecastController : ControllerBase 
    {
        [HttpGet] // Informando o verbo do método
        //[HttpGet("teste")] // Informando o verbo do método e um complemento personalizado para a rota
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id:int}/{id2:int}")] // Informando o verbo do método, os parâmetros que o método vai receber e o tipo do parâmetro 
        public IActionResult Get2(int id, int id2)
        {
            return Ok();
        }
    }
}
