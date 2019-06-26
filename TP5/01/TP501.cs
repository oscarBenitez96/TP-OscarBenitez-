using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP501 {

    class TP501DB : DbContext {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<LasCarreras> LasCarreras { get; set; }
        public DbSet<TodasLasNotas> TodasLasNotas { get; set; }
    }

    internal class Program {
        private static void Main(string[] args) {
            using (var ctx = new TP501DB()) {

                var a1 = new TodasLasNotas() { Nombre = "Historia del Arte", Cuat = 2, Anio = 2017, Nota = 4, Fecha = "19 Julio 2017", Tipo = "Primer Parcial" };
                var a2 = new TodasLasNotas() { Nombre = "Introduccion a la hospitalidad", Cuat = 1, Anio = 2016, Nota = 8, Fecha = "12 Octubre 2016", Tipo = "Trabajo Practico" };
                var a3 = new TodasLasNotas() { Nombre = "Oratoria", Cuat = 5, Anio = 2018, Nota = 9, Fecha = "11 Diciembre 2018", Tipo = "Final" };

                var a4 = new LasCarreras() { NombreCarrera = "Arte" };
                var a5 = new LasCarreras() { NombreCarrera = "Hoteleria" };
                var a6 = new LasCarreras() { NombreCarrera = "Periodismo" };

                var a7 = new Alumno() { TP5DB = "Matute Fenocchi", CarrerasId = 1 };
                var a8 = new Alumno() { TP5DB = "Juan Carballo", CarrerasId = 2 };
                var a9 = new Alumno() { TP5DB = "Miranda Leopoldo", CarrerasId = 3 };

                ctx.TodasLasNotas.Add(a1);
                ctx.TodasLasNotas.Add(a2);
                ctx.TodasLasNotas.Add(a3);
                ctx.SaveChanges();
                ctx.LasCarreras.Add(a4);
                ctx.LasCarreras.Add(a5);
                ctx.LasCarreras.Add(a6);
                ctx.SaveChanges();
                ctx.Alumnos.Add(a7);
                ctx.Alumnos.Add(a8);
                ctx.Alumnos.Add(a9);
                ctx.SaveChanges();

                var LosAlumnos = ctx.Alumnos.ToList();
                var LasCarreras = ctx.LasCarreras.ToList();
                var TodasLasNotas = ctx.TodasLasNotas.ToList();

                foreach (var als in LosAlumnos) {
                    String texto = als.Id + " - " + als.TP5DB + "\n";

                    foreach (var carreers in LasCarreras) {
                        if (carreers.Id == als.Id) {
                            String res2 = texto + "Carrera: " + carreers.NombreCarrera + "\n";
                            foreach (var noters in TodasLasNotas) {
                                if (noters.Id == als.Id) {
                                    String res3 = res2 + "Mat: " + noters.Nombre + "\nAño: " + noters.Anio + " - Cuat: " + noters.Cuat + "\nTipo examen: " + noters.Tipo + " - Fecha Examen: " + noters.Fecha + " - Nota: " + noters.Nota + "\n";
                                    Console.WriteLine(res3);

                                }
                            }
                        }


                    }


                }
                Console.ReadKey();
            }
        }
    }
    public class Alumno {
        public String TP5DB { get; set; }
        public int Id { get; set; }
        public int CarrerasId { get; set; }
        public LasCarreras LasCarreras { get; set; }
        public TodasLasNotas TodasLasNotas { get; set; }
    }
    public class LasCarreras {
        public String NombreCarrera { get; set; }
        public int Id { get; set; }
    }

    public class TodasLasNotas {
        public String Nombre { get; set; }
        public int Cuat { get; set; }
        public int Anio { get; set; }
        public int Nota { get; set; }
        public String Fecha { get; set; }
        public String Tipo { get; set; }
        public int Id { get; set; }

    }
}
