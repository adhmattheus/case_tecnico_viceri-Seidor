using APISuperHeroi.Model;
using Microsoft.EntityFrameworkCore;
using System;

public class AppDbContext : DbContext
{
    public DbSet<Heroi> Herois { get; set; }
    public DbSet<SuperPoderes> Superpoderes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Heroi>()
            .Property(h => h.Id)
            .ValueGeneratedOnAdd(); // Configuração para gerar automaticamente valores ao adicionar

        builder.Entity<SuperPoderes>().HasData(
            SuperPoderes.ObterOpcoesIniciais()
        );

        builder.Entity<Heroi>()
           .HasIndex(h => h.NomeHeroi)
           .IsUnique();

        builder.Entity<HeroisSuperPoderes>()
            .HasKey(p => new { p.SuperPoderesId, p.HeroiId });

        builder.Entity<HeroisSuperPoderes>()
            .HasOne(p => p.Heroi)
            .WithMany(h => h.HeroisSuperPoderes)
            .HasForeignKey(p => p.HeroiId);
            }
}