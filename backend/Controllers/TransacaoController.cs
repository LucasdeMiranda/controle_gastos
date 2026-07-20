using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly AppDbContext _context;//só pode escolher para onde apontar uma única vez.
        public TransacaoController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transacao"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CriarTransacao(Transacao transacao)
        {
            var pessoa = _context.Pessoas.Find(transacao.PessoaId);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada");
            }

            if (transacao.Valor <= 0)
            {
                return BadRequest("O valor da transação deve ser maior que zero.");
            }

            if (transacao.Tipo == 1 && pessoa.Idade < 18)
            {
                return BadRequest("Não é permitido criar receita para pessoas menores de 18 anos.");
            }
            else if (transacao.Tipo == 1 && pessoa.Idade >= 18)
            {
                _context.Transacoes.Add(transacao);
                _context.SaveChanges();

                return Ok(transacao);
            }
            else if (transacao.Tipo == 0)
            {
                _context.Transacoes.Add(transacao);
                _context.SaveChanges();

                return Ok(transacao);
            }

            // tentou enviar qualquer outro tipo coisa que pode ser feito interceptando o front
            return BadRequest("Tipo de transação inválido.");

        }

        [HttpGet]
        public IActionResult ListarTransacoes()
        {
            var transacoes = _context.Transacoes.ToList();
            return Ok(transacoes);
        }
    }


}