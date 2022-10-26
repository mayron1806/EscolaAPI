namespace EscolaAPI.Repository.Interfaces
{
    public interface IGenericoRepository<T>
    {
        public Task<T> PegaPorIDAsync(Guid id);
        public Task<T> AdicionarAsync(T entity);
        public Task<T> AtualizarAsync(T entity);
        public Task<bool> DeletarAsync(T entity);
    }
}