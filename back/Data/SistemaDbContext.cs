using back.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace back.Data
{
    public class SistemaDbContext : IdentityDbContext<Usuario>
    {
        public SistemaDbContext(DbContextOptions opts) : base(opts)
        {


        }


        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            Builder.Entity<Campeonatos>().HasIndex(c => c.Titulo).IsUnique();

            Builder.Entity<Campeonatos>().HasIndex(c => new
            {
                c.Estado,
                c.Cidade
            }).IsUnique();

            Builder.Entity<Campeonatos>().Property(c => c.Entrada).HasPrecision(4, 2);
            Builder.Entity<Atletas>().HasIndex(a => a.CPF).IsUnique();

            Builder.Entity<AtletaCampeonato>().HasKey(ac => new
            {
                ac.AtletaId,
                ac.CampeonatoId
            });

            Builder.Entity<AtletaCampeonato>().HasOne(ac => ac.Atleta)
                .WithMany(atleta => atleta.AtletaCampeonatos)
                .HasForeignKey(ac => ac.AtletaId);

            Builder.Entity<AtletaCampeonato>().HasOne(ac => ac.Campeonatos)
            .WithMany(campeonato => campeonato.AtletaCampeonatos)
            .HasForeignKey(ac => ac.CampeonatoId);

            Builder.Entity<AtletasLutas>()
                .HasKey(al => new { al.AtletasId, al.LutasId });

            // Configura as relações entre Atletas e Lutas
            Builder.Entity<AtletasLutas>()
                .HasOne(al => al.Atletas)
                .WithMany(a => a.AtletasLutas)
                .HasForeignKey(al => al.AtletasId);


            Builder.Entity<AtletasLutas>()
                .HasOne(al => al.Lutas)
                .WithMany(l => l.AtletasLutas)
                .HasForeignKey(al => al.LutasId);

        }

        public DbSet<Campeonatos> Campeonatos { get; set; }
        public DbSet<Atletas> Atletas { get; set; }
        public DbSet<AtletaCampeonato> AtletaCampeonato { get; set; }
        public DbSet<Chaves> Chaves { get; set; }
        public DbSet<Lutas> Lutas { get; set; }
        public DbSet<AtletasLutas> AtletasLutas { get; set; }

    }
}
