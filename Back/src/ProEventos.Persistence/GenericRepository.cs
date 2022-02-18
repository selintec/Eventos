using ProEventos.Repository.Context;
using ProEventos.Repository.Interface;
using System.Threading.Tasks;

namespace ProEventos.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ProEventosContext _contexto;

        public GenericRepository(ProEventosContext context)
        {
            _contexto = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _contexto.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }

    }
}
