using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTimeMonitor.Migrations
{
    public partial class IniialMigrion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTimerRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClockInTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClockOutTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimerRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTimerRecord");
        }
    }
}
