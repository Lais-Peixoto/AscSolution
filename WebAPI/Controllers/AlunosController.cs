using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AlunosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Aluno>>> GetAluno()
        {
            return await _context.Aluno.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // GET: api/Alunos/Campeonato
        [HttpGet("/campeonato")]
        public async Task<ActionResult<List<Competidores>>> GetCampeonato()
        {
            // competidores: pegar a lista de alunos, ordenar de forma decrescente pela média e pegar os cinco primeiros.
            var alunos = await _context.Aluno.ToListAsync();
            alunos = alunos.OrderByDescending(c => c.Media).Take(5).ToList();

            // vencedor: gerar um numero aleatorio, calcular a media e pegar o de maior media.
            // retornar uma lista com competiores, notas, nota especial, media, resultado
            var resultado = new List<Competidores>();
            foreach (var aluno in alunos)
            {
                var rnd = new Random();
                var notaCompeticao = (float)((aluno.Nota1 + aluno.Nota2 + aluno.Nota3 + 2 * (rnd.NextDouble() * 10)) / 5);

                var classificado = new Competidores(aluno, notaCompeticao);

                resultado.Add(classificado);
            }
            resultado = resultado.OrderByDescending(r => r.Resultado).ToList();

            return resultado;
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }

    public class Competidores
    {
        public Aluno Competidor { get; private set; }
        public float Resultado { get; private set; }
        public Competidores(Aluno competidor, float nota)
        {
            Competidor = competidor;
            Resultado = nota;
        }
    }
}
