using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\nDesafio 1");
        Desafio1_Soma();
        Console.WriteLine("\nDesafio 2");
        Desafio2_Fibonacci();
        Console.WriteLine("\nDesafio 3");
        Desafio3_Faturamento();
        Console.WriteLine("\nDesafio 4");
        Desafio4_Porcentagem();
        Console.WriteLine("\nDesafio 5");
        Desafio5_InvertePalavras();
    }

    //Desafio 1:
    private static void Desafio1_Soma()
    {
        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        { 
            K = K + 1;
            SOMA = SOMA + K;
        }
        Console.WriteLine(SOMA);
    }

    //Desafio 2:
    private static void Desafio2_Fibonacci()
    {
        try
        {
            Console.WriteLine("Digite um número inteiro para verificar se pertence à sequencia de Fibonacci");
            int nroDigitado = int.Parse(Console.ReadLine());

            bool nroFibonacci = VerificaNumeroFibonacci(nroDigitado);
            Console.WriteLine(nroFibonacci ? $"O {nroDigitado} pertence à sequência de Fibonacci." : $"O {nroDigitado} não pertence à sequência de Fibonacci.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Por favor, informe um número inteiro.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
        }
        }

    private static bool VerificaNumeroFibonacci(int nroDigitado)
    {
        int primeiroNro = 0, segundoNro = 1;
        if (nroDigitado == primeiroNro || nroDigitado == segundoNro)
        {
            return true;
        }
        while(segundoNro < nroDigitado)
        {
            int auxiliar = segundoNro;
            segundoNro = primeiroNro + segundoNro;
            primeiroNro = auxiliar;
        }
        if(segundoNro == nroDigitado)
            return true;
        else
            return false;
    }

    //Desafio 3:
    private static void Desafio3_Faturamento()
    {
        double[] faturamentoDiario;

        try
        {
            string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dadosFaturamento.json");
            string json = File.ReadAllText(caminhoArquivo);
            var dados = JsonConvert.DeserializeObject<Dictionary<string, double[]>>(json);

            if (dados != null && dados.ContainsKey("faturamentoDiario"))
            {
                faturamentoDiario = dados["faturamentoDiario"];
            }
            else
            {
                Console.WriteLine("Erro: Estrutura do JSON inválida.");
                return;
            }

            double menorValorFaturamento = double.MaxValue;
            double maiorValorFaturamento = double.MinValue;
            double totalFaturamento = 0;
            int diasComFaturamento = 0;
            int diasAcimaMedia = 0;

            foreach (var faturamento in faturamentoDiario)
            {
                if (faturamento > 0)
                {
                    if (faturamento < menorValorFaturamento)
                    {
                        menorValorFaturamento = faturamento;
                    }

                    if (faturamento > maiorValorFaturamento)
                    {
                        maiorValorFaturamento = faturamento;
                    }

                    totalFaturamento += faturamento;
                    diasComFaturamento++;
                }
            }

            if (diasComFaturamento == 0)
            {
                Console.WriteLine("Não há dias com faturamento para calcular a média.");
                return;
            }

            double mediaFaturamento = totalFaturamento / diasComFaturamento;

            foreach (var faturamento in faturamentoDiario)
            {
                if (faturamento > mediaFaturamento)
                {
                    diasAcimaMedia++;
                }
            }

            Console.WriteLine($"Menor faturamento: R${menorValorFaturamento:F2}");
            Console.WriteLine($"Maior faturamento: R${maiorValorFaturamento:F2}");
            Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar o arquivo JSON: {ex.Message}");
        }
    }

    //Desafio 4:
    private static void Desafio4_Porcentagem()
    {
        double faturamentoSP = 67836.43;
        double faturamentoRJ = 36678.66;
        double faturamentoMG = 29229.88;
        double faturamentoES = 27165.48;
        double faturamentoOutros = 19849.53;

        double faturamentoTotal = faturamentoSP + faturamentoRJ + faturamentoMG + faturamentoES + faturamentoOutros;

        Console.WriteLine("Percentual de representação de cada estado:");
        Console.WriteLine($"SP: {((faturamentoSP / faturamentoTotal) * 100):F2}%");
        Console.WriteLine($"RJ: {((faturamentoRJ / faturamentoTotal) * 100):F2}%");
        Console.WriteLine($"MG: {((faturamentoMG / faturamentoTotal) * 100):F2}%");
        Console.WriteLine($"ES: {((faturamentoES / faturamentoTotal) * 100):F2}%");
        Console.WriteLine($"Outros: {((faturamentoOutros / faturamentoTotal) * 100):F2}%");
    }

    //Desafio 5:
    private static void Desafio5_InvertePalavras()
    {
        Console.WriteLine("Informe uma palavra ou frase para ser escrita de forma invertida:");
        string stringDigitada = Console.ReadLine();
        string stringInvertida = "";

        for (int i = stringDigitada.Length - 1; i >= 0; i--)
        {
            stringInvertida += stringDigitada[i];
        }

        Console.WriteLine($"Frase original: {stringDigitada}");
        Console.WriteLine($"Frase invertida: {stringInvertida}");
    }

}
