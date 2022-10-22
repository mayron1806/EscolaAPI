using EscolaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EscolaAPI.Entities;

namespace EscolaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoServices _alunoServices;
        public AlunoController(AlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }
        #region GETS
        [HttpGet("presenca")]
        public async Task<IActionResult> PegaPorPresenca([FromQuery] string condicao, [FromQuery] int presenca, [FromQuery] Guid escola)
        {
            try
            {
                var alunos = await _alunoServices.PegaAlunosPorPresenca(escola, condicao, presenca);
                return Ok(alunos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("nome")]
        public async Task<IActionResult> PegaPorNome([FromQuery] string nome, [FromQuery] Guid escola)
        {
            try
            {
                var alunos = await _alunoServices.PegaAlunosPorNome(escola, nome);
                return Ok(alunos);
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
                var aluno = await _alunoServices.PegaAlunoPorID(id);
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("escola/{escolaID}")]
        public async Task<IActionResult> PegaPorEscola(Guid escolaID)
        {
            try
            {
                var alunos = await _alunoServices.PegaAlunosEscola(escolaID);
                return Ok(alunos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        #endregion
       
        [HttpPost]
        public async Task<IActionResult> AdicionarAluno(Aluno novoAluno)
        {
            try
            {
                var aluno = await _alunoServices.AdicionarAluno(novoAluno);
                return CreatedAtAction(nameof(PegaPorID), new {id = aluno.ID}, aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAluno(Guid id, Aluno novoAluno)
        {
            try
            {
                var aluno = await _alunoServices.AtualizarAluno(id, novoAluno);
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
                await _alunoServices.DeletarAluno(id);
                return Ok("Aluno deletado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}