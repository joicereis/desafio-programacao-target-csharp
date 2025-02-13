using System;

public class Program
{
    public static void Main(string[] args)
    {
        Desafio1_Soma();
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
}