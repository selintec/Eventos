using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Repository.Context;
using ProEventos.Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Repository
{
    public class EventoRepository : IEventoRepository
    {

        private readonly ProEventosContext _contexto;

        public EventoRepository(ProEventosContext context)
        {
            _contexto = context;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool comPalestrantes = false)
        {
            IQueryable<Evento> resultado = _contexto.Eventos.Include(e => e.Lotes)
                                                            .Include(e => e.RedeSociais).OrderBy(e => e.Id)
                                                            .Where(e => e.Tema.ToLower().Contains(e.Tema.ToLower()));

            if (comPalestrantes)
                resultado = resultado.Include(pe => pe.PalestrantesEventos).ThenInclude(p => p.Palestrante);

            return await resultado.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool comPalestrantes = false)
        {
            IQueryable<Evento> resultado = _contexto.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais).OrderBy(e => e.Id).AsNoTracking();

            if (comPalestrantes)
                resultado = resultado.Include(pe => pe.PalestrantesEventos).ThenInclude(p => p.Palestrante);

            return await resultado.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool comPalestrantes = false)
        {
            IQueryable<Evento> resultado = _contexto.Eventos.Include(e => e.Lotes)
                                                            .Include(e => e.RedeSociais)
                                                            .Where(e => e.Id == id);

            if (comPalestrantes)
                resultado = resultado.Include(pe => pe.PalestrantesEventos).ThenInclude(p => p.Palestrante);

            return await resultado.FirstOrDefaultAsync();
        }
    }
}
