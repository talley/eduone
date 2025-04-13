using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Fr.Models
{
    public partial class TransactionSecurity
    {
        public Guid TransactionId { get; set; }

        [Key]
        public Guid GID { get; set; }

        public int Id { get; set; }

        public int EleveId { get; set; }

        public int SemestreId { get; set; }

        public bool Statut { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal MontantDu { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal MontantReçu { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }

        [Required]
        public string Notes { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }

        [Required]
        [StringLength(1)]
        public string Type_Action { get; set; }

        [Required]
        [StringLength(80)]
        public string Utilisateur_Action { get; set; }

        public DateTime Date_Action { get; set; }
    }
}
