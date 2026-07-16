using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.DTOs;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TotaisController : ControllerBase
    {
        private readonly AppDbContext _context;//só pode escolher para onde apontar uma única vez.
        public TotaisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarTotais()
        {
            
            // o que ésta sendo feito aqui é para cada pessoa ta separando e somando as receitas e despesas
            //assim o banco de dados faz os cálculos e evit de fazer todas as operações na memória
            var pessoas = _context.Pessoas
                .Select(pessoa => new TotalporPessoa
                {
                    Nome = pessoa.Nome,
                    Receitas = _context.Transacoes
                        .Where(transacao => transacao.PessoaId == pessoa.Id && transacao.Tipo == 1)
                        .Sum(t => (decimal?)t.Valor) ?? 0,
                    Despesas = _context.Transacoes
                        .Where(t => t.PessoaId == pessoa.Id && t.Tipo == 0)
                        .Sum(t => (decimal?)t.Valor) ?? 0
                }).ToList();

            /* neste for como já e calculado as receitas e despesas de cada pessoa basta fazer um menos o
            outro para se obter o saldo de cada pessoa
            */
            foreach (var pessoa in pessoas)
            {
                pessoa.Saldo = pessoa.Receitas - pessoa.Despesas;
            }

            var totalreceita = pessoas.Sum(p => p.Receitas);
            var totaldespesa = pessoas.Sum(p => p.Despesas);

            return Ok(new
            {
                Pessoas = pessoas,
                Totalreceita = totalreceita,
                Totaldespesa = totaldespesa,
                saldogeral = totalreceita - totaldespesa
            });
        }
    }
}