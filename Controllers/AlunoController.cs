using EscolaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoServices _alunoServices;
        private readonly NotaServices _notaServices;

        public AlunoController(AlunoServices alunoServices, NotaServices notaServices)
        {
            _alunoServices = alunoServices;
            _notaServices = notaServices;
        }
                
        [HttpGet("{id}")]
        public async Task<IActionResult> PegaPorID(Guid id)
        {
            try
            {
                var aluno = await _alunoServices.PegaPorID(id);
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("{id}/notas")]
        public async Task<IActionResult> PegaNotas(Guid id, [FromQuery] int ano)
        {
            try
            {
                var aluno = await _notaServices.PegaNotasDoAluno(id, ano);
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
       
        [HttpPost]
        public async Task<IActionResult> AdicionarAluno(Aluno novoAluno)
        {
            try
            {
                var aluno = await _alunoServices.Adicionar(novoAluno);
                return CreatedAtAction(nameof(PegaPorID), new {id = aluno.ID}, aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAluno(Guid id, JsonPatchDocument<Aluno> novoAluno)
        {
            try
            {
                var aluno = await _alunoServices.Atualizar(id, novoAluno);
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaAluno(Guid id)
        {
            try
            {
                await _alunoServices.Deletar(id);
                return Ok("Aluno deletado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}