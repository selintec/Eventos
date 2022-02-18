using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? Data { get; set; }
        public string Tema { get; set; }
        public int Quantidade { get; set; }
        public string Lote { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

        public static implicit operator Task<object>(Evento v)
        {
            throw new NotImplementedException();
        }
    }
}