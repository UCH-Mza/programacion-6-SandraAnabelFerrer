/*
    using System;
    using System.Threading.Tasks;

    class Ejercicio1
    {
        static void Main(string[] arg)
        {
            var h = new Task(() =>
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine($"Hilo 1: Número {i}");
                }
            });

            var j = new Task(() =>
            {
                int numero = 15;
                while (numero >= 0)
                {
                    Console.WriteLine($"Número decreciente: {numero}");
                    numero--;
                }
            });

            var k = new Task(() =>
            {
                for (int i = 10; i <= 20; i += 2) // Corregido el operador +=
                {
                    Console.WriteLine($"Numeros Pares: {i}");
                }
            });

            var l = new Task(() =>
            {
                int suma = 0;
                for (int i = 1; i <= 10; i++)
                {
                    suma += i;
                }
                Console.WriteLine($"Suma de los primeros numeros naturales: {suma}");
            });

            var m = new Task(() =>
            {
                int[] numeros = { 3, 6, 9, 12, 15 };
                foreach (int numero in numeros)
                {
                    Console.WriteLine($"Numeros divisibles por 3: {numero}");
                }
            });

            var n = new Task(() =>
            {
                string[] frutas = { "Manzana", "Naranja", "Frutillas", "Peras" };
                foreach (string fruta in frutas)
                {
                    Console.WriteLine($"Frutas: {fruta}");
                }
            });

            h.Start();
            j.Start();
            k.Start();
            l.Start();
            m.Start();
            n.Start();

            Task.WaitAll(h, j, k, l, m, n);
        }
    }
*/

/*
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    class Ejercicio2
    {

        static void Main()
        {

            List<Task<int>> tareas = new List<Task<int>>();//crear una lista de tareas para almacenar numeros enteros

            for (int i = 0; i <= 10; i++)//bucle para crear 10 tareas
            {

                tareas.Add(GenerarYCalcularSumaAsync());//agregar en la tarea el metodo para generar num aleatorios y sumarlos
            }

            Task.WhenAll(tareas).Wait();//espera a que todas las tareas terminen para traer el rdo

            int[] resultado = tareas.Select(t => t.Result).ToArray();//selecciona los resultados de cada tarea y los convierte en un array

            Console.WriteLine($"Sumatoria de resultados individuales");

            for (int i = 0; i < resultado.Length; i++)// bucle para mostrar los rdos individuales de cada tarea
            {

                Console.WriteLine($"List{i + 1}:{resultado[i]}");//muestra el rdo actual de la tarea
            }
            //suma total de todos los resultados
            int sumatotal = resultado.Sum();
            Console.WriteLine($"Suma Total:{sumatotal}");

        }

        static async Task<int> GenerarYCalcularSumaAsync()//metodo que crea y suma numeros aleatorios
        {

            Random aleatorio = new Random();//metodo de creacion de num aleatorios
            List<int> numerosaleatorios = new List<int>();//se crea lista para los numeros aleatorios

            for (int i = 0; i < 1500; i++)//bucle para crear 1500 nros aleatorios
            {
                int numeroaleatorio = aleatorio.Next(501);//los numeros aleatorios van del 0 al 500
                numerosaleatorios.Add(numeroaleatorio);//agrega los num aleatorios a la lista
            }
            int suma = await

            CalcularSumaAsync(numerosaleatorios);//llamada para calular suma asincrona

            return suma;

        }

        static Task<int> CalcularSumaAsync(List<int> numeros)//metodo que calcula la suma de numeros de una lista(numerosaleatorios) de manera asincrona
        {

            return Task.Run(() =>//iniciar una tarea asincrona para realizar la suma
            {
                int suma = numeros.Sum();//calcular la suma de los numeros en la Lista(numeros)
                return suma;//devolver el rdo
            });
        }

    }
*/
/*
using System;
using System.Threading.Tasks;


    class ejercicio3
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Piedra, Papel o Tijeras!");

            Task<(string, string)> eleccionesJugadoresTarea = ObtenerEleccionesAleatorias();

            var (eleccionJugador1, eleccionJugador2) = await eleccionesJugadoresTarea;

            Console.WriteLine($"El Jugador 1 eligió: {eleccionJugador1}");
            Console.WriteLine($"El Jugador 2 eligió: {eleccionJugador2}");

            string resultado = DeterminarGanador(eleccionJugador1, eleccionJugador2);
            Console.WriteLine(resultado);
        }

        static async Task<(string, string)> ObtenerEleccionesAleatorias()
        {
            string[] opciones = { "piedra", "papel", "tijeras" };
            Random random = new Random();

            await Task.Delay(random.Next(1000, 3000)); 
            string eleccionJugador1 = opciones[random.Next(opciones.Length)];

            await Task.Delay(random.Next(1000, 3000)); 
            string eleccionJugador2 = opciones[random.Next(opciones.Length)];

            return (eleccionJugador1, eleccionJugador2);
        }

        static string DeterminarGanador(string eleccionJugador1, string eleccionJugador2)
        {
            if (eleccionJugador1 == eleccionJugador2)
            {
                return "¡Empate!";
            }
            else if ((eleccionJugador1 == "piedra" && eleccionJugador2 == "tijeras") ||
                     (eleccionJugador1 == "papel" && eleccionJugador2 == "piedra") ||
                     (eleccionJugador1 == "tijeras" && eleccionJugador2 == "papel"))
            {
                return "El Jugador 1 gana!";
            }
            else
            {
                return "El Jugador 2 gana!";
            }
        }
    }
*/
/*
using System;
using System.Threading.Tasks;


    class ejercicio4
    {
        static bool procesoCancelado = false;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando proceso...");

            // Iniciar una tarea para ejecutar el proceso principal de forma asincrónica
            Task procesoTarea = EjecutarProcesoAsync();

            // Iniciar una tarea para actualizar la barra de carga mientras el proceso se ejecuta
            Task barraCargaTarea = ActualizarBarraCargaAsync(procesoTarea);

            // Esperar a que ambas tareas se completen antes de continuar
            await Task.WhenAll(procesoTarea, barraCargaTarea);

            Console.WriteLine("Proceso completado.");
        }

        static async Task EjecutarProcesoAsync()
        {
            // Simula un proceso que toma tiempo
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000); // Esperar 1 segundo

                if (procesoCancelado)
                {
                    Console.WriteLine("Proceso cancelado.");
                    return; // Salir del método si el proceso es cancelado
                }
            }
        }

        static async Task ActualizarBarraCargaAsync(Task procesoTarea)
        {
            int barLength = 20; // Longitud de la barra de carga
            int porcentaje = 0;

            Console.WriteLine("Progreso:");
            while (!procesoTarea.IsCompleted)
            {
                Console.Write($"|{new string('-', porcentaje / (100 / barLength)).PadRight(barLength)}| {porcentaje}%\r");
                porcentaje += 10; // Incrementar el porcentaje en 10%
                await Task.Delay(1000); // Esperar 1 segundo antes de actualizar la barra de carga
            }
            Console.WriteLine();
        }

        static void CancelarProceso()
        {
            procesoCancelado = true; // Establecer la bandera de proceso cancelado como verdadera
        }
    }

*/



    



