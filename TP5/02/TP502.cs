using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5B
{

    class TP5B : DbContext
    {        
        public DbSet<Als> Alumnos{ get; set; }
        public DbSet<TCarreras> TCarreras { get; set; }
        public DbSet<TodasLasNotas> TodasLasNotas { get; set; }
    }

    internal class Program
    {   
        private static void Main(string[] args)
        {
            using (var ctx = new TP5B())
            {

                var alumno7 = new TodasLasNotas() { Nombre = "Administrativo", Cuat = 1, Anio = 2017, Nta = 8, Fecha = "30 Marzo 2017", Tipo = "Primer Parcial" };
                var alumno8 = new TodasLasNotas() { Nombre = "Historia del Cine", Cuat = 2, Anio = 2016, Nta = 6, Fecha = "18 Octubre 2016", Tipo = "Trabajo Practico" };
                var alumno9 = new TodasLasNotas() { Nombre = "Anatomia", Cuat = 3, Anio = 2017, Nta = 10, Fecha = "18 Diciembre 2017", Tipo = "Final" };
                var alumno10 = new TodasLasNotas() { Nombre = "Administrativo", Cuat = 5, Anio = 2015, Nta = 8, Fecha = "12 Abril 2015", Tipo = "Trabajo Practico" };
                var alumno11 = new TodasLasNotas() { Nombre = "Historia del Cine", Cuat = 1, Anio = 2019, Nta = 2, Fecha = "02 Enero 2019", Tipo = "Trabajo Practico" };
                var alumno12 = new TodasLasNotas() { Nombre = "Anatomia", Cuat = 1, Anio = 2017, Nta = 10, Fecha = "18 Diciembre 2017", Tipo = "Final" };


                var alumno2 = new TCarreras() { NombreCarrera = "Derecho" };
                var alumno6 = new TCarreras() { NombreCarrera = "Historia" };
                var alumno4 = new TCarreras() { NombreCarrera = "Medicina" };
                var alumno13 = new TCarreras() { NombreCarrera = "Derecho" };
                var alumno14 = new TCarreras() { NombreCarrera = "Historia" };
                var alumno15 = new TCarreras() { NombreCarrera = "Medicina" };

                var Als = new Als() { Nombre = "ZHugo", CarrerasId= 1 };
                var alumno3 = new Als() { Nombre = "LPaco", CarrerasId = 2 };
                var alumno5 = new Als() { Nombre = "Auis", CarrerasId = 3 };

                var alumno16 = new Als() { Nombre = "BEsteban", CarrerasId = 4 };
                var alumno17 = new Als() { Nombre = "MRaul", CarrerasId = 5 };
                var alumno18 = new Als() { Nombre = "WArturo", CarrerasId = 6 };

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
                ctx.Alumnos.Add(Als);
                ctx.Alumnos.Add(alumno3);
                ctx.Alumnos.Add(alumno5);
                ctx.Alumnos.Add(alumno16);
                ctx.Alumnos.Add(alumno17);
                ctx.Alumnos.Add(alumno18);
                ctx.SaveChanges();                
                                
                var LosAlumnos = ctx.Alumnos.ToList();
                var LasCarreras = ctx.TCarreras.ToList();
                var LasNotas = ctx.TodasLasNotas.ToList();
                foreach (var notes in LasNotas)
                {
                    if (notes.Cuat == 1)
                    {
                        String texto1 = "Mat: " + notes.Nombre + "\nAño: " + notes.Anio + " - Cuat: " + notes.Cuat + "\nTipo examen: " + notes.Tipo + " - Fecha: " + notes.Fecha + " - Nta: " + notes.Nta + "\n";

                        foreach (var carrers in LasCarreras)
                        {
                            if (carrers.Id == notes.Id)
                            {
                                String texto2 = "Carrera: " + carrers.NombreCarrera + "\n"+texto1;
                                foreach (var alumf in LosAlumnos)
                                {
                                    if (notes.Id == alumf.Id)
                                    {
                                        String texto3 = alumf.Id + " - " + alumf.Nombre + "\n" + texto2;

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
    public class Als
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
        public int  Cuat { get; set; }
        public int Anio { get; set; }
        public int Nta { get; set; }
        public String Fecha { get; set; }
        public String Tipo { get; set; }
        public int Id { get; set; }

    }
}