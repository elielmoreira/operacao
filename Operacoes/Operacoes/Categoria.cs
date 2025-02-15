
namespace Operacoes
{
    public class Categoria
    {
        public int Atraso { get; set; } // quantidade de dias de atraso da operação
        public string Setor { get; set; } // setor de origem da operação (Exemplo: Publico ou Privado)
        public double ValorAcimaDe { get; set; } // valor de estouro de limite da operação
        public string DescricaoCategoria { get; set; } // descrição da categoria da operação
        public string DescricaoRegra { get; set; } // descrição da regra de tratamento da categoria
    }
}