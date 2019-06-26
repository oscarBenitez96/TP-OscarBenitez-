using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5E
{

    class TP5E : DbContext
    {        
        public DbSet<Alumnos> Alumnos{ get; set; }
        public DbSet<TCarreras> TCarreras { get; set; }
        public DbSet<TodasLasNotas> TodasLasNotas { get; set; }
        public DbSet<Ctrs> Ctrs { get; set; }
    }

    internal class Program
    {   
        private static void Main(string[] args)
        {
            int Cant = 0;
            int sumanotas = 0;
            double Prom = 0;
            using (var ctx = new TP5E())
            {

                var alumno7 = new TodasLasNotas() { Nombre = "Derecho Romano", Cuat = 1, Anio = 2018, Nota = 8, Fecha = "30 Marzo 2018", Tipo = "Primer Parcial" };
                var alumno8 = new TodasLasNotas() { Nombre = "Historia del Cine", Cuat = 2, Anio = 2016, Nota = 6, Fecha = "18 Octubre 2016", Tipo = "TP" };
                var alumno9 = new TodasLasNotas() { Nombre = "Anatomia", Cuat = 3, Anio = 2018, Nota = 10, Fecha = "18 Diciembre 2018", Tipo = "Final" };
                var alumno10 = new TodasLasNotas() { Nombre = "Derecho Romano", Cuat = 5, Anio = 2015, Nota = 8, Fecha = "12 Abril 2015", Tipo = "TP" };
                var alumno11 = new TodasLasNotas() { Nombre = "Historia del Cine", Cuat = 1, Anio = 2014, Nota = 2, Fecha = "02 Enero 2014", Tipo = "TP" };
                var alumno12 = new TodasLasNotas() { Nombre = "Historia del Cine", Cuat = 1, Anio = 2018, Nota = 10, Fecha = "18 Diciembre 2018", Tipo = "Final" };


                var alumno2 = new TCarreras() { Nombre = "Derecho" };
                var alumno6 = new TCarreras() { Nombre = "Historia" };
                var alumno4 = new TCarreras() { Nombre = "Medicina" };
                var alumno13 = new TCarreras() { Nombre = "Derecho" };
                var alumno14 = new TCarreras() { Nombre = "Historia" };
                var alumno15 = new TCarreras() { Nombre = "Historia" };

                var Alumnos = new Alumnos() { Nombre = "Pochi", CarrerasId= 1 };
                var alumno3 = new Alumnos() { Nombre = "Esteban", CarrerasId = 2 };
                var alumno5 = new Alumnos() { Nombre = "Ernesto", CarrerasId = 3 };

                var alumno16 = new Alumnos() { Nombre = "Mariano", CarrerasId = 4 };
                var alumno17 = new Alumnos() { Nombre = "Santiago", CarrerasId = 5 };
                var alumno18 = new Alumnos() { Nombre = "Maria", CarrerasId = 6 };

                ctx.TodasLasNotas.Add(alumno7);
                ctx.TodasLasNotas.Add(alumno8);
                ctx.TodasLasNotas.Add(alumno9);
                ctx.TodasLasNotas.Add(alumno10);
                ctx.TodasLasNotas.Add(alumno11);
                ctx.TodasLasNotas.Add(alumno12);
                ctx.SaveChanges();                
                ctx.TCarreras.Add(alumno2);
                ctx.TCarreras.Add(alumno6);
                ctx.TCarreras.Add(alumno4);
                ctx.TCarreras.Add(alumno13);
                ctx.TCarreras.Add(alumno14);
                ctx.TCarreras.Add(alumno15);
                ctx.SaveChanges();
                ctx.Alumnos.Add(Alumnos);
                ctx.Alumnos.Add(alumno3);
                ctx.Alumnos.Add(alumno5);
                ctx.Alumnos.Add(alumno16);
                ctx.Alumnos.Add(alumno17);
                ctx.Alumnos.Add(alumno18);
                ctx.SaveChanges();
                
                var LA = ctx.Alumnos.ToList();
                var LCarreras = ctx.TCarreras.ToList();
                var LasNotas = ctx.TodasLasNotas.ToList();
                String Nombre = "Historia del Cine";
                
                foreach (var noters in LasNotas)
                {                    
                     if (noters.Nombre.Equals(Nombre))
                     {                        
                        Cant ++;
                        sumanotas = +noters.Nota;
                        Prom = noters.PromedioNotas(sumanotas, Cant);
                        String texto1 = "Existen " + Cant + " registros para la matera " + Nombre + "\nLa nota promedio es: " + Prom;
                        Ctrs Resultado = new Ctrs { Resultado = texto1};
                        var all = from c in ctx.Ctrs select c;
                        ctx.Ctrs.RemoveRange(all);
                        ctx.Ctrs.Add(Resultado);
                        ctx.SaveChanges();
                    }
                    
                }

                
                var ElRes = ctx.Ctrs.ToArray();
                foreach (var results in ElRes)
                {
                    Console.WriteLine(results.Resultado);
                }

                Console.ReadKey();

            }
        }
    }

    public static class LasNotasExtensionMethods
    {
        public static double PromedioNotas(this TodasLasNotas TodasLasNotas,int nota, int Cant)
        {
            return nota/Cant;
        }
    }

    public class Alumnos
    {
        public String Nombre { get; set; }
        public int Id { get; set; }
        public int CarrerasId { get; set; }
        public TCarreras TCarreras { get; set; }
        public TodasLasNotas TodasLasNotas { get; set; }
}
    public class TCarreras
    {
        public String Nombre { get; set; }
        public int Id { get; set; }
    }

    public class TodasLasNotas
    {
        public String Nombre { get; set; }
        public int  Cuat { get; set; }
        public int Anio { get; set; }
        public int Nota { get; set; }
        public String Fecha { get; set; }
        public String Tipo { get; set; }
        public int Id { get; set; }

    }

    public class Ctrs
    {
        public String Resultado { get; set; }
        public int Id { get; set; }
    }

    
}