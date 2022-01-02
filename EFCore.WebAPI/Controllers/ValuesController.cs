using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            var listHeroi = _context.Herois.ToList();
            return Ok(listHeroi);
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            //var listHeroi = _context.Herois.ToList();
            var listHeroi = (from heroi in _context.Herois where heroi.Nome.Contains(nome) select heroi).ToList();
            return Ok(listHeroi);
        }

        [HttpGet("atualizar/{nome}")]
        public ActionResult Get(string nome)
        {
            var heroi = _context.Herois
                .Where(h => h.Id == 3)
                .FirstOrDefault();
            heroi.Nome = "Homem Aranha";
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero };

            _context.Herois.Add(heroi);
            _context.SaveChanges();

            return Ok();
        }

    }
}
