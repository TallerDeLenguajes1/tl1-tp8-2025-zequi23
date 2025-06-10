
namespace ListaTareas
{
    // Clase Tarea proporcionada.
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }

        // Campo privado para almacenar la duración.
        private int duracion;

        // Propiedad con validación en el setter.
        public int Duracion
        {
            get { return duracion; }
            set
            {
                if (value < 10 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Duracion), "La duración debe estar entre 10 y 100.");
                duracion = value;
            }
        }

        public Tarea(int tareaID, string descripcion, int duracion)
        {
            TareaID = tareaID;
            Descripcion = descripcion;
            Duracion = duracion; // Se aplicará la validación en el setter.
        }

        // Método auxiliar para mostrar detalles de la tarea.
        public string MostrarTarea()
        {
            return $"[ID: {TareaID}] {Descripcion} - Duración: {Duracion}";
        }
    }


    public class GestorTareas
    {

        /// Recorre la lista de tareas pendientes y permite mover cada tarea a la lista de realizadas.
        /// Se pregunta por cada tarea si fue completada; si el usuario ingresa 1 se mueve la tarea.

        /// <param name="pendientes">Lista de tareas pendientes</param>
        /// <param name="realizadas">Lista de tareas realizadas</param>
        public static void PasajeLista(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            if (pendientes.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes para mover.");
                return;
            }


            int i = 0;
            while (i < pendientes.Count)
            {
                Console.WriteLine();
                Console.WriteLine(pendientes[i].MostrarTarea());
                Console.Write("¿Realizoe sta tarea? (si:1, no:0): ");

                if (!int.TryParse(Console.ReadLine(), out int realizado))
                {
                    Console.WriteLine("Entrada invalida. Se considerara como 'no'.");
                    realizado = 0;
                }


                if (realizado == 1)
                {
                    Tarea tarea = pendientes[i];
                    pendientes.RemoveAt(i);
                    realizadas.Add(tarea);
                    Console.WriteLine("La tarea se movio a realizadas.");
                    // No incrementamos i porque se eliminó el elemento actual
                }
                else
                {
                    i++;
                }
            }
        }



        public static void MostrarTareas(List<Tarea> lista, string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay tareas para mostrar.");
                return;
            }

            foreach (var tarea in lista)
                Console.WriteLine(tarea.MostrarTarea());
        }

        public static void CrearTareasAleatorias(List<Tarea> pendientes, int cantidad)
        {
            Random rand = new Random();
            for (int i = 1; i <= cantidad; i++)
            {
                // Se crea una tarea con duración aleatoria entre 10 y 100 y una descripcion
                int duracion = rand.Next(10, 101); // limite superior exclusivo
                string descripcion = $"Tarea generada {i}";
                pendientes.Add(new Tarea(i, descripcion, duracion));
            }
        }

        
        public static void BuscarEnPendientes(List<Tarea> pendientes, string clave)
        {
            bool encontrado = false;
            Console.WriteLine("\nPendientes que contienen '" + clave + "':");

            
            foreach (Tarea tarea in pendientes)
            {
                // Se utiliza IndexOf para realizar una búsqueda insensible a mayúsculas/minúsculas
                if (tarea.Descripcion.IndexOf(clave, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(tarea.MostrarTarea());
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("  Ninguna.");
            }
        }
    }
}