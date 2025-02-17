using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Fr.Models
{
    public partial class Staffs
    {
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

        public DateTime? Date_Embauche { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }

        public string Notes { get; set; }

        public bool Status { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }
    }
}
