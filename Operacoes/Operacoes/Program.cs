using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Operacoes
{
    internal class Program
    {
        static void Main(string[] args)
        {            

            // Ausentes os detalhes de como serão processadas as entradas o código trata a 
            // digitação das operações uma a uma, mas, pode ser facilmente ajustado para 
            // receber um arquivo em formato JSON ou outro para realizar um processamento
            // em lote.
            string DtReferencia = "";

            Console.WriteLine("OPERAÇÕES");
            Console.WriteLine("\nInforme a data de referência para categorizar as operações ou <Enter> para encerrar:");
            DtReferencia = Console.ReadLine();

            if (DtReferencia != "")
            {
                Console.WriteLine("\nInforme a quantidade de operações:");
                string QtdOperacoes = Console.ReadLine();

                if (QtdOperacoes != "0")
                {
                    List<Trade> listaOperacoes = new List<Trade>();                    
                    int qtdOperacoes = Convert.ToInt32(QtdOperacoes);
                    int iContLoop = 1;
                    while (qtdOperacoes > 0)
                    {                        
                        Console.WriteLine("\nInforme a operação {0}:", iContLoop);
                        var operacao = Console.ReadLine();

                        if (string.IsNullOrEmpty(operacao))
                            continue;

                        if (operacao.Split().Length != 3)
                        {
                            Console.WriteLine("\nFormato da operação {0} inválido.", iContLoop);
                            iContLoop++;
                            qtdOperacoes--;
                            continue;
                        }                            

                        Trade itemOperacao = new Trade();
                        itemOperacao.Value = Convert.ToDouble(operacao.Split()[0]);
                        itemOperacao.ClientSector =  operacao.Split()[1];
                        itemOperacao.NextPaymentDate = DateTime.ParseExact(operacao.Split()[2], "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        listaOperacoes.Add(itemOperacao);

                        iContLoop++;
                        qtdOperacoes--;
                    }
                    
                    List<Classificacao> operacoesClassificadas = new List<Classificacao>();
                    Classificacao itemClassificacao = new Classificacao();
                    DateTime dtReferencia = DateTime.ParseExact(DtReferencia, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string resultadoClassificacao = "";

                    foreach (var item in listaOperacoes)
                    {
                        var resultadoCategoria = VerificaCategoria(dtReferencia, item.NextPaymentDate, item.Value, item.ClientSector);                        

                        itemClassificacao.Categoria = resultadoCategoria;
                        itemClassificacao.DataReferencia = dtReferencia;
                        itemClassificacao.Value = item.Value;
                        itemClassificacao.ClientSector = item.ClientSector;
                        itemClassificacao.NextPaymentDate = item.NextPaymentDate;

                        resultadoClassificacao += "\n";
                        resultadoClassificacao += itemClassificacao.Categoria + " - " +
                                                  "Operação: " +
                                                  itemClassificacao.Value + " " +
                                                  itemClassificacao.ClientSector + " " +
                                                  itemClassificacao.NextPaymentDate.ToString("MM/dd/yyyy");
                    }

                    Console.Write("\nRESULTADO DA CLASSIFICAÇÃO:\n");
                    Console.Write(resultadoClassificacao + "\n");
                    Console.ReadKey();
                }
            }                            
        }

        private static string VerificaCategoria(DateTime dtReferencia, DateTime NextPaymentDate, double Value, string ClientSector)
        {
            var categoriasJson = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\categoria.json");
            var categorias = JsonConvert.DeserializeObject<List<Categoria>>(categoriasJson);

            foreach (var categoria in categorias)
            {
                //pagamento atrasado
                if (NextPaymentDate.AddDays(categoria.Atraso) < dtReferencia)
                    return categoria.DescricaoCategoria;

                // valor superior e setor específico
                if (Value > categoria.ValorAcimaDe && ClientSector == categoria.Setor)
                    return categoria.DescricaoCategoria;

                //valor menor ou igual e setor específico
                if (Value <= categoria.ValorAcimaDe && ClientSector == categoria.Setor)
                    return categoria.DescricaoCategoria;
            }

            // categoria não definida
            return "UNDEFINED";
        }
    }
}