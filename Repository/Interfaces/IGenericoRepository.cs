namespace EscolaAPI.Repository.Interfaces
{
    public interface IGenericoRepository<T> where T : class
    {
        public Task<T> AdicionarAsync(T entity);
        public Task<T> AtualizarAsync(T entity);
        public Task<bool> DeletarAsync(T entity);
    }
}