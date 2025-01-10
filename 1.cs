// 1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
// Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
// Imprimir(SOMA);
// Ao final do processamento, qual será o valor da variável SOMA?

class Program
{
    static void Main()
    {
        int INDICE = 13;
        int SOMA = 0;
        int K = 0;

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine($"O valor final da soma é: {SOMA}");
    }
}

// 2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

// IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um número para verificar se pertence à sequência de Fibonacci:");
        int numero = Convert.ToInt32(Console.ReadLine());

        if (PertenceSequenciaFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci!");
        }
        else
        {
            Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci!");
        }
    }

    static bool PertenceSequenciaFibonacci(int numero)
    {
        if (numero == 0 || numero == 1)
            return true;

        int anterior = 0;
        int atual = 1;

        while (atual <= numero)
        {
            if (atual == numero)
                return true;

            int proximo = anterior + atual;
            anterior = atual;
            atual = proximo;
        }

        return false;
    }
}

// 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
// • O menor valor de faturamento ocorrido em um dia do mês;
// • O maior valor de faturamento ocorrido em um dia do mês;
// • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

// IMPORTANTE:
// a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
// b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;

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

// 4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
// • SP – R$67.836,43
// • RJ – R$36.678,66
// • MG – R$29.229,88
// • ES – R$27.165,48
// • Outros – R$19.849,53

// Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  

using System;

class Program
{
    static void Main()
    {
        Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double>
        {
            {"SP", 67836.43},
            {"RJ", 36678.66},
            {"MG", 29229.88},
            {"ES", 27165.48},
            {"Outros", 19849.53}
        };

        double valorTotal = faturamentoPorEstado.Values.Sum();

        Console.WriteLine("Percentual de representação por estado:");
        Console.WriteLine("=====================================");

        foreach (var estado in faturamentoPorEstado)
        {
            double percentual = (estado.Value / valorTotal) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }

        Console.WriteLine($"\nValor total do faturamento: R${valorTotal:F2}");
    }
}

// 5) Escreva um programa que inverta os caracteres de um string.

// IMPORTANTE:
// a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
// b) Evite usar funções prontas, como, por exemplo, reverse;

using System;

class Program
{
    static string InverterString(string texto)
    {
        char[] caracteres = new char[texto.Length];
        
        for (int i = 0; i < texto.Length; i++)
        {
            caracteres[i] = texto[texto.Length - 1 - i];
        }
        
        return new string(caracteres);
    }

    static void Main()
    {
        Console.WriteLine("Digite um texto para ser invertido:");
        string textoOriginal = Console.ReadLine();

        string textoInvertido = InverterString(textoOriginal);

        Console.WriteLine("\nTexto original: " + textoOriginal);
        Console.WriteLine("Texto invertido: " + textoInvertido);
    }
}