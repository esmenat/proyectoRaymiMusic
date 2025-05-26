using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RaymiMusic.Modelos;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<RaymiMusic.Modelos.Album> Albumes { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Artista> Artistas { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Cancion> Canciones { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.CancionPlaylist> CancionesPlaylists { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Estadistica> Estadisticas { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Favorito> Favoritos { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.HistorialReproduccion> HistorialReproducciones { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Pago> Pagos { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Playlist> Playlists { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.RefreshToken> RefreshTokens { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Reproduccion> Reproducciones { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Rol> Roles { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Seguidor> Seguidores { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Suscripcion> Suscripciones { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.TipoSuscripcion> TiposSuscripciones { get; set; } = default!;

        public DbSet<RaymiMusic.Modelos.Usuario> Usuarios { get; set; } = default!;
    }
