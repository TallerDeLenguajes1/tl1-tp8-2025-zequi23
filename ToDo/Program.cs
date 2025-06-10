// See https://aka.ms/new-console-template for more information
using ListaTareas;


 List<Tarea> tareasPendientes = new List<Tarea>();
 List<Tarea> tareasRealizadas = new List<Tarea>();

 bool salir = false;

while (!salir)
{
    Console.WriteLine("\n===== MENU PRINCIPAL =====");
    Console.WriteLine("1. Crear tareas aleatorias.");
    Console.WriteLine("2. Mostrar tareas pendientes.");
    Console.WriteLine("3. Mover tareas pendientes a realizadas.");
    Console.WriteLine("4. Mostrar tareas realizadas.");
    Console.WriteLine("5. Mostrar todas las tareas.");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opcion: ");

    string opcion = Console.ReadLine();
    Console.WriteLine();
    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese la cantidad de tareas a crear: ");
            if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
            {
                GestorTareas.CrearTareasAleatorias(tareasPendientes, cantidad);
                Console.WriteLine("Tareas creadas exitosamente.");
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            break;

        case "2":
            GestorTareas.MostrarTareas(tareasPendientes, "Tareas Pendientes");
            break;

        case "3":
            GestorTareas.PasajeLista(tareasPendientes, tareasRealizadas);
            break;

        case "4":
            GestorTareas.MostrarTareas(tareasRealizadas, "Tareas Realizadas");
            break;

        case "5":
            GestorTareas.MostrarTareas(tareasPendientes, "Tareas Pendientes");
            GestorTareas.MostrarTareas(tareasRealizadas, "Tareas Realizadas");
            break;

        case "6":
            salir = true;
            Console.WriteLine("Saliendo");
            break;

        default:
            Console.WriteLine("Opción invalida. Intente nuevamente.");
            break;
    }
}