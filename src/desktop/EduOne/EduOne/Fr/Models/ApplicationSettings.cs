using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Fr.Models
{
    public partial class ApplicationSettings
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string AppKey { get; set; }

        [Required]
        [StringLength(500)]
        public string AppValue { get; set; }

        public bool CanBeAltered { get; set; }

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
