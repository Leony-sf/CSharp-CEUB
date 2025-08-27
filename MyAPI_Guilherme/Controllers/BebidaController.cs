using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        private readonly BebidaService _bebidaService;

        public BebidasController(BebidaService bebidaService)
        {
            _bebidaService = bebidaService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_bebidaService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bebida = _bebidaService.GetById(id);
            if (bebida == null) return NotFound();
            return Ok(bebida);
        }

        [HttpPost("nao-alcoolica")]
        public IActionResult CreateNaoAlcoolica([FromBody] string nome)
        {
            var bebida = _bebidaService.CreateBebida(nome);
            return CreatedAtAction(nameof(GetById), new { id = bebida.Id }, bebida);
        }

        [HttpPost("alcoolica")]
        public IActionResult CreateAlcoolica([FromBody] BebidaAlcoolicaInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Nome))
            {
                return BadRequest("Nome da bebida alcoólica não pode ser nulo ou vazio.");
            }
            var bebida = _bebidaService.CreateBebidaAlcoolica(input.Nome, input.TeorAlcoolico);
            return CreatedAtAction(nameof(GetById), new { id = bebida.Id }, bebida);
        }
    }

    public class BebidaAlcoolicaInput
    {
        public string? Nome { get; set; }
        public double TeorAlcoolico { get; set; }
    }
}
