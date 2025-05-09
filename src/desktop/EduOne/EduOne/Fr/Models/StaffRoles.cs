﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EduOne.Fr.Models
{
    public partial class StaffRoles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }
    }
}
