/* 
4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
• SP – R$67.836,43
• RJ – R$36.678,66
• MG – R$29.229,88
• ES – R$27.165,48
• Outros – R$19.849,53
Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  
*/
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