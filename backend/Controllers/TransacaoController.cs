using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController: ControllerBase
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
        /// <param name="pessoaid"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CriarTransacao(Transacao transacao, int pessoaid, int tipo)
        {
             var pessoa = _context.Pessoas.Find(pessoaid);
             if (pessoa == null)
             {
                 return NotFound();
             }

             if (tipo == 1 && pessoa.Idade < 18)
            {
                return BadRequest("Não é permitido criar receita para pessoas menores de 18 anos.");
            }

            else if(tipo == 1 && pessoa.Idade >= 18)
            {
                transacao.PessoaId = pessoaid;
                transacao.Tipo = tipo;
                _context.Transacoes.Add(transacao);
                _context.SaveChanges();
                return Ok(pessoa);
            } 
            else if(tipo == 0)
            {
                transacao.PessoaId = pessoaid;
                transacao.Tipo = tipo;
                _context.Transacoes.Add(transacao);
                _context.SaveChanges();
                 return Ok(pessoa);
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