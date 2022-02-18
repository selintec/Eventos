using ProEventos.Application.Interface;
using ProEventos.Domain;
using ProEventos.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {

        public readonly IGenericRepository _genericRepository;
        public readonly IEventoRepository _eventoRepository;

        public EventoService(IGenericRepository genericRepository, IEventoRepository eventoRepository)
        {
            _genericRepository = genericRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> Add(Evento model)
        {
            try
            {
                _genericRepository.Add(model);

                if (await _genericRepository.SaveChangesAsync())
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> Update(int id, Evento model)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(id, false);

                if (evento == null) return null;

                model.Id = evento.Id;
                _genericRepository.Update(model);

                if (await _genericRepository.SaveChangesAsync())
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(id, false);

                if (evento == null) throw new Exception("Evento não encontrado para exclusão.");

                _genericRepository.Delete<Evento>(evento);

                return await _genericRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]>  GetAllEventosAsync(bool comPalestrantes)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(comPalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool comPalestrantes)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(id, comPalestrantes);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool comPalestrantes)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, comPalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
