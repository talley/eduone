using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EduOne.Fr.Models
{
    [DebuggerNonUserCode]
    public partial class Students
    {
        public Guid GlobalId { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prénom { get; set; }

        [Required]
        [StringLength(100)]
        public string Surnom { get; set; }

        [Required]
        [StringLength(200)]
        public string LieuNaissance { get; set; }

        public DateTime DateNaissance { get; set; }

        [Required]
        [StringLength(40)]
        public string Genre { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string TelePhone { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [Required]
        [StringLength(200)]
        public string Addresse { get; set; }

        [StringLength(200)]
        public string Addresse2 { get; set; }

        [Required]
        [StringLength(100)]
        public string Ville { get; set; }

        [Required]
        [StringLength(100)]
        public string État { get; set; }

        [Required]
        [StringLength(100)]
        public string Pays { get; set; }

        public DateTime? Date_Inscription { get; set; }

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
