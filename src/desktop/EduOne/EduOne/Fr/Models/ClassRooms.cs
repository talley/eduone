using System;
using System.ComponentModel.DataAnnotations;

namespace EduOne.Fr.Models
{
    public partial class Classrooms
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NuméroChambre { get; set; }

        [Required]
        [StringLength(200)]
        public string Bâtiment { get; set; }

        public int Capacité { get; set; }

        public bool Statut { get; set; }

        public string Notes { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }
    }
}
