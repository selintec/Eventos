using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Repository.Interface
{
    public interface IPalestranteRepository
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool comEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool comEventos = false);
        Task<Palestrante> GetAllPalestranteByIdAsync(int id, bool comEventos = false);
    }
}
