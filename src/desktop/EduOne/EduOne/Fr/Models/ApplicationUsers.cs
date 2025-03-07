using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduOne.Fr.Models
{
    public partial class ApplicationUsers
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Utilisateur { get; set; }

        [Required]
        public byte[] Password { get; set; }

        public bool Statut { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(200)]
        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        [Required]
        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("ApplicationUsers")]
        public virtual ApplicationRoles Role { get; set; }
    }
}
