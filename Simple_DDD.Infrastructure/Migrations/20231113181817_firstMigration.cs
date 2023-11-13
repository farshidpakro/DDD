using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examlist", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examlist");
        }
    }
}
