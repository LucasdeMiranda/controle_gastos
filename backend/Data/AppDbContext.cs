// aqui fica a comunicação entre a aplicação e o banco de dados
using Microsoft.EntityFrameworkCore;
using backend.Models;


namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        // cria as tabelas com base nas classes criadas
        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }
    }
}