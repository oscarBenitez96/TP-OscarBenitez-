using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5D
{

    class TP5D : DbContext
    {        
        public DbSet<Alumnos> Alumnos{ get; set; }
        public DbSet<TCarreras> TCarreras { get; set; }
        public DbSet<Notas> Notas { get; set; }
    }

    internal class Program
    {   
        private static void Main(string[] args)
        {
            using (var ctx = new TP5D())
            {

                var alumno7 = new Notas() { Nombre = "Derecho Romano", Cuat = 1, Anio = 2018, Nota = 8, Fecha = "30 Marzo 2018", Tipo = "Primer Parcial" };
                var alumno8 = new Notas() { Nombre = "Historia del Cine", Cuat = 2, Anio = 2016, Nota = 6, Fecha = "18 Octubre 2016", Tipo = "TP" };
                var alumno9 = new Notas() { Nombre = "Anatomia", Cuat = 3, Anio = 2018, Nota = 10, Fecha = "18 Diciembre 2018", Tipo = "Final" };
                var alumno10 = new Notas() { Nombre = "Derecho Romano", Cuat = 5, Anio = 2015, Nota = 8, Fecha = "12 Abril 2015", Tipo = "TP" };
                var alumno11 = new Notas() { Nombre = "Historia del Cine", Cuat = 1, Anio = 2019, Nota = 2, Fecha = "02 Enero 2019", Tipo = "TP" };
                var alumno12 = new Notas() { Nombre = "Anatomia", Cuat = 1, Anio = 2018, Nota = 10, Fecha = "18 Diciembre 2018", Tipo = "Final" };


                var alumno2 = new TCarreras() { NombreCarrera = "Derecho" };
                var alumno6 = new TCarreras() { NombreCarrera = "Historia" };
                var alumno4 = new TCarreras() { NombreCarrera = "Medicina" };
                var alumno13 = new TCarreras() { NombreCarrera = "Derecho" };
                var alumno14 = new TCarreras() { NombreCarrera = "Historia" };
                var alumno15 = new TCarreras() { NombreCarrera = "Medicina" };

                var Alumnos = new Alumnos() { Nombre = "Fredo", CarrerasId= 1 };
                var alumno3 = new Alumnos() { Nombre = "Sonny", CarrerasId = 2 };
                var alumno5 = new Alumnos() { Nombre = "Michael", CarrerasId = 3 };

                var alumno16 = new Alumnos() { Nombre = "Vito", CarrerasId = 4 };
                var alumno17 = new Alumnos() { Nombre = "Luca", CarrerasId = 5 };
                var alumno18 = new Alumnos() { Nombre = "Tom", CarrerasId = 6 };

                ctx.Notas.Add(alumno7);
                ctx.Notas.Add(alumno8);
                ctx.Notas.Add(alumno9);
                ctx.Notas.Add(alumno10);
                ctx.Notas.Add(alumno11);
                ctx.Notas.Add(alumno12);
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
                                
                var LosAlumnos = ctx.Alumnos.ToList();
                var LasCarreras = ctx.TCarreras.ToList();
                var LasNotas = ctx.Notas.ToList();
                foreach (var notes in LasNotas)
                {
                    if (notes.Tipo.Equals("TP"))
                    {
                        String texto1 = "Materia: " + notes.Nombre + "\nAño: " + notes.Anio + " - Cuat: " + notes.Cuat + "\nTipo examen: " + notes.Tipo + " - Fecha Examen: " + notes.Fecha + " - Nota: " + notes.Nota + "\n";

                        foreach (var carrers in LasCarreras)
                        {
                            if (carrers.Id == notes.Id)
                            {
                                String texto2 = "Carrera: " + carrers.NombreCarrera + "\n"+texto1;
                                foreach (var alumns in LosAlumnos)
                                {
                                    if (notes.Id == alumns.Id)
                                    {
                                        String texto3 = alumns.Id + " - " + alumns.Nombre + "\n" + texto2;

                                        Console.WriteLine(texto3);

                                    }
                                }
                            }
                        }
                    }                    
                }
                Console.ReadKey();
            }            
        }
    }
    public class Alumnos
    {
        public String Nombre { get; set; }
        public int Id { get; set; }
        public int CarrerasId { get; set; }
        public TCarreras TCarreras { get; set; }
        public Notas Notas { get; set; }
}
    public class TCarreras
    {
        public String NombreCarrera { get; set; }
        public int Id { get; set; }
    }

    public class Notas
    {
        public String Nombre { get; set; }
        public int  Cuat { get; set; }
        public int Anio { get; set; }
        public int Nota { get; set; }
        public String Fecha { get; set; }
        public String Tipo { get; set; }
        public int Id { get; set; }

    }
}