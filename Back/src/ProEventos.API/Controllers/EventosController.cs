using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _contexto;
        public EventosController(DataContext contexto)
        {
          _contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _contexto.Eventos;
        }

         [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _contexto.Eventos.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "ValuePost";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Exemplo Verbo PUT: " + id.ToString();
        }

         [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Exemplo Verbo DELETE: " + id.ToString();
        }
    }
}
