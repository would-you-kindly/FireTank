﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FireSafety
{
    public class UserModel
    {
        public UserModel()
        {
            this.Algorithms = new HashSet<AlgorithmModel>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public virtual ICollection<AlgorithmModel> Algorithms { get; set; }
    }
}