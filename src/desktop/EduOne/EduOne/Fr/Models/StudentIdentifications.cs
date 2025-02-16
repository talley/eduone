using System;
using System.Diagnostics;

namespace EduOne.Fr.Models
{
    [DebuggerNonUserCode]
    public partial class StudentIdentifications
    {
        public Guid UID { get; set; }

        public int Id { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] FileData { get; set; }

        public DateTime AjouterAu { get; set; }

        public string AjouterPar { get; set; }

        public DateTime? ModifierAu { get; set; }

        public string ModifierPar { get; set; }
    }
}