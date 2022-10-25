using EscolaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly NotaServices _notaServices;
        public NotaController(NotaServices notaServices)
        {
            _notaServices = notaServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Nota>>> PegaNotasDoAluno([FromQuery] Guid alunoID, [FromQuery] int ano){
            try
            {
                (bool sucesso, Guid resultado) = GuidServices.GuidValido("");
                if(!sucesso){
                    return BadRequest("Por favor forneça um aluno valido.");
                }
                var notas = await _notaServices.PegaNotasPorAluno(resultado, ano);
                return Ok(notas);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("bimestre/{bimestre}")]
        public async Task<ActionResult<int>> PegaNotasDoBimestre([FromRoute] Bimestre bimestre, [FromQuery] Guid alunoID, [FromQuery] int ano){
            try
            {
                var somaNotas = await _notaServices.SomaNotasDoBimestre(alunoID, bimestre, ano);
                return Ok(new { resultadoBimestral  = somaNotas });
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Nota>> AdicionaNota(Nota novaNota)
        {
            try
            {
                var escola = await _notaServices.Adicionar(novaNota);
                return Ok(escola);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT/ PATCH
        [HttpPut("{id}")]
        public async Task<ActionResult<Nota>> AtualizaNota(Guid id, Nota novaNota)
        {
            try
            {
                var escola = await _notaServices.Atualizar(id, novaNota);
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
                await _notaServices.Deletar(id);
                return Ok("Nota deletada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}