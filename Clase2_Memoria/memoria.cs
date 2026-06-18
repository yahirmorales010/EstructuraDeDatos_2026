using System;

class Program
{
    static void CambiarValor(int x)
    {
        x = 100;
        Console.WriteLine($"  Dentro de CambiarValor: x = {x}");
    }

    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100;
        Console.WriteLine($"  Dentro de CambiarReferencia: arr[0] = {arr[0]}");
    }

    static void Main()
    {
        Console.WriteLine("=== DEMOSTRACIÓN: STACK vs HEAP ===\n");

        Console.WriteLine("-- Value Type (int) --");
        int numero = 10;
        Console.WriteLine($"Antes: numero = {numero}");
        CambiarValor(numero);
        Console.WriteLine($"Después: numero = {numero}\n");

        Console.WriteLine("-- Reference Type (int[]) --");
        int[] arreglo = { 10, 20, 30 };
        Console.WriteLine($"Antes: arreglo[0] = {arreglo[0]}");
        CambiarReferencia(arreglo);
        Console.WriteLine($"Después: arreglo[0] = {arreglo[0]}\n");

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}