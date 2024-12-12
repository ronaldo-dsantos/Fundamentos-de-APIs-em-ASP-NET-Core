using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)] // Produzindo um tipo de resposta, informando que devolveremos um tipo produto e um status code de 200 (formatador de resposta, serve para informar a API que tipo de retorno que teremos neste método)
        public IActionResult Get()
        {
            return Ok(new Produto { Id = 1, Nome = "Ronaldo" });
        }

        [HttpGet("{id:int}")] // Informando que receberemos um parâmetro na rota da requisição
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok(new Produto { Id = id, Nome = "Ronaldo" });
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Produto produto) // Informando que receberemos dados do produto no corpo da requisição (request body)
        {
            return CreatedAtAction("Get", new { id = produto.Id }, produto); // Retornando um status code 201, o endpoint para visualizar o recurso criado (rota e parâmetro) e o produto criado
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, Produto produto) // Informando que receberemos o id pela rota e o produto pelo corpo da requisição
        {
            if (id != produto.Id) return BadRequest();

            return NoContent(); // Retornando o status code 204
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id) 
        {
            return NoContent();
        }
    }
}
