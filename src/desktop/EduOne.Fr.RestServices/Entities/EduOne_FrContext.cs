#nullable disable
namespace EduOne.Fr.RestServices.Entities;

public partial class EduOne_FrContext : DbContext
{
    public EduOne_FrContext()
    {
    }

    public EduOne_FrContext(DbContextOptions<EduOne_FrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationForms> ApplicationForms { get; set; }

    public virtual DbSet<ApplicationFormsSecurity> ApplicationFormsSecurity { get; set; }

    public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }

    public virtual DbSet<ApplicationUsers> ApplicationUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(DbHelpers.CS);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationForms>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC076DBA7B48");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ApplicationFormsSecurity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC074FB3CAD3");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Form).WithMany(p => p.ApplicationFormsSecurity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__FormI__30F848ED");

            entity.HasOne(d => d.Role).WithMany(p => p.ApplicationFormsSecurity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__RoleI__300424B4");
        });

        modelBuilder.Entity<ApplicationRoles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC077A5C8C51");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ApplicationUsers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07A9D39E94");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Role).WithMany(p => p.ApplicationUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__RoleI__403A8C7D");
        });

        OnModelCreatingGeneratedFunctions(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}