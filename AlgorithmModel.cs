using System;
using System.ComponentModel.DataAnnotations;

namespace FireSafety
{
    public class AlgorithmModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public double Result { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public bool Success { get; set; }
        
        [Required]
        public UserModel User { get; set; }

        [Required]
        public MapModel Map { get; set; }
    }
}