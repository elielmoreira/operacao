using System;

namespace Operacoes
{
    public class Trade
    {
        public double Value { get; set;  } //indica o valor da operação em dólar
        public string ClientSector { get; set; } //Indica o setor do cliente, que pode ser "Public" ou "Private"
        public DateTime NextPaymentDate { get; set; } //Indica a expectativa da data do próximo pagamento do cliente ao banco
    }
}