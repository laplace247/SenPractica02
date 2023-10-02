using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenatiPractica.common.instructor
{
    public class EntidadInstructor
    {
        public String Dni { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Edad { get; set; }
        public String Curso { get; set; }
        public String Genero { get; set; }
        public int Id { get; set; }

        // Constructor
        public EntidadInstructor(string dni, string nombres, string apellidos, string edad, string curso, string genero)
        {
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
            Edad = edad;
            Curso = curso;
            Genero = genero;
        }
        public EntidadInstructor(int id, string dni, string nombres, string apellidos, string edad, string curso, string genero)
        {
            Id = id;
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
            Edad = edad;
            Curso = curso;
            Genero = genero;
        }
        public EntidadInstructor() { }
    }
}
