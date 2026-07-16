namespace backend.Models
 
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public  int PessoaId { get; set; } 
        public int Tipo { get; set; } // 0 = despesa, 1 = receita   

    }
}