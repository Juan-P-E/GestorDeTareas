using System;
using System.Collections.Generic;
using System.IO;         // Para leer y escribir archivos
using System.Text.Json;  // Para convertir objetos a JSON y viceversa

class Program
{
    // Lista para almacenar las tareas
    static List<Tarea> tareas = new();

    class Tarea
    {
        public string Texto { get; set; } = "";
    }


    static void Main()
    {
        CargarTareas();

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
            tareas.Add(new Tarea { Texto = tarea });
            GuardarTareas();

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
                Console.WriteLine($"{i + 1}. {tareas[i].Texto}");

            }
        }
        Console.ReadKey();
    }

    static void GuardarTareas()
    {
        string json = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("tareas.json", json);
    }

    static void CargarTareas()
    {
        if (File.Exists("tareas.json"))
        {
            string json = File.ReadAllText("tareas.json");
            tareas = JsonSerializer.Deserialize<List<Tarea>>(json) ?? new List<Tarea>();
        }
    }

    static void EliminarTarea()
    {
        VerTareas();
        Console.Write("Número de tarea a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= tareas.Count)
        {
            tareas.RemoveAt(num - 1); GuardarTareas();

            Console.WriteLine("Tarea eliminada!");
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }
        Console.ReadKey();
    }
}
