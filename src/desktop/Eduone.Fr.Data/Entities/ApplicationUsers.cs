﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Eduone.Fr.Data.Entities;

[Index("Email", Name = "UQ__tmp_ms_x__A9D105346B62C2D8", IsUnique = true)]
public partial class ApplicationUsers
{
    [Key]
    public Guid Id { get; set; }

    public Guid RoleId { get; set; }

    [Required]
    [StringLength(50)]
    public string Utilisateur { get; set; }

    [Required]
    public byte[] Password { get; set; }

    public bool Statut { get; set; }

    [Required]
    [StringLength(100)]
    public string Nom { get; set; }

    [Required]
    [StringLength(200)]
    public string Prenom { get; set; }

    public DateTime DateNaissance { get; set; }

    [Required]
    [StringLength(1000)]
    public string Notes { get; set; }

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

    [ForeignKey("RoleId")]
    [InverseProperty("ApplicationUsers")]
    public virtual ApplicationRoles Role { get; set; }
}