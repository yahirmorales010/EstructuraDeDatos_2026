using System;

class SimuladorStack
{
    public static void ImprimirCuentaRegresiva(int numero)
    {
        if (numero < 1)
        {
            Console.WriteLine("¡Despegue!");
            return;
        }

        Console.WriteLine($"[APILANDO] {numero}");
        ImprimirCuentaRegresiva(numero - 1);
        Console.WriteLine($"[LIBERANDO] {numero}");
    }

    public static int SumarHasta(int n)
    {
        if (n == 1)
            return 1;
            
        return n + SumarHasta(n - 1);
    }
}

class Program
{
    static void Main()
    {
        SimuladorStack.ImprimirCuentaRegresiva(3);

        Console.Write("\nIntroduce un número positivo: ");
        string entrada = Console.ReadLine();
        
        if (int.TryParse(entrada, out int numero) && numero > 0)
        {
            int resultado = SimuladorStack.SumarHasta(numero);
            Console.WriteLine($"La suma de 1 hasta {numero} es: {resultado}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Solo se aceptan enteros positivos.");
            Console.ResetColor();
        }
    }
}