using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio1 {

    class Ejercicio1Test {
        

        static void Main(string[] args) {

           Ejercicio1A();
           Ejercicio1B();
           Ejercicio1C();
           Ejercicio1D();
           Ejercicio1E();

        }

        public static void Ejercicio1A() {

            Console.WriteLine("\nEjercicio 1-A");
            Console.WriteLine("\nIngrese Nombre");
            String nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            String apellido = Console.ReadLine();
            Console.WriteLine($"El nombre completo es {nombre} {apellido}");
            Console.WriteLine("\n\n");

        }

        public static void Ejercicio1B() {

            Console.WriteLine("\nEjercicio 1-B");
            Console.WriteLine("\nIngrese Nombre");
            String nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Edad");
            int edad = int.Parse(Console.ReadLine());

            if (edad >= 18) {
                Console.WriteLine("Es mayor de edad");
            } else {
                Console.WriteLine("No es mayor de edad");
            }
            Console.WriteLine("\n\n");
        }

        public static void Ejercicio1C() {
            Console.WriteLine("\nEjercicio 1-C");

            var lista = new List<int>();
            int valor1 = 1;
            int valorfinal = 0;
            int i = 0;

            while (valor1 != 0) {
                Console.WriteLine("\nPasame un valor\nIntroduzca 0 para terminar el programa");
                valor1 = int.Parse(Console.ReadLine());
                if (valor1 != 0)
                    lista.Add(valor1);
                int resultado = lista.Sum(x => Convert.ToInt32(x));
                valorfinal = resultado; 
                if (valor1 == 0) {
                    Console.WriteLine("El resultado es: " + valorfinal);
                    Console.ReadKey();
                }
            }


        }

        public static void Ejercicio1D() {

            Console.WriteLine("\nEjercicio 1-D");

            Console.WriteLine("Ingrese numero 1");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese numero 2");
            int num2 = int.Parse(Console.ReadLine());
            
            for(int k = num1; k > 0; k--) {
                if (num1 % k == 0 && num2 % k == 0) {
                    Console.WriteLine($"El maximo comun divisor es {k}");
                    k = 0;
                }
            }
            Console.WriteLine("\n\n");

        }

        public static void Ejercicio1E() {
            Console.WriteLine("\nEjercicio 1-E");

            int c = 0;
            int tot = 0;
            Console.WriteLine("\nIngrese numero");
            int num = int.Parse(Console.ReadLine());
            while (num != 0) {
                c++;
                Console.WriteLine("\nIngrese nuevo numero\nIntroduzca 0 para terminar el programa");
                tot += num;
                num = int.Parse(Console.ReadLine());
            }

            double promedio = tot / c;
            Console.WriteLine($"El promedio de los numeros ingresados es :{promedio}");
            Console.WriteLine("\n\n");

        }

    }
}


