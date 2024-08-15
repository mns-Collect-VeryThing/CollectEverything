using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectEverything.Commandes.Migrations
{
    /// <inheritdoc />
    public partial class Articlesandcommandesasseparateaggregates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandesCommande",
                table: "CommandesCommande");

            migrationBuilder.RenameTable(
                name: "CommandesCommande",
                newName: "CommandesCommandes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandesCommandes",
                table: "CommandesCommandes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommandesArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prix = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RemovedFromSale = table.Column<bool>(type: "boolean", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandesArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandesArticleDansPanierJoinEntities",
                columns: table => new
                {
                    PanierId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandesArticleDansPanierJoinEntities", x => new { x.PanierId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_CommandesArticleDansPanierJoinEntities_CommandesArticles_Ar~",
                        column: x => x.ArticleId,
                        principalTable: "CommandesArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandesArticleDansPanierJoinEntities_CommandesCommandes_P~",
                        column: x => x.PanierId,
                        principalTable: "CommandesCommandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandesArticleDansPanierJoinEntities_ArticleId",
                table: "CommandesArticleDansPanierJoinEntities",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandesArticleDansPanierJoinEntities_PanierId_ArticleId",
                table: "CommandesArticleDansPanierJoinEntities",
                columns: new[] { "PanierId", "ArticleId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandesArticleDansPanierJoinEntities");

            migrationBuilder.DropTable(
                name: "CommandesArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandesCommandes",
                table: "CommandesCommandes");

            migrationBuilder.RenameTable(
                name: "CommandesCommandes",
                newName: "CommandesCommande");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandesCommande",
                table: "CommandesCommande",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    PanierId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => new { x.PanierId, x.Id });
                    table.ForeignKey(
                        name: "FK_Article_CommandesCommande_PanierId",
                        column: x => x.PanierId,
                        principalTable: "CommandesCommande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
