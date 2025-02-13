using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main(string[] args)
    {
        Desafio1_Soma();
        Desafio2_Fibonacci();
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
}
