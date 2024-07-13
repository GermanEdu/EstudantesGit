using EstudantesApi.Context;
using EstudantesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudantesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudantesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public EstudantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEstudantes()
        {
            return Ok(_context.Estudantes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Getestudante(int id)
        {
            var estudante = _context.Estudantes.Find(id);
            if (estudante == null)
                return NotFound();
            return Ok(estudante);
        }

        [HttpPost]
        public IActionResult Createestudante([FromBody] Estudante estudante)
        {
            _context.Estudantes.Add(estudante);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Getestudante), new { id = estudante.Id }, estudante);
        }

        [HttpPut("{id}")]
        public IActionResult Updateestudante(int id, [FromBody] Estudante estudante)
        {
            var existingestudante = _context.Estudantes.Find(id);
            if (existingestudante == null)
                return NotFound();

            existingestudante.Nome = estudante.Nome;
            existingestudante.Idade = estudante.Idade;
            existingestudante.Serie = estudante.Serie;
            existingestudante.NotaMedia = estudante.NotaMedia;
            existingestudante.Endereco = estudante.Endereco;
            existingestudante.NomePai = estudante.NomePai;
            existingestudante.NomeMae = estudante.NomeMae;
            existingestudante.DataNascimento = estudante.DataNascimento;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteestudante(int id)
        {
            var estudante = _context.Estudantes.Find(id);
            if (estudante == null)
                return NotFound();

            _context.Estudantes.Remove(estudante);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
