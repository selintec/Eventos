using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Repository.Context;
using ProEventos.Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Repository
{
    public class PalestranteRepository : IPalestranteRepository
    {

        private readonly ProEventosContext _contexto;

        public PalestranteRepository(ProEventosContext context)
        {
            _contexto = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool comEventos = false)
        {
            IQueryable<Palestrante> resultado = _contexto.Palestrantes.Include(p => p.RedeSociais)
                                                                        .OrderBy(p => p.Id)
                                                                        .Where(p => p.Nome.ToLower().Contains(p.Nome.ToLower())).AsNoTracking();

            if (comEventos)
                resultado = resultado.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);

            return await resultado.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool comEventos = false)
        {
            IQueryable<Palestrante> resultado = _contexto.Palestrantes.Include(e => e.RedeSociais).OrderBy(e => e.Id).AsNoTracking();

            if (comEventos)
                resultado = resultado.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);

            return await resultado.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int id, bool comEventos = false)
        {
            IQueryable<Palestrante> resultado = _contexto.Palestrantes.Include(p => p.RedeSociais)
                                                                      .Where(p => p.Id == id).AsNoTracking();

            if (comEventos)
                resultado = resultado.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);

            return await resultado.FirstOrDefaultAsync();
        }
    }
}
