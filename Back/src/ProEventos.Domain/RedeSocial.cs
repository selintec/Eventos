namespace ProEventos.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public int? IdEvento { get; set; }
        public Evento Evento { get; set; }
        public int IdPalestrante { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}
