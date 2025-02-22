using System;
using System.Collections.Generic;

class Estudiante
{
    public string Nombre { get; set; }
    public double Calificacion { get; set; }

    public Estudiante(string nombre, double calificacion)
    {
        Nombre = nombre;
        Calificacion = calificacion;
    }
}

class Program
{
    static List<Estudiante> estudiantes = new List<Estudiante>();

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");

        while (true)
        {
            MostrarMenu();
            int opcion = LeerOpcion();

            switch (opcion)
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    MostrarListaEstudiantes();
                    break;
                case 3:
                    CalcularPromedioCalificaciones();
                    break;
                case 4:
                    MostrarEstudianteConMaximaCalificacion();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n1. Agregar estudiante");
        Console.WriteLine("2. Mostrar lista de estudiantes");
        Console.WriteLine("3. Calcular promedio de calificaciones");
        Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static int LeerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número entre 1 y 5.");
            Console.Write("Seleccione una opción: ");
        }
        return opcion;
    }

    static void AgregarEstudiante()
    {
        Console.Write("Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine();

        double calificacion;
        Console.Write("Ingrese la calificación del estudiante: ");
        while (!double.TryParse(Console.ReadLine(), out calificacion) || calificacion < 0 || calificacion > 100)
        {
            Console.WriteLine("Calificación no válida. Debe ser un número entre 0 y 100.");
            Console.Write("Ingrese la calificación del estudiante: ");
        }

        estudiantes.Add(new Estudiante(nombre, calificacion));
        Console.WriteLine("Estudiante agregado correctamente.");
    }

    static void MostrarListaEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("\nLista de estudiantes:");
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine($"{estudiante.Nombre} - Calificación: {estudiante.Calificacion:F2}");
            }
        }
    }

    static void CalcularPromedioCalificaciones()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double suma = 0;
            foreach (var estudiante in estudiantes)
            {
                suma += estudiante.Calificacion;
            }
            double promedio = suma / estudiantes.Count;
            Console.WriteLine($"El promedio de calificaciones es: {promedio:F2}");
        }
    }

    static void MostrarEstudianteConMaximaCalificacion()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            Estudiante estudianteMax = estudiantes[0];
            foreach (var estudiante in estudiantes)
            {
                if (estudiante.Calificacion > estudianteMax.Calificacion)
                {
                    estudianteMax = estudiante;
                }
            }
            Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax.Nombre} con {estudianteMax.Calificacion:F2}");
        }
    }
}