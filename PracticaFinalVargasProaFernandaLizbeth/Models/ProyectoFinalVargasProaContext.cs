using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaFinalVargasProaFernandaLizbeth.Models;

public partial class ProyectoFinalVargasProaContext : DbContext
{
    public ProyectoFinalVargasProaContext()
    {
    }

    public ProyectoFinalVargasProaContext(DbContextOptions<ProyectoFinalVargasProaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonaItem> PersonaItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; DataBase=Proyecto_Final_Vargas_Proa;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonaItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonaI__3214EC073B4DF3D8");

            entity.ToTable("PersonaItem");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
