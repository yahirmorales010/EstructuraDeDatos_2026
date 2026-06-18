using System;
using System.Collections.Generic;
using System.Linq;

class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(int id, string nombre, double precio, int cantidad)
    {
        ID = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    public override string ToString()
    {
        return $"[{ID}] {Nombre} - ${Precio:F2} | Stock: {Cantidad}";
    }
}

class Program
{
    static void MostrarTodos(List<Producto> inventario)
    {
        Console.WriteLine("\n Inventario Completo ");
        foreach (var p in inventario)
            Console.WriteLine(p);
    }

    static void MostrarPorPrecio(List<Producto> inventario)
    {
        Console.WriteLine("\n=== Productos por Precio (Mayor a Menor) ===");
        var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
        foreach (var p in porPrecio)
            Console.WriteLine(p);
    }

    static void MostrarAgotados(List<Producto> inventario)
    {
        Console.WriteLine("\n=== Productos Agotados ===");
        var agotados = inventario.Where(p => p.Cantidad == 0).ToList();
        if (agotados.Count == 0)
            Console.WriteLine("Sin productos agotados.");
        else
            agotados.ForEach(p => Console.WriteLine(p));
    }

    static void BuscarPorID(Dictionary<int, Producto> catalogo)
    {
        Console.Write("\nIngresa el ID del producto a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int idBuscado))
        {
            if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
                Console.WriteLine($"Producto encontrado: {encontrado}");
            else
                Console.WriteLine("Producto no encontrado.");
        }
        else
        {
            Console.WriteLine("ID no válido.");
        }
    }

    static void Main()
    {
        List<Producto> inventario = new List<Producto>
        {
            new Producto(1, "Laptop Lenovo",    15999.00, 10),
            new Producto(2, "Mouse Inalámbrico",  349.00, 25),
            new Producto(3, "Teclado Mecánico",   899.00,  0),
            new Producto(4, "Monitor 24\"",       4500.00,  5),
            new Producto(5, "Audífonos Sony",    1200.00,  0)
        };

        inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

        var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
        inventario.Add(otroProducto);

        Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

        Console.WriteLine($"Total en inventario: {inventario.Count} productos");

        MostrarTodos(inventario);
        MostrarPorPrecio(inventario);
        MostrarAgotados(inventario);
        BuscarPorID(catalogo);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}