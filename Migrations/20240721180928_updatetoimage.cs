using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commrec.Migrations
{
    public partial class updatetoimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "prouducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "prouducts");
        }
    }
}
