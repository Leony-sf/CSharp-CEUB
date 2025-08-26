using Microsoft.AspNetCore.Mvc;
using ServidorFuncionarioAPI.Models;

namespace ServidorFuncionarioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>
        {
            new Funcionario { Id = 1, Nome = "João Silva", Cargo = "Analista", Salario = 3500 },
            new Funcionario { Id = 2, Nome = "Maria Oliveira", Cargo = "Desenvolvedora", Salario = 5000 }
        };
        private static int nextId = 3;

        [HttpGet]
        public ActionResult<List<Funcionario>> Get()
        {
            return Ok(funcionarios);
        }

        [HttpPost]
        public ActionResult<Funcionario> Post([FromBody] Funcionario novoFuncionario)
        {
            if (novoFuncionario == null)
            {
                return BadRequest("Funcionário inválido.");
            }

            novoFuncionario.Id = nextId++;
            funcionarios.Add(novoFuncionario);
            return CreatedAtAction(nameof(Get), new { id = novoFuncionario.Id }, novoFuncionario);
        }
    }
}