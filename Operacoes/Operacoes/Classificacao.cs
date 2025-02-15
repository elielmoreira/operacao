using System;

namespace Operacoes
{
    public class Classificacao : Trade
    {
        public DateTime DataReferencia { get; set; } //Data de referência para classificação da operação
        public string Categoria { get; set; } //Categoria de classificação da operação
    }
}