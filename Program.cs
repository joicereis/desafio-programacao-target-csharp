using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    //Desafio 1:
    public static void Main(string[] args)
    {
        Desafio1_Soma();
        Desafio2_Fibonacci();
        Desafio3_Faturamento();
    }

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
        var faturamentoDiario = new double[] { 4827.26, 5412.34, 5318.28, 0, 5746.82, 4823.58, 0, 4792.56, 5235.47, 0 };

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

        double mediaFaturamento = totalFaturamento / diasComFaturamento;

        foreach (var faturamento in faturamentoDiario)
        {
            if (faturamento > mediaFaturamento)
            {
                diasAcimaMedia++;
            }
        }

        Console.WriteLine($"Menor faturamento: R${menorValorFaturamento}");
        Console.WriteLine($"Maior faturamento: R${maiorValorFaturamento}");
        Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaMedia}");
    }



}
