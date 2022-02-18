using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Repository.Interface
{
    public interface IEventoRepository
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool comPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool comPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int id, bool comPalestrantes);
    }
}
