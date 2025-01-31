using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EduOne.Fr.Models
{
    [DebuggerNonUserCode]
    public partial class Departments
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nom_Département { get; set; }

        public int? ID_Chef_Département { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }

        [InverseProperty("ID_DepartmentNavigation")]
        public virtual ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
