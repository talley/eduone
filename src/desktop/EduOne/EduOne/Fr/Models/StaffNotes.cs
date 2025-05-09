﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EduOne.Fr.Models
{
    public partial class StaffNotes
    {
        [Key]
        public int Id { get; set; }

        public int EId { get; set; }

        [Required]
        public string Notes { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(300)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }
    }
}
