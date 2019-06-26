using System;

namespace Ejercicio2 {
    class Ejercicio2TEst {

        static void Main(string[] args) {


            Metodos[] figuras = new Metodos[3];
            Console.WriteLine("Ingrese area del circulo y luego el diametro");
            figuras[0]= new Circulo(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine("Ingrese lado 1 , lado 2 , lado 3 , base y altura del triangulo");
            figuras[1] = new Triangulo(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));//terrible constructor :L
            Console.WriteLine("Ingrese un lado del cuadrado");
            figuras[2] = new Cuadrado(double.Parse(Console.ReadLine()));

            foreach (Metodos elementos in figuras) {

                if (elementos is Circulo) {
                    Console.WriteLine($"El area del Circulo es de {elementos.CalcularArea()}\nEl perimetro es de : {elementos.CalcularPerimetro()}\n");
                }

                if(elementos is Triangulo) {
                    Console.WriteLine($"El area del Triangunlo es de {elementos.CalcularArea()}\nEl perimetro es de : {elementos.CalcularPerimetro()}\n");
                }

                if (elementos is Cuadrado) {
                    Console.WriteLine($"El area del Cuadrado es de {elementos.CalcularArea()}\nEl perimetro es de : {elementos.CalcularPerimetro()}\n");
                }

            }
        }
    }


    interface Metodos {

        double CalcularArea();

        double CalcularPerimetro();



    }


    class Circulo : Metodos {

        public double radio;
        public double diametro;


        public Circulo(double radio, double diametro) {
            this.radio = radio;
            this.diametro = diametro;
        }

        public double CalcularArea() {

            double PI = Math.PI;

            return PI * (this.radio *= this.radio);

        }
        public double CalcularPerimetro() {

            double PI = Math.PI;

            return PI * this.diametro;

        }


    }

    class Triangulo : Metodos {

        public double lado1, lado2, lado3, basee, altura;


        public Triangulo(double lado1, double lado2, double lado3, double basee, double altura) {
            this.lado1 = lado1;
            this.lado2 = lado2;
            this.lado3 = lado3;
            this.basee = basee;
            this.altura = altura;
        }

        public double CalcularArea() {

            return (basee * altura) / 2;

        }
        public double CalcularPerimetro() {

            return lado1 + lado2 + lado3;

        }

    }

    class Cuadrado : Metodos {

        public double lado1;


        public Cuadrado(double lado1) {
            this.lado1 = lado1;


        }

        public double CalcularArea() {

            return lado1 * lado1;

        }

        public double CalcularPerimetro() {

            return lado1 * 4;

        }



    }
}
