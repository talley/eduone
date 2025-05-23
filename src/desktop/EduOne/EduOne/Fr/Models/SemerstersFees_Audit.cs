﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Fr.Models
{
    public partial class SemerstersFees_Audit
    {
        [Key]
        public Guid Gid { get; set; }

        public int Id { get; set; }

        public int SemestreId { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Frais { get; set; }

        public string Notes { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        [StringLength(200)]
        public string Action_Utilisateur { get; set; }

        public DateTime Action_Date { get; set; }
    }
}
