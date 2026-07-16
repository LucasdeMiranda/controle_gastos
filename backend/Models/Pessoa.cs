namespace backend.Models
{

    public class Pessoa// public porque o Entity Framework precisa prencher os valores no futuro 
    //na hora de criar ou atualizar um objeto
    {
        // entity ja entende que id é a chave primaria,
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;// inicializa com uma string vazia por enquanto
        public int Idade { get; set; }
         // uma pessoa pode ter varias transacoes, por isso é uma lista
         public List<Transacao> Transacoes { get; set; } = new();
         

      
    }
}