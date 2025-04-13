using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduOne.Fr.Models
{
    public partial class Enrollments
    {
        [Key]
        public int InscriptionID { get; set; }

        public int? SemestreID { get; set; }
        public int EleveId { get; set; }

        public int CoursId { get; set; }

        public DateTime Date_Inscription { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Grade { get; set; }

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
