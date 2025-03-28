﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EduOne.Fr.Models
{
    public partial class Semesters
    {
        [Key]
        public int ID { get; set; }

        public int Année { get; set; }

        [Required]
        [StringLength(200)]
        public string Semestre { get; set; }

        public string Notes { get; set; }

        public bool Statut { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }
    }
}
