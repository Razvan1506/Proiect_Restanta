using Microsoft.EntityFrameworkCore.Migrations;

namespace Tamba_Razvan_Catalin.Migrations
{
    public partial class DogBreed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonorID",
                table: "Dog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DogBreed",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(nullable: false),
                    BreedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreed", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DogBreed_Breed_BreedID",
                        column: x => x.BreedID,
                        principalTable: "Breed",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogBreed_Dog_DogID",
                        column: x => x.DogID,
                        principalTable: "Dog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_DonorID",
                table: "Dog",
                column: "DonorID");

            migrationBuilder.CreateIndex(
                name: "IX_DogBreed_BreedID",
                table: "DogBreed",
                column: "BreedID");

            migrationBuilder.CreateIndex(
                name: "IX_DogBreed_DogID",
                table: "DogBreed",
                column: "DogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Donor_DonorID",
                table: "Dog",
                column: "DonorID",
                principalTable: "Donor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Donor_DonorID",
                table: "Dog");

            migrationBuilder.DropTable(
                name: "DogBreed");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropIndex(
                name: "IX_Dog_DonorID",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "DonorID",
                table: "Dog");
        }
    }
}
