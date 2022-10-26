using EscolaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Entities;
using EscolaAPI.Entities.Enums;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult<Nota>> PegaNotaPorID(Guid id)
        {
            try
            {
                var nota = await _notaServices.PegaNotasPorID(id);
                return Ok(nota);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Nota>> AdicionaNota(Nota novaNota)
        {
            try
            {
                var nota = await _notaServices.Adicionar(novaNota);
                return Ok(nota);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT/ PATCH
        [HttpPut("{id}")]
        public async Task<ActionResult<Nota>> AtualizaNota(Guid id, JsonPatchDocument<Nota> novaNota)
        {
            try
            {
                var nota = await _notaServices.Atualizar(id, novaNota);
                return Ok(nota);
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