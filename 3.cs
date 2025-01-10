/*

3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
• O menor valor de faturamento ocorrido em um dia do mês;
• O maior valor de faturamento ocorrido em um dia do mês;
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

IMPORTANTE:
a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;
*/

using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

public class Programa
{
    public class DadosFaturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    public static void Main()
    {
        Console.WriteLine("Analisando dados do XML:");
        var dadosXml = LerDadosXml("dados (2).xml");
        AnalisarFaturamento(dadosXml);

        Console.WriteLine("\nAnalisando dados do JSON:");
        var dadosJson = LerDadosJson("dados.json");
        AnalisarFaturamento(dadosJson);
    }

    private static List<DadosFaturamento> LerDadosXml(string nomeArquivo)
    {
        var documento = XDocument.Load(nomeArquivo);
        return documento.Descendants("row")
            .Select(linha => new DadosFaturamento
            {
                Dia = int.Parse(linha.Element("dia").Value),
                Valor = double.Parse(linha.Element("valor").Value.Replace(".", ","))
            })
            .ToList();
    }

    private static List<DadosFaturamento> LerDadosJson(string nomeArquivo)
    {
        string textoJson = File.ReadAllText(nomeArquivo);
        return JsonSerializer.Deserialize<List<DadosFaturamento>>(textoJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    private static void AnalisarFaturamento(List<DadosFaturamento> dadosFaturamento)
    {
        var diasComFaturamento = dadosFaturamento.Where(d => d.Valor > 0).ToList();

        var menorFaturamento = diasComFaturamento.Min(d => d.Valor);
        var diaMenorFaturamento = diasComFaturamento.First(d => d.Valor == menorFaturamento).Dia;
        Console.WriteLine($"Menor faturamento: R$ {menorFaturamento:F2} (Dia {diaMenorFaturamento})");

        var maiorFaturamento = diasComFaturamento.Max(d => d.Valor);
        var diaMaiorFaturamento = diasComFaturamento.First(d => d.Valor == maiorFaturamento).Dia;
        Console.WriteLine($"Maior faturamento: R$ {maiorFaturamento:F2} (Dia {diaMaiorFaturamento})");

        var mediaMensal = diasComFaturamento.Average(d => d.Valor);
        Console.WriteLine($"Média mensal: R$ {mediaMensal:F2}");

        var diasAcimaMedia = diasComFaturamento.Count(d => d.Valor > mediaMensal);
        Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");

        Console.WriteLine($"Total de dias com faturamento: {diasComFaturamento.Count}");
        Console.WriteLine($"Total de dias sem faturamento: {dadosFaturamento.Count - diasComFaturamento.Count}");
    }
}