namespace EscolaAPI.Repository.Interfaces
{
    public interface IGenericoRepository<T> where T : class
    {
        public Task<T> PegaPorId(Guid id);
        public Task<List<T>> PegaTodos();
        public Task<T> Adicionar(T entity);
        public Task<T> Atualizar(T entity);
        public Task<bool> Deletar(T entity);
    }
}