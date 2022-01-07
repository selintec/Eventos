using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> eventos = new Evento [] 
        {
            new Evento() 
                {
                    Id = 1,
                    Tema = "Angular 11 e .NET 5.1",
                    Local = "São Paulo",
                    Lote = "Primeiro",
                    Quantidade = 100,
                    Data = DateTime.Now.AddDays(7).ToString(),
                    ImagemURL = "foto.png"
                },
                new Evento() 
                {
                    Id = 2,
                    Tema = "Angular 11 e .NET 5.1 + Dicas Preciosas",
                    Local = "São Paulo",
                    Lote = "Segundo",
                    Quantidade = 500,
                    Data = DateTime.Now.AddDays(7).ToString(),
                    ImagemURL = "foto1.png"
                }
        };

        public EventoController()
        {
    
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return eventos;
        }

         [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return eventos.Where(e => e.Id == id);
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
