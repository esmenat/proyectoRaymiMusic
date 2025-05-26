using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RaymiMusic.Api.Migrations
{
    /// <inheritdoc />
    public partial class reproductor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreRol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TiposSuscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    PrecioMensual = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSuscripciones", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: true),
                    Activa = table.Column<bool>(type: "boolean", nullable: false),
                    TipoSuscripcionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Suscripciones_TiposSuscripciones_TipoSuscripcionCodigo",
                        column: x => x.TipoSuscripcionCodigo,
                        principalTable: "TiposSuscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    MetodoPago = table.Column<string>(type: "text", nullable: false),
                    SuscripcionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pagos_Suscripciones_SuscripcionCodigo",
                        column: x => x.SuscripcionCodigo,
                        principalTable: "Suscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreUsuario = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Contraseña = table.Column<string>(type: "text", nullable: false),
                    FechaNac = table.Column<DateOnly>(type: "date", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    FotoPerfilURL = table.Column<string>(type: "text", nullable: true),
                    RolCodigo = table.Column<int>(type: "integer", nullable: false),
                    SuscripcionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolCodigo",
                        column: x => x.RolCodigo,
                        principalTable: "Roles",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Suscripciones_SuscripcionCodigo",
                        column: x => x.SuscripcionCodigo,
                        principalTable: "Suscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreArtistico = table.Column<string>(type: "text", nullable: false),
                    Biografia = table.Column<string>(type: "text", nullable: false),
                    UsuarioCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Artistas_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    EsPublica = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: true),
                    UsuarioCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Playlists_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeguidorCodigo = table.Column<int>(type: "integer", nullable: false),
                    SeguidorUsuarioCodigo = table.Column<int>(type: "integer", nullable: true),
                    SeguidoCodigo = table.Column<int>(type: "integer", nullable: false),
                    SeguidoUsuarioCodigo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuarios_SeguidoUsuarioCodigo",
                        column: x => x.SeguidoUsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuarios_SeguidorUsuarioCodigo",
                        column: x => x.SeguidorUsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateTable(
                name: "Albumes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    FechaLanzamiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: true),
                    ArtistaCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Albumes_Artistas_ArtistaCodigo",
                        column: x => x.ArtistaCodigo,
                        principalTable: "Artistas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TituloCancion = table.Column<string>(type: "text", nullable: false),
                    Duracion = table.Column<int>(type: "integer", nullable: false),
                    Ruta = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: true),
                    ArtistaCodigo = table.Column<int>(type: "integer", nullable: false),
                    AlbumCodigo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Canciones_Albumes_AlbumCodigo",
                        column: x => x.AlbumCodigo,
                        principalTable: "Albumes",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Canciones_Artistas_ArtistaCodigo",
                        column: x => x.ArtistaCodigo,
                        principalTable: "Artistas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancionesPlaylists",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    CancionCodigo = table.Column<int>(type: "integer", nullable: false),
                    PlaylistCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancionesPlaylists", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_CancionesPlaylists_Canciones_CancionCodigo",
                        column: x => x.CancionCodigo,
                        principalTable: "Canciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancionesPlaylists_Playlists_PlaylistCodigo",
                        column: x => x.PlaylistCodigo,
                        principalTable: "Playlists",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estadisticas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReproduccionesTotales = table.Column<int>(type: "integer", nullable: false),
                    FavoritosTotales = table.Column<int>(type: "integer", nullable: false),
                    CancionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadisticas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Estadisticas_Canciones_CancionCodigo",
                        column: x => x.CancionCodigo,
                        principalTable: "Canciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioCodigo = table.Column<int>(type: "integer", nullable: false),
                    CancionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Favoritos_Canciones_CancionCodigo",
                        column: x => x.CancionCodigo,
                        principalTable: "Canciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialReproducciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCodigo = table.Column<int>(type: "integer", nullable: false),
                    CancionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialReproducciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_HistorialReproducciones_Canciones_CancionCodigo",
                        column: x => x.CancionCodigo,
                        principalTable: "Canciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialReproducciones_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reproducciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioCodigo = table.Column<int>(type: "integer", nullable: false),
                    CancionCodigo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reproducciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Reproducciones_Canciones_CancionCodigo",
                        column: x => x.CancionCodigo,
                        principalTable: "Canciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reproducciones_Usuarios_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albumes_ArtistaCodigo",
                table: "Albumes",
                column: "ArtistaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_UsuarioCodigo",
                table: "Artistas",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_AlbumCodigo",
                table: "Canciones",
                column: "AlbumCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_ArtistaCodigo",
                table: "Canciones",
                column: "ArtistaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CancionesPlaylists_CancionCodigo",
                table: "CancionesPlaylists",
                column: "CancionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_CancionesPlaylists_PlaylistCodigo",
                table: "CancionesPlaylists",
                column: "PlaylistCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Estadisticas_CancionCodigo",
                table: "Estadisticas",
                column: "CancionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_CancionCodigo",
                table: "Favoritos",
                column: "CancionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UsuarioCodigo",
                table: "Favoritos",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialReproducciones_CancionCodigo",
                table: "HistorialReproducciones",
                column: "CancionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialReproducciones_UsuarioCodigo",
                table: "HistorialReproducciones",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_SuscripcionCodigo",
                table: "Pagos",
                column: "SuscripcionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UsuarioCodigo",
                table: "Playlists",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UsuarioCodigo",
                table: "RefreshTokens",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reproducciones_CancionCodigo",
                table: "Reproducciones",
                column: "CancionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reproducciones_UsuarioCodigo",
                table: "Reproducciones",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_SeguidorUsuarioCodigo",
                table: "Seguidores",
                column: "SeguidorUsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_SeguidoUsuarioCodigo",
                table: "Seguidores",
                column: "SeguidoUsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_TipoSuscripcionCodigo",
                table: "Suscripciones",
                column: "TipoSuscripcionCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolCodigo",
                table: "Usuarios",
                column: "RolCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SuscripcionCodigo",
                table: "Usuarios",
                column: "SuscripcionCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancionesPlaylists");

            migrationBuilder.DropTable(
                name: "Estadisticas");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "HistorialReproducciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Reproducciones");

            migrationBuilder.DropTable(
                name: "Seguidores");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Albumes");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropTable(
                name: "TiposSuscripciones");
        }
    }
}
