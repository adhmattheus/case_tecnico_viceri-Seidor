using APISuperHeroi.Model;
using Microsoft.AspNetCore.Mvc;

namespace APISuperHeroi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeroisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Heroi>> Get()
        {
            var herois = _context.Herois.ToList();
            if (herois.Count == 0)
            {
                return NotFound("Heróis não encontrados.");
            }
            return herois;
        }

        [HttpPost]
   
        public IActionResult Create([FromBody] Heroi novoHeroi)
        {
            try
            {
                // Validar se o modelo é válido
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verificar se NomeHeroi já existe (sem diferenciação de maiúsculas e minúsculas)
                var existingHeroi = _context.Herois
                    .AsEnumerable()
                    .FirstOrDefault(h => h.NomeHeroi.Equals(novoHeroi.NomeHeroi, StringComparison.OrdinalIgnoreCase));

                if (existingHeroi != null)
                {
                    // Retornar um BadRequest com a mensagem de erro
                    ModelState.AddModelError("NomeHeroi", "Já existe um herói com o mesmo nome.");
                    return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
                }

                // Associar os superpoderes ao novo herói
                if (novoHeroi.HeroisSuperPoderes != null)
                {
                    foreach (var heroiSuperPoder in novoHeroi.HeroisSuperPoderes)
                    {
                        heroiSuperPoder.Heroi = novoHeroi;
                    }
                }

                // Adicionar o novo herói ao contexto
                _context.Herois.Add(novoHeroi);
                _context.SaveChanges();

                // Retornar o novo herói e um status 201 Created
                return CreatedAtAction(nameof(Get), new { id = novoHeroi.Id }, novoHeroi);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retornar um status 500 Internal Server Error
                return StatusCode(500, new { Error = $"Erro interno: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<object> GetById(int id)
        {
            try
            {
                // Verificar se o ID foi fornecido
                if (id <= 0)
                {
                    return BadRequest(new { ErrorMessage = "ID inválido. Forneça um ID válido para consultar um super-herói." });
                }

                // Buscar o super-herói pelo Id
                var heroi = _context.Herois.Find(id);

                // Verificar se o super-herói foi encontrado
                if (heroi == null)
                {
                    return NotFound(new { ErrorMessage = $"Super-herói com Id {id} não encontrado." });
                }

                // Retornar o super-herói encontrado
                return new { Heroi = heroi };
            }
            catch (Exception ex)
            {
                // Em caso de erro, retornar um status 500 Internal Server Error
                return StatusCode(500, new { ErrorMessage = $"Erro interno: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Heroi heroiAtualizado)
        {
            try
            {
                // Verificar se o ID é válido
                if (id <= 0)
                {
                    return BadRequest(new { ErrorMessage = "ID inválido. Forneça um ID válido para atualizar um super-herói." });
                }

                // Buscar o super-herói pelo Id
                var heroiExistente = _context.Herois.Find(id);

                // Verificar se o super-herói foi encontrado
                if (heroiExistente == null)
                {
                    return NotFound(new { ErrorMessage = $"Super-herói com Id {id} não encontrado." });
                }

                // Atualizar as propriedades do super-herói existente com as do herói atualizado
                heroiExistente.Nome = heroiAtualizado.Nome;
                heroiExistente.NomeHeroi = heroiAtualizado.NomeHeroi;
                heroiExistente.DataNascimento = heroiAtualizado.DataNascimento;
                heroiExistente.Altura = heroiAtualizado.Altura;
                heroiExistente.Peso = heroiAtualizado.Peso;

                // Atualizar o contexto
                _context.SaveChanges();

                // Retornar o super-herói atualizado
                return Ok(new { Message = "Herói atualizado com sucesso!", Heroi = heroiExistente });
            }
            catch (Exception ex)
            {
                // Em caso de erro, retornar um status 500 Internal Server Error
                return StatusCode(500, new { ErrorMessage = $"Erro interno: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // Verificar se o ID é válido
                if (id <= 0)
                {
                    return BadRequest(new { ErrorMessage = "ID inválido. Forneça um ID válido para excluir um super-herói." });
                }

                // Buscar o super-herói pelo Id
                var heroi = _context.Herois.Find(id);

                // Verificar se o super-herói foi encontrado
                if (heroi == null)
                {
                    return NotFound(new { ErrorMessage = $"Super-herói com Id {id} não encontrado." });
                }

                // Remover o super-herói do contexto e salvar as alterações
                _context.Herois.Remove(heroi);
                _context.SaveChanges();

                // Retornar uma mensagem de sucesso
                return Ok(new { Message = $"Super-herói com Id {id} excluído com sucesso." });
            }
            catch (Exception ex)
            {
                // Em caso de erro, retornar um status 500 Internal Server Error
                return StatusCode(500, new { ErrorMessage = $"Erro interno: {ex.Message}" });
            }
        }




    }


}
