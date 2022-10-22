using EscolaAPI.Context;
using EscolaAPI.Entities;
using EscolaAPI.Repository;
using EscolaAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Services;
public class EscolaServices
{
    private readonly IEscolaRepository _escolaRepo;
    public EscolaServices(IEscolaRepository escolaRepo)
    {
        _escolaRepo = escolaRepo;
    }

    // SELECT
    public async Task<Escola> PegaEscolaPorId(Guid id){
        var escola = await _escolaRepo.PegaPorIdAsync(id);
        if(escola == null) throw new NullReferenceException("Escola não encontrada.");
        return escola;
    }
    public async Task<List<Escola>> PegaEscolasPorNome(string nome){
        var escolas = await _escolaRepo.PegarPorNomeAsync(nome);
        if(escolas == null) throw new NullReferenceException("Nenhuma escola corresponde a este nome.");
        return escolas;
    }
    public async Task<List<Escola>> PegaTodasEscolas(){
        var escolas = await _escolaRepo.PegaTodosAsync();
        if(escolas == null) throw new NullReferenceException("Ainda não foram adicionadas escolas");
        return escolas;
    }

    // INSERT
    public async Task<Escola> Adicionar(Escola novaEscola){
        await _escolaRepo.AdicionarAsync(novaEscola);
        if(novaEscola.ID == null){
            throw new Exception("Erro ao adicionar escola.");
        }
        return novaEscola;
    }

    // UPDATE
    public async Task<Escola> Atualizar(Guid id, Escola novaEscola)
    {
        var escola = await _escolaRepo.PegaPorIdAsync(id);
        if(escola == null) throw new NullReferenceException("Erro ao atualizar a escola. Escola não encontrada.");
        novaEscola.ID = escola.ID;
        return await _escolaRepo.AtualizarAsync(novaEscola);
    }
    
    // DELETE
    public async Task<bool> DeletarEscola(Guid id){
        var escola = await _escolaRepo.PegaPorIdAsync(id);
        if(escola == null) throw new NullReferenceException("A escola que você está tentando deletar não foi encontrada.");
        return await _escolaRepo.DeletarAsync(escola);
    }
}