using System;

public class Nodo
{
    public int ID { get; set; }
    public string Dato { get; set; } = string.Empty;
    public Nodo? HijoIzquierdo { get; set; }
    public Nodo? HijoDerecho { get; set; }

    public Nodo(int id, string dato)
    {
        ID = id;
        Dato = dato;
    }
}

class Program
{
    public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
    {
        if (raiz == null)
            return nuevoNodo;

        if (nuevoNodo.ID < raiz.ID)
        {
            raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
        }
        else if (nuevoNodo.ID > raiz.ID)
        {
            raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
        }

        return raiz;
    }

    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        if (raiz == null)
            return null;

        if (idTarget == raiz.ID)
            return raiz.Dato;

        if (idTarget < raiz.ID)
            return BuscarNodo(raiz.HijoIzquierdo, idTarget);
        else
            return BuscarNodo(raiz.HijoDerecho, idTarget);
    }

    static void Main()
    {
        Nodo? raiz = null;

        int[] idsAInsertar = { 10, 5, 15, 3, 7, 12, 20 };
        string[] datos = { "Raíz", "Izquierda", "Derecha", "Hoja A", "Hoja B", "Hoja C", "Hoja D" };

        Console.WriteLine("=== Insertando nodos en el árbol ===");
        for (int i = 0; i < idsAInsertar.Length; i++)
        {
            raiz = InsertarNodo(raiz, new Nodo(idsAInsertar[i], datos[i]));
            Console.WriteLine($"Insertado: ID={idsAInsertar[i]}, Dato={datos[i]}");
        }

        Console.WriteLine("\n=== Buscando nodos ===");
        int[] busquedas = { 7, 20, 99 };
        foreach (int id in busquedas)
        {
            string? resultado = BuscarNodo(raiz, id);
            Console.WriteLine(resultado != null
                ? $"ID {id} encontrado: {resultado}"
                : $"ID {id} no encontrado en el árbol.");
        }

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
