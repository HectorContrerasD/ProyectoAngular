using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KpopApi.Models.Entities;

public partial class WebsitosAngularProjectContext : DbContext
{
    public WebsitosAngularProjectContext()
    {
    }

    public WebsitosAngularProjectContext(DbContextOptions<WebsitosAngularProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kpopgroup> Kpopgroup { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Kpopgroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kpopgroup");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CantidadAlbums).HasColumnType("int(11)");
            entity.Property(e => e.Imagen).HasMaxLength(255);
            entity.Property(e => e.Integrantes).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
