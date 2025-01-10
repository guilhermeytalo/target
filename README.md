# Teste Técnico

Este repositório contém a resolução de um teste técnico utilizando a linguagem **C#**. Cada questão proposta foi resolvida com o foco em eficiência e clareza de código.

## Estrutura do Repositório

- `1.cs`: Solução para o cálculo da variável `SOMA` no trecho de código fornecido.
- `2.cs`: Implementação de um programa que verifica se um número pertence à sequência de Fibonacci.
- `3.cs`: Análise de faturamento diário de uma distribuidora, calculando:
  - Menor valor de faturamento;
  - Maior valor de faturamento;
  - Número de dias com faturamento acima da média mensal.
- `4.cs`: Cálculo do percentual de representação de cada estado dentro do faturamento mensal de uma distribuidora.
- `5.cs`: Programa para inverter os caracteres de uma string sem o uso de funções prontas como `reverse`.

## Tecnologias Utilizadas

- Linguagem: **C#**
- Ferramentas e bibliotecas adicionais:
  - `.NET Core` para execução do código.

## Como Executar

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone este repositório:
   ```bash
   git clone https://github.com/guilhermeytalo/target.git
   ```
3. Navegue até a pasta do projeto.
4. Para executar cada arquivo, utilize o comando:
   ```bash
   dotnet run --project <caminho-do-arquivo>
   ```

### Executando o Exercício 3

O arquivo `3.cs` analisa dados de faturamento diário a partir de arquivos XML e JSON. Para executá-lo:

1. Certifique-se de que os arquivos `dados (2).xml` e `dados.json` estejam presentes no diretório de execução(podem ser encontrado na pasta `assets`).
2. Utilize o comando:
   ```bash
   dotnet run --project 3.cs
   ```
3. O programa exibirá as análises no console, incluindo menor e maior faturamento, média mensal, e número de dias acima da média.

## Contato

Se tiver dúvidas ou sugestões, sinta-se à vontade para entrar em contato:
- **E-mail**: contatoguilhermeytalo@outlook.com
- **LinkedIn**: [Guilherme Ytalo](https://linkedin.com/in/guilhermeytalo)
