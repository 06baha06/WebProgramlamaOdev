using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaOdev.Migrations
{
    public partial class migrationRandevu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaID = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false),
                    SaatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevular_Bolumler_BolumID",
                        column: x => x.BolumID,
                        principalTable: "Bolumler",
                        principalColumn: "BolumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevular_Hastalar_HastaID",
                        column: x => x.HastaID,
                        principalTable: "Hastalar",
                        principalColumn: "HastaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Randevular_Saatler_SaatID",
                        column: x => x.SaatID,
                        principalTable: "Saatler",
                        principalColumn: "SaatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_BolumID",
                table: "Randevular",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HastaID",
                table: "Randevular",
                column: "HastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_SaatID",
                table: "Randevular",
                column: "SaatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevular");
        }
    }
}
