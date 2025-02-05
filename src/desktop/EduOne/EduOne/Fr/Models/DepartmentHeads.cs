using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Fr.Models
{
    public partial class DepartmentHeads
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nom { get; set; }

        [Required]
        [StringLength(200)]
        public string Prénom { get; set; }

        [Required]
        [StringLength(25)]
        public string TelePhone { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

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
    }
}
