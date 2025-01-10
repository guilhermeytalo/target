/* 
5) Escreva um programa que inverta os caracteres de um string.
IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;
*/

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