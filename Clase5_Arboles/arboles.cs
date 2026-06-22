using System;

class Alumno
{
    public string Nombre { get; set; } = string.Empty;
}

class Program
{
    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static int CalcularYValidar(int dividendo, int divisor, out int residuo)
    {
        residuo = dividendo % divisor;
        return dividendo / divisor;
    }

    static void Main()
    {
        Console.WriteLine("=== Módulo 1: Intercambiar con ref ===");
        int x = 10, y = 25;
        Console.WriteLine($"Antes: x={x}, y={y}");
        Intercambiar(ref x, ref y);
        Console.WriteLine($"Después: x={x}, y={y}\n");

        Console.WriteLine("=== Módulo 2: CalcularYValidar con out ===");
        int cociente = CalcularYValidar(17, 5, out int resto);
        Console.WriteLine($"Cociente: {cociente}");
        Console.WriteLine($"Residuo: {resto}\n");

        Console.WriteLine("=== Módulo 3: Referencias de Objetos ===");
        Alumno alumno1 = new Alumno { Nombre = "Dany" };
        Alumno alumno2 = alumno1;

        Console.WriteLine($"Antes: alumno1.Nombre = {alumno1.Nombre}");
        alumno2.Nombre = "3Treum";
        Console.WriteLine($"Después de cambiar alumno2: alumno1.Nombre = {alumno1.Nombre}");
        Console.WriteLine("Ambas variables apuntan al mismo objeto en el Heap.\n");

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}