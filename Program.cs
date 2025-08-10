using System;
using System.Collections.Generic;

class Program
{
    // Lista para almacenar las tareas
    static List<string> tareas = new();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== GESTOR DE TAREAS ====");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Ver tareas");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    VerTareas();
                    break;
                case "3":
                    EliminarTarea();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción inválida. Presiona una tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AgregarTarea()
    {
        Console.Write("Escribe la nueva tarea: ");
        string? tarea = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(tarea))
        {
            tareas.Add(tarea);
            Console.WriteLine("Tarea agregada!");
        }
        else
        {
            Console.WriteLine("No se puede agregar una tarea vacía.");
        }
        Console.ReadKey();
    }

    static void VerTareas()
    {
        Console.WriteLine("=== Lista de Tareas ===");
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas.");
        }
        else
        {
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }
        Console.ReadKey();
    }

    static void EliminarTarea()
    {
        VerTareas();
        Console.Write("Número de tarea a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= tareas.Count)
        {
            tareas.RemoveAt(num - 1);
            Console.WriteLine("Tarea eliminada!");
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }
        Console.ReadKey();
    }
}
