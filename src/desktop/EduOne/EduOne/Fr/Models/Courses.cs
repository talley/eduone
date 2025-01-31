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
    public partial class Courses
    {
        [Key]
        public int Cours_Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Nom_Cours { get; set; }

        [Required]
        public string Description { get; set; }

        public int ID_Department { get; set; }

        public bool Statut { get; set; }

        public DateTime AjouterAu { get; set; }

        [Required]
        [StringLength(80)]
        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        [StringLength(80)]
        public string ModifierPar { get; set; }

        [ForeignKey("ID_Department")]
        [InverseProperty("Courses")]
        public virtual Departments ID_DepartmentNavigation { get; set; }
    }
}
