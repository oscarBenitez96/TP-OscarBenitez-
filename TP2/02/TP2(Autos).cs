using System;


namespace ConsoleApp4 {
    class TP2Ejercicio2 {
        static void Main(string[] args) {

            Random random = new Random();

            Ruedas[] ruedas = new Ruedas[4];
            ruedas[0] = new Ruedas1();
            ruedas[1] = new Ruedas2();
            ruedas[2] = new Ruedas3();
            ruedas[3] = new Ruedas1();

            Motor[] motor = new Motor[4];
            motor[0] = new Motor1();
            motor[1] = new Motor2();
            motor[2] = new Motor3();
            motor[3] = new Motor3();


            CajaDeCambios[] cambios = new CajaDeCambios[4];
            cambios[0] = new CajaCambios1();
            cambios[1] = new CajaCambios2();
            cambios[2] = new CajaCambios3();
            cambios[3] = new CajaCambios2();

            int c = 0;

            for (int i = 0; i < motor.Length; i++) {
                c++;
                int cantRuedas = random.Next(6) + 1;
                int diametro = random.Next(400) + 200;
                int cilindro = random.Next(10) + 2;
                int cambios2 = random.Next(9) + 2;
                int var = random.Next(2);
                bool vol;
                if (var == 1) {
                    vol = true;
                } else {
                    vol = false;
                }

                Console.WriteLine("\n");
                Console.WriteLine($"Auto {c}");
                Console.WriteLine(ruedas[i].ruedasValidar(cantRuedas));
                if (cantRuedas < 5) {
                    Console.WriteLine(ruedas[i].iniciar(diametro));
                    Console.WriteLine(ruedas[i].frenar(diametro));
                    Console.WriteLine(motor[i].iniciar(cilindro));
                    Console.WriteLine(motor[i].frenar(cilindro));
                    Console.WriteLine(cambios[i].HacerCambios(vol, cambios2));
                } else {
                    Console.WriteLine("El auto no puede tener mas de 4 ruedas");
                }


            }

            Console.ReadKey();

        }
    }



    class Ruedas1 : Ruedas {


        bool ValidaR;
        String Ruedas.ruedasValidar(int ruedas) {
            return $"Tiene {ruedas} ruedas";
        }

        String Ruedas.iniciar(double diametro) {
            if (ValidaR = true) {
                return "Inician las ruedas de " + diametro + "CM de diametro.";
            } else {
                return "Ingreso una cantidad incorrecta de ruedas. El automovil solo puede tener cinco ruedas";
            }

        }

        String Ruedas.frenar(double diametro) {
            if (ValidaR = true) {
                return "Frenan las ruedas de CM:" + diametro;
            } else {
                return "Ingreso una cantidad incorrecta de ruedas. Deberian ser CINCO ruedas!";
            }

        }


    }

    class Ruedas2 : Ruedas {


        bool ValidaR;
        String Ruedas.ruedasValidar(int ruedas) {
            return $"Tiene {ruedas} ruedas";
        }

        String Ruedas.iniciar(double diametro) {
            if (ValidaR = true) {
                return "Inician las ruedas de " + diametro + " centrimetros de diametro.";
            } else {
                return "Ingreso una cantidad incorrecta de ruedas (se supone que son cinco).";
            }

        }

        String Ruedas.frenar(double diametro) {
            if (ValidaR = true) {
                return "Frenan las ruedas de " + diametro + " diametro.";
            } else {
                return "Ingreso una cantidad incorrecta de ruedas.";
            }

        }
    }

    class Ruedas3 : Ruedas {


        bool ValidaR;
        String Ruedas.ruedasValidar(int ruedas) {

            return $"Tiene {ruedas} ruedas";

        }

        String Ruedas.iniciar(double diametro) {
            if (ValidaR = true) {
                return "Inician las ruedas de " + diametro + " diametro.";
            } else {
                return "Ingreso una cantidad incorrecta de ruedas.";
            }

        }

        String Ruedas.frenar(double diametro) {
            if (ValidaR = true) {
                return "Frenan las ruedas de " + diametro + " diametro.";
            } else {
                return "Ingreso una cantidad incorrecta de ruedas.";
            }

        }
    }

    class Motor1 : Motor {


        String Motor.iniciar(int cilindrada) {
            int cilindros = cilindrada + 2;
            return "Inicia el motor, todos los " + cilindros + " cilindros aceleran.";
        }

        String Motor.frenar(int cilindrada) {
            int cilindros = cilindrada + 2;
            return "Frena el motor, todos los " + cilindros + " cilindros desaceleran.";
        }
    }

    class Motor2 : Motor {


        String Motor.iniciar(int cilindrada) {
            return "Inicia el motor que tiene " + cilindrada + " cilindros, todos aceleran correctamente.";
        }

        String Motor.frenar(int cilindrada) {
            return "Frena el motor, los " + cilindrada + " cilindros se detienen.";
        }
    }

    class Motor3 : Motor {

        String Motor.iniciar(int cilindrada) {
            return "Inicia el motor, aceleran todos los " + cilindrada + " cilindros del motor.";
        }

        String Motor.frenar(int cilindrada) {
            return "Frenamos el motor de " + cilindrada + " cilindros.";
        }
    }

    class CajaCambios1 : CajaDeCambios {


        String CajaDeCambios.HacerCambios(bool TipoCaja, int CantCambios) {
            int CuantosCambios = CantCambios;

            TipoCaja = true;

            if (TipoCaja == true) {
                return "Se utiliza la caja automatica, la ponemos en D";
            } else {
                return "Hacemos un cambio de los " + CuantosCambios + " que tiene la caja";
            }

        }

    }

    class CajaCambios2 : CajaDeCambios {


        String CajaDeCambios.HacerCambios(bool TipoCaja, int CantCambios) {
            int CuantosCambios = CantCambios;

            TipoCaja = true;

            if (TipoCaja == true) {
                return "Las cajas automaticas no tienen cambios";
            } else {
                return "Esta caja tiene " + CuantosCambios + " y hacemos un cambio ahora mismo";
            }
        }

    }

    class CajaCambios3 : CajaDeCambios {


        String CajaDeCambios.HacerCambios(bool TipoCaja, int CantCambios) {
            int CuantosCambios = CantCambios;

            TipoCaja = true;

            if (TipoCaja == true) {
                return "Se pone la caja automatica en DRIVE";
            } else {
                return "Hacemos un cambio de los en esta caja de " + CuantosCambios;

            }
        }

    }

    interface Ruedas {
        String ruedasValidar(int ruedas);
        String iniciar(double diametro);
        String frenar(double diametro);
    }

    interface Motor {
        String iniciar(int cilindrada);
        String frenar(int cilindrada);
    }

    interface CajaDeCambios {
        String HacerCambios(bool TipoCaja, int CantCambios);
    }
}
