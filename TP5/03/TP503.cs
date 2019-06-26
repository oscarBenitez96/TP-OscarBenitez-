using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5C
{

    class TP5C : DbContext
    {        
        public DbSet<Alumno> Alumnos{ get; set; }
        public DbSet<TCarreras> TCarreras { get; set; }
        public DbSet<TodasLasNotas> TodasLasNotas { get; set; }
        public DbSet<Ctdores> Ctdores { get; set; }
    }

    internal class Program
    {   
        private static void Main(string[] args)
        {
            using (var ctx = new TP5C())
            {

                var alumno7 = new TodasLasNotas() { Nombre = "Derecho Romano", Cuatrimestre = 1, Anio = 2018, Nota = 8, Fecha = "30 Marzo 2018", Tipo = "Primer Parcial" };
                var alumno8 = new TodasLasNotas() { Nombre = "Historia del Cine", Cuatrimestre = 2, Anio = 2016, Nota = 6, Fecha = "18 Octubre 2016", Tipo = "Trabajo Practico" };
                var alumno9 = new TodasLasNotas() { Nombre = "Anatomia", Cuatrimestre = 3, Anio = 2018, Nota = 10, Fecha = "18 Diciembre 2018", Tipo = "Final" };

                var alumno2 = new TCarreras() { NombreCarrera = "Derecho" };
                var alumno6 = new TCarreras() { NombreCarrera = "Historia" };
                var alumno4 = new TCarreras() { NombreCarrera = "Medicina" };

                var alumno = new Alumno() { Nombre = "ZHugo", CarrerasId= 1 };
                var alumno3 = new Alumno() { Nombre = "LPaco", CarrerasId = 2 };
                var alumno5 = new Alumno() { Nombre = "ALuis", CarrerasId = 3 };

                ctx.TodasLasNotas.Add(alumno7);
                ctx.TodasLasNotas.Add(alumno8);
                ctx.TodasLasNotas.Add(alumno9);
                ctx.SaveChanges();                
                ctx.TCarreras.Add(alumno2);
                ctx.TCarreras.Add(alumno6);
                ctx.TCarreras.Add(alumno4);
                ctx.SaveChanges();
                ctx.Alumnos.Add(alumno);
                ctx.Alumnos.Add(alumno3);
                ctx.Alumnos.Add(alumno5);
                ctx.SaveChanges();                
                
                var LosAlumnos = ctx.Alumnos.ToList();
                var LasCarreras = ctx.TCarreras.ToList();
                var LasNotas = ctx.TodasLasNotas.ToList();
                
                foreach (var als in LosAlumnos)
                {
                    String res1= als.Nombre +" - ID: " + als.Id + " - \n";

                    foreach (var carrers in LasCarreras)
                    {
                        if (carrers.Id == als.Id)
                        {
                            String res2 = res1+ "Carrera: " + carrers.NombreCarrera +"\n";
                            foreach (var noters in LasNotas)
                            {
                                if (noters.Id == als.Id)
                                {
                                    String res3 = res2 + "Materia: " + noters.Nombre + "\nAño: " + noters.Anio + " - Cuatrimestre: " + noters.Cuatrimestre + "\nTipo examen: " + noters.Tipo + " - Fecha Examen: "+noters.Fecha + " - Nota: " + noters.Nota + "\n";
                                    Ctdores Resultado = new Ctdores { Resultado = res3 };
                                    //Console.WriteLine(res3);
                                    ctx.Ctdores.Add(Resultado);
                                    ctx.SaveChanges();
                                }
                            }
                        }
                        

                    }
                }

                foreach (var results in sortedList)
                {
                     Console.WriteLine("Nombre: " + results.Resultado);
                }

                
				Console.ReadKey();
            }            
        }
    }
    public class Alumno
    {
        public String Nombre { get; set; }
        public int Id { get; set; }
        public int CarrerasId { get; set; }
        public TCarreras TCarreras { get; set; }
        public TodasLasNotas TodasLasNotas { get; set; }
}
    public class TCarreras
    {
        public String NombreCarrera { get; set; }
        public int Id { get; set; }
    }

    public class TodasLasNotas
    {
        public String Nombre { get; set; }
        public int  Cuatrimestre { get; set; }
        public int Anio { get; set; }
        public int Nota { get; set; }
        public String Fecha { get; set; }
        public String Tipo { get; set; }
        public int Id { get; set; }

    }
    public class Ctdores
    {
        public String Resultado { get; set; }
        public int Id { get; set; }
    }
}