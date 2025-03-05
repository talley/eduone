using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduOne.Data.Fr;

namespace EduOne.Fr.Models
{
    public partial class ApplicationRoles
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NomRole { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<ApplicationFormsSecurity> ApplicationFormsSecurity { get; set; } = new List<ApplicationFormsSecurity>();

        [InverseProperty("Role")]
        public virtual ICollection<ApplicationUsers> ApplicationUsers { get; set; } = new List<ApplicationUsers>();
    }
}
