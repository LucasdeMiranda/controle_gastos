/*utilizando uma classe dto para que como não será armazenado os totais no banco e so calculado na hora
o dto é a melhor opção para isso é uma classe simples usada exclusivamente para transportar dados,
entre diferentes aplicações ou requisições de api como é o caso
*/
namespace backend.DTOs
{
    public class  TotalporPessoa
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Receitas { get; set; }
        public decimal Despesas { get; set; }
        public decimal Saldo { get; set; }
    }
}