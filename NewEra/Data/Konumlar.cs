using System;
using System.ComponentModel.DataAnnotations;


namespace NewEra.Data
{
    public class Konumlar
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string Bina { get; set; }
        [Required]
        [StringLength(30)]
        public string Kat { get; set; }
        [Required]
        [StringLength(30)]
        public string Konum { get; set; }

    }
}