using System.ComponentModel.DataAnnotations;

namespace C8ProyectoFinalPorEquipos.Models
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; }
        [Required, MaxLength(50)]
        public string Apellidos { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Genero { get; set; }
    }
}