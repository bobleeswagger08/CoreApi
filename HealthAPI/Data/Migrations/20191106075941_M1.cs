using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAPI.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patinet",
                columns: table => new
                {
                    PatinetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patinet", x => x.PatinetId);
                });

            migrationBuilder.CreateTable(
                name: "Ailment",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    PatientPatinetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ailment", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ailment_Patinet_PatientPatinetId",
                        column: x => x.PatientPatinetId,
                        principalTable: "Patinet",
                        principalColumn: "PatinetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Doses = table.Column<string>(nullable: true),
                    PatientPatinetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Medication_Patinet_PatientPatinetId",
                        column: x => x.PatientPatinetId,
                        principalTable: "Patinet",
                        principalColumn: "PatinetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ailment_PatientPatinetId",
                table: "Ailment",
                column: "PatientPatinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_PatientPatinetId",
                table: "Medication",
                column: "PatientPatinetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ailment");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Patinet");
        }
    }
}
