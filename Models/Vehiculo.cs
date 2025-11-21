using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoParqueo.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Placa { get; set; }

        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(30)]
        public string Color { get; set; }

        public DateTime? HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; } = "Dentro";

        [Required]
        public decimal HorasTotal { get; set; } = 0;

        [Required]
        [MaxLength(50)]
        public string Regalo { get; set; } = "N/A";
    }
}
