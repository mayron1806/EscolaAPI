using EscolaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;
using Microsoft.AspNetCore.JsonPatch;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly NotaServices _notaServices;
        private readonly TurmaServices _turmaServices;

        public TurmaController(TurmaServices turmaServices, NotaServices notaServices)
        {
            _turmaServices = turmaServices;
            _notaServices = notaServices;
        }
        
        [HttpGet]
        public async Task<ActionResult<Turma>> PegaTurmaPorID(Guid id)
        {
            
            try
            {
                var turma = await _turmaServices.PegaPorID(id);
                return Ok(turma);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Turma>> AdicionaTurma(Turma novaTurma)
        {
            try
            {
                var turma = await _turmaServices.Adicionar(novaTurma);
                return Ok(turma);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT/ PATCH
        [HttpPut("{id}")]
        public async Task<ActionResult<Nota>> AtualizaTurma(Guid id, JsonPatchDocument<Nota> novaTurma)
        {
            try
            {
                var turma = await _notaServices.Atualizar(id, novaTurma);
                return Ok(turma);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaTurma(Guid id)
        {
            try
            {
                await _turmaServices.Deletar(id);
                return Ok("Turma deletada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}