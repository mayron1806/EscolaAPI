using EscolaAPI.Context;
using EscolaAPI.Entities;
using EscolaAPI.Repository;
using EscolaAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EscolaAPI.Services;
public class EscolaServices: GenericoService<Escola>
{
    private readonly IEscolaRepository _escolaRepo;
    public EscolaServices(IEscolaRepository escolaRepo): base(escolaRepo)
    { 
        _escolaRepo = escolaRepo; 
    }

    public static async Task ValidaEscolaExiste(IEscolaRepository _escolaRepo, Guid escolaID){
        var escola = await _escolaRepo.PegaPorIDAsync(escolaID);
        if(escola == null){
            throw new ArgumentException("A escola não existe");
        }
    }
    public async Task<List<Escola>> PegaTodasEscolas()
    {
        var escolas = await _escolaRepo.PegaTodosAsync();
        if(escolas == null) throw new NullReferenceException("Ainda não foram adicionadas escolas.");
        return escolas;
    }
}