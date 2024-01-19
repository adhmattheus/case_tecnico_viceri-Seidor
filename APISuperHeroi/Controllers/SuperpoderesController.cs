using APISuperHeroi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APISuperHeroi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuperpoderesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SuperPoderes>> Get()
        {
            var superpoderes = _context.Superpoderes.ToList();
            if (superpoderes.Count == 0)
            {
                return NotFound("Superpoderes não encontrados.");
            }
            return superpoderes;
        }
    }
}
