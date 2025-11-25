using SQLite;

namespace GestionMascotas.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Mascota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; } // Perro, Gato, etc.
        public int Edad { get; set; }
    }

    public class Medicina
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NombreMedicina { get; set; }
        public string Dosis { get; set; }
    }

    public class CitaVeterinaria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string NombreMascota { get; set; }
    }
}