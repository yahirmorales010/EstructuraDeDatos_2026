using System;

class Program
{
    struct Poligono
    {
        public int Lados;
        public string Nombre;
        public double Lado;
        public double Apotema;
        public double Area;
    }

    static int SeleccionarPoligono()
    {
        int opciones;
        Console.WriteLine("Selecciona un polígono:");
        Console.WriteLine("1. Triángulo  (3 lados)");
        Console.WriteLine("2. Cuadrado   (4 lados)");
        Console.WriteLine("3. Pentágono  (5 lados)");
        Console.WriteLine("4. Hexágono   (6 lados)");
        Console.WriteLine("5. Heptágono  (7 lados)");
        Console.WriteLine("6. Octágono   (8 lados)");
        Console.Write("Elige una opción (1-6): ");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out opciones) && opciones >= 1 && opciones <= 6)
                break;
            Console.Write("Ingresa una opción válida: ");
        }

        int[] tabLados = { 3, 4, 5, 6, 7, 8 };
        return tabLados[opciones - 1];
    }

    static string ObtenerNombre(int lados)
    {
        switch (lados)
        {
            case 3: return "Triángulo";
            case 4: return "Cuadrado";
            case 5: return "Pentágono";
            case 6: return "Hexágono";
            case 7: return "Heptágono";
            case 8: return "Octágono";
            default: return "Desconocido";
        }
    }

    static void PedirDatos(ref Poligono figura)
    {
        Console.Write("Ingresa la medida del lado: ");
        while (!double.TryParse(Console.ReadLine(), out figura.Lado) || figura.Lado <= 0)
            Console.Write("Ingresa un valor positivo: ");

        Console.Write("Ingresa la apotema: ");
        while (!double.TryParse(Console.ReadLine(), out figura.Apotema) || figura.Apotema <= 0)
            Console.Write("Ingresa un valor positivo: ");
    }

    static double CalcularArea(Poligono figura)
    {
        return (figura.Lados * figura.Lado * figura.Apotema) / 2;
    }

    static void MostrarResultado(Poligono figura)
    {
        Console.WriteLine($"\n--- Resultado ---");
        Console.WriteLine($"Figura: {figura.Nombre}");
        Console.WriteLine($"Lado: {figura.Lado}");
        Console.WriteLine($"Apotema: {figura.Apotema}");
        Console.WriteLine($"Área: {figura.Area:F2}\n");
    }

    static void Main()
    {
        char repetir;
        do
        {
            Poligono figura = new Poligono();
            figura.Lados = SeleccionarPoligono();
            figura.Nombre = ObtenerNombre(figura.Lados);
            PedirDatos(ref figura);
            figura.Area = CalcularArea(figura);
            MostrarResultado(figura);

            Console.Write("\n¿Deseas calcular otro polígono? (s/n): ");
            string entrada = Console.ReadLine();
            repetir = string.IsNullOrEmpty(entrada) ? 'n' : entrada[0];

        } while (repetir == 's' || repetir == 'S');
    }
}