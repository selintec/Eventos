using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Interface
{
    public interface IEventoService
    {
        Task<Evento> Add(Evento model);
        Task<Evento> Update(int id, Evento model);
        Task<bool> Delete(int id);

        Task<Evento[]> GetAllEventosAsync(bool comPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int id, bool comPalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool comPalestrantes = false);
    }
}
