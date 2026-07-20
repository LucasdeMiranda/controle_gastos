using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;

//API rest como os metodos post para criação get para listagem e delete para exclusão da pessoa e suas transações
namespace backend.Controllers
{
    [ApiController]
    //esse controller é substituído pelo nome da classe sem o controller automaticamente
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarPessoa(Pessoa pessoa)
        {
            if (pessoa.Idade < 0){
                 return BadRequest("Não é permitido idade negativa.");
            }
            _context.Pessoas.Add(pessoa);

            _context.SaveChanges();

            return Ok(pessoa);
        }

        [HttpGet]
        public IActionResult ListarPessoas()
        {
            var pessoas = _context.Pessoas.ToList();
            return Ok(pessoas);
        }
        //passa o id para saber qual pessoa excluir
        [HttpDelete("{id}")]
        public IActionResult ExcluirPessoa(int id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var transacoes = _context.Transacoes.Where(t => t.PessoaId == id).ToList();
            _context.Transacoes.RemoveRange(transacoes);
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();

            return Ok(pessoa);
        }

    }
}