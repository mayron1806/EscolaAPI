using EscolaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Services;
using EscolaAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class EscolaController: ControllerBase
    {
        private readonly EscolaServices _escolaServices;
        public EscolaController(EscolaServices escolaServices)
        {
            _escolaServices = escolaServices;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> PegaPorID(Guid id)
        {
            try
            {
                var escolas = await _escolaServices.PegaEscolaPorId(id);
                return Ok(escolas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> PegaPorNome(string nome)
        {
            try
            {
                var escolas = await _escolaServices.PegaEscolasPorNome(nome);
                return Ok(escolas);
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
        [HttpPut("{id}")]
        public async Task<ActionResult<Escola>> AtualizaEscola(Guid id, Escola novaEscola)
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
        public async Task<ActionResult<Escola>> DeletaEscola(Guid id)
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