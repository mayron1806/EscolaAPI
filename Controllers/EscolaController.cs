using EscolaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Services;
using EscolaAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class EscolaController: ControllerBase
    {
        private readonly EscolaServices _escolaServices;
        private readonly AlunoServices _alunoServices;
        private readonly TurmaServices _turmaServices;


        public EscolaController(EscolaServices escolaServices, AlunoServices alunoServices, TurmaServices turmaServices)
        {
            _escolaServices = escolaServices;
            _turmaServices = turmaServices;
            _alunoServices = alunoServices;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> PegaTodas()
        {
            try
            {
                var escolas = await _escolaServices.PegaTodasEscolas();
                return Ok(escolas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("{id}/alunos")]
        public async Task<IActionResult> PegaAlunos(Guid id)
        {
            try
            {
                var escolas = await _alunoServices.PegaAlunosEscola(id);
                return Ok(escolas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("{id}/turmas")]
        public async Task<IActionResult> PegaTurmas(Guid id)
        {
            try
            {
                var escolas = await _turmaServices.PegaTurmasDaEscola(id);
                return Ok(escolas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PegaPorID(Guid id)
        {
            try
            {
                var escola = await _escolaServices.PegaPorID(id);
                return Ok(escola);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        
        // POST
        [HttpPost]
        public async Task<ActionResult<Escola>> AdicionaEscola(Escola novaEscola)
        {
            try
            {
                var escola = await _escolaServices.Adicionar(novaEscola);
                return Ok(escola);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT/ PATCH
        [HttpPatch("{id}")]
        public async Task<ActionResult<Escola>> AtualizaEscola(Guid id, JsonPatchDocument<Escola> novaEscola)
        {
            try
            {
                var escola = await _escolaServices.Atualizar(id, novaEscola);
                return Ok(escola);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaEscola(Guid id)
        {
            try
            {
                await _escolaServices.Deletar(id);
                return Ok("Escola deletada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}