﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eduone.Fr.Data.Entities;

public partial class StaffNotes
{
    [Key]
    public int Id { get; set; }

    public int EId { get; set; }

    [Required]
    public string Notes { get; set; }

    public DateTime AjouterAu { get; set; }

    [Required]
    [StringLength(300)]
    public string AjouterPar { get; set; }

    public DateTime? ModifierAu { get; set; }

    [StringLength(80)]
    public string ModifierPar { get; set; }
}